using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AttaccoAlRe
{
    internal class CRe : APersonaggio
    {
        private string fileOutput = "output.txt";
        public event AttaccoEventHandler SottoAttacco;

        public CRe(string nome) : base(nome) { }

        public void SubisciAttacco()
        {
            string mess = $"Il re {Nome} è sotto attacco";

            Console.WriteLine(mess);

            try
            {
                File.AppendAllText(fileOutput, mess);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex}");
                SottoAttacco?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}