using System;
using System.Collections.Generic;
using System.Text;

namespace AvventuraRobotDinosauri
{
    internal class Robot
    {
        private string _nome;
        private Magazzino _magazzino;

        public Robot(string nome, Magazzino magazzino)
        {
            _nome = nome;
            _magazzino = magazzino;
        }

        public async Task Raccogli(int quantita)
        {
            for (int indice = 0; indice < quantita; indice++)
            {
                await Task.Delay(2000);
                await Task.Delay(Random.Shared.Next(300, 701)); // tempo di raccolta
                var pezzo = new Componente($"Pezzo-{_nome}-{indice}");
                _magazzino.Aggiungi(pezzo);
                Console.WriteLine($"ROBOT: {_nome} ha raccolto: {pezzo.Name}");
            }
        }
    }
}
