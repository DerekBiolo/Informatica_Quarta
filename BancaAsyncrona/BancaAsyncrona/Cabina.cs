using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace BancaAsyncrona
{
    enum Direzione
    {
        Entrata,
        Uscita
    }

    internal class Cabina(int max)
    {


        private readonly int _max = max;
        private int _dentro = 0;
        private Direzione? _direzione = null;

        private readonly SemaphoreSlim _mutex = new(1, 1);
        private readonly SemaphoreSlim _posti = new(max, max);

        private readonly List<Cliente> _clienti = [];

        private Barrier? _barriera = null;
        private bool? _risultatoGruppo = null;
        private bool _controlloEffettuato = false;

        public async Task<bool> Entra(Direzione dir, Cliente c)
        {
            while (true)
            {
                await _mutex.WaitAsync();
                bool puo_entrare = (_direzione == null || _direzione == dir) && _dentro < _max;
                _mutex.Release();

                if (puo_entrare)
                {
                    await _posti.WaitAsync();
                    break;
                }
                await Task.Delay(100);
            }

            await _mutex.WaitAsync();

            _clienti.Add(c);
            _dentro++;
            _direzione ??= dir;

            if (_barriera == null)
            {
                _barriera = new Barrier(_max);
                _risultatoGruppo = null;
                _controlloEffettuato = false;
            }

            int clientiAttuali = _dentro;
            bool sono_primo = clientiAttuali == 1;
            _mutex.Release();

            Console.WriteLine($"[INFO] Cliente {c.id} entra nella cabina ({clientiAttuali}/{_max})");

            await Task.Run(() => _barriera.SignalAndWait()); //SIgnal and wait aspetta che tutti arrivino, quando ci sono 5 clienti procede ma solo il primo fa il con trollo e stampa pero ti(ma lo faranno tutti)

            if (dir == Direzione.Entrata)
            {
                await _mutex.WaitAsync();
                bool devo_controllare = !_controlloEffettuato;
                if (devo_controllare)
                {
                    _controlloEffettuato = true;
                }
                _mutex.Release();

                if (devo_controllare)
                {
                    //entra solo il primo cliente che arriva qui (gli altri aspettano la barriera)
                    Console.WriteLine($"\nGRUPPO AL COMPLETO! Tutti e {_max} i clienti passano al metal detector:");

                    await _mutex.WaitAsync();
                    foreach (Cliente cliente in _clienti)
                    {
                        Console.WriteLine($"Cliente ID: {cliente.id}{(cliente.haMetallo ? "(HA METALLO == DORMIGLIONE!" : " (NON HA METALLO)")}");
                    }
                    _mutex.Release();

                    Console.WriteLine("\nControllo metal detector in corso...");
                    await Task.Delay(1000);

                    // se qualcuno ha il metallo tutti a dormire (a nanna tutti zitti)
                    await _mutex.WaitAsync();
                    bool qualcuno_ha_metallo = MetalDetector.Controllo(_clienti);
                    _risultatoGruppo = !qualcuno_ha_metallo;
                    _mutex.Release();

                    if (_risultatoGruppo.Value)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("NESSUNO aveva metallo! Tutto il gruppo può ENTRARE!\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Qualcuno aveva metallo! Tutto il gruppo è ESPULSO! (NON VOGLIO SNITCH NEL GANG)\n");
                        Console.ResetColor();
                    }
                }
                // qeusa barriera aspetta che tutti arrivano qui dopo il controllo
                await Task.Run(() => _barriera.SignalAndWait());

                await _mutex.WaitAsync();
                bool risultato = _risultatoGruppo.Value;
                _mutex.Release();

                return risultato; // ritorna true se possono entrare, false se devono andare via
            }
            else // usicta
            {

                await _mutex.WaitAsync();
                bool devo_stampare = !_controlloEffettuato;
                if (devo_stampare)
                {
                    _controlloEffettuato = true;
                }
                _mutex.Release();

                if (devo_stampare)
                {
                    Console.WriteLine($"\nGRUPPO IN USCITA AL COMPLETO! Tutti e {_max} clienti escono insieme:");

                    await _mutex.WaitAsync();
                    foreach (Cliente cliente in _clienti)
                    {
                        Console.WriteLine($"Cliente ID: {cliente.id}");
                    }
                    _mutex.Release();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Il gruppo esce dalla banca\n");
                    Console.ResetColor();
                }

                //aspetto cjhe tutti arrivano qui prima di procedere
                await Task.Run(() => _barriera.SignalAndWait());

                return true;
            }
        }

        public async Task EsciDallaBanca(Cliente c)
        {
            Console.WriteLine($"Cliente {c.id} ha finito le operazioni, vuole uscire.");
            bool uscito = await Entra(Direzione.Uscita, c);

            if (uscito)
            {
                Console.WriteLine($"Cliente {c.id} è uscito con successo.");
            }
        }

        public async Task Esci(Cliente c)
        {
            await _mutex.WaitAsync();
            _clienti.Remove(c);
            _dentro--;
            _posti.Release();

            //reset di tutto se non c'è nessuno dentro
            if (_dentro == 0)
            {
                _direzione = null;
                _barriera?.Dispose();
                _barriera = null;
                _risultatoGruppo = null;
                _controlloEffettuato = false;
            }

            _mutex.Release();
        }
    }
}