using System;
using System.Collections.Generic;

namespace La_Fattoria_Degli_Animali
{
    public delegate void RiproduzioneVersoHandler(string versoPath, string nomeAnimale);

    internal class Fattoria
    {
        public List<Animale> animali = new List<Animale>();

        public event RiproduzioneVersoHandler VersoRiprodotto;

        public void AggiungiAnimale(Animale a)
        {
            animali.Add(a);
        }

        public void RichiediVerso(Animale a)
        {
            VersoRiprodotto?.Invoke(a.GetVersoPath(), a.Nome);
        }
    }
}
