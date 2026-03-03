using System;
using System.Collections.Generic;
using System.Text;

namespace AvventuraRobotDinosauri
{
    using LinkedPila;
    internal class Dinosauro
    {
        private string _nome;
        private Magazzino _magazzino;
        private LinkedPila<Componente> _pilaCostruzione;
        private int _altezzaTarget;
        private object _lock = new object();

        public Dinosauro(string nome, Magazzino magazzino, int altezzaTarget, LinkedPila<Componente> pilaCostruzione)
        {
            _nome = nome;
            _magazzino = magazzino;
            _altezzaTarget = altezzaTarget;
            _pilaCostruzione = pilaCostruzione;
        }

        public async Task Costruisci()
        {
            while (!_magazzino.produzioneTerminata || _magazzino.PezziRimanenti() > 0)
            {
                Componente pezzo = _magazzino.PrendiPezzo();

                if (pezzo != null)
                {
                    lock (_lock)
                    {
                        _pilaCostruzione.Push(pezzo);
                    }
                    Console.WriteLine($"DINO DINO {_nome}: Ho piazziato il pezzo {pezzo.Name} ora e alta {_pilaCostruzione.Count()}.");
                    await Task.Delay(2000);
                    await Task.Delay(Random.Shared.Next(500, 1000)); // tempo pam pam costruire

                    if (_pilaCostruzione.Count() >= _altezzaTarget)
                    {
                        Console.WriteLine($"DINO DINO {_nome}: Ho raggiunto l'altezza target di {_altezzaTarget} pezzi!");
                        Console.WriteLine("svuoto la pila di costruzione...");
                        _pilaCostruzione.Clear();
                    }
                }
                else
                {
                    await Task.Delay(500); // polling delay se non ci sono pezzi disponibili
                }
            }
            Console.WriteLine($"DINO DINO {_nome}: ze fini i tocchi!");
        }
    }
}