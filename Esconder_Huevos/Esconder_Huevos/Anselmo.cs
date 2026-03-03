using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using LinkedCoda;

namespace Esconder_Huevos
{
    internal class Anselmo
    {
        private readonly BugsBunny _fabbrica;
        private readonly LinkedCoda<Huevo> _nascondiglioHuevos;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public Anselmo(BugsBunny fabbrica, LinkedCoda<Huevo> nascondiglioHuevos, CancellationTokenSource cancellationTokenSource)
        {
            _fabbrica = fabbrica;
            _nascondiglioHuevos = nascondiglioHuevos;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public async Task ControllaENascondi()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {

                if (_nascondiglioHuevos.Count() == _fabbrica.MAX_HUEVOS)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Anselmo ha finito di nascondere uova, se ve de mo");
                    _cancellationTokenSource.Cancel();
                    Console.ResetColor();
                    break;
                }
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Anselmo sta controllando e nascondendo un uovo...");
                Console.ResetColor();
                Huevo uovo = _fabbrica.PrendiUovoDaNascondere();
                Console.WriteLine("Ho preso un uovo da nascondere: " + uovo.Colore1 + " " + uovo.Colore2);
                Huevo lastUovo;
                if(_nascondiglioHuevos.Count() > 0)
                {
                    lastUovo = _nascondiglioHuevos.Peek();
                    Console.WriteLine("L'ultimo uovo nascosto è: " + lastUovo.Colore1 + " " + lastUovo.Colore2);
                } else {
                    Console.WriteLine("Non ci sono uova nascoste, nascondo il primo uovo senza controllo.");
                    _nascondiglioHuevos.Enqueue(uovo);
                    await Task.Delay(1000);
                    continue;
                }

                if (uovo.Colore1 == lastUovo.Colore1 || uovo.Colore2 == lastUovo.Colore2 || uovo.Colore1 == lastUovo.Colore2 || uovo.Colore2 == lastUovo.Colore1)
                {
                    _nascondiglioHuevos.Enqueue(uovo);
                    Console.WriteLine($"Uovo nascosto: {uovo.Colore1} {uovo.Colore2}");
                    await Task.Delay(1000);
                } else {
                    Console.WriteLine($"Uovo non nascosto: {uovo.Colore1} {uovo.Colore2}, non idoneo a essere nascosto.");
                    //lo rimando a colorarsi
                    await Task.Run(() => _fabbrica.Ricolora(uovo));
                }

                Console.WriteLine($"Uova nascoste finora: {_nascondiglioHuevos.Count()}");
                Console.WriteLine($"Uova rimaste da nascondere: {_fabbrica.MAX_HUEVOS}");
                Console.WriteLine("--------------------------------------------------\n\n");
            }
        }
    }
}
