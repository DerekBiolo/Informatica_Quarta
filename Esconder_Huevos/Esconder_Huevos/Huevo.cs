using System;
using System.Collections.Generic;
using System.Text;

namespace Esconder_Huevos
{
    public enum Colori
    {
        Rosso,
        Verde,
        Giallo,
        Azzurro,
        Viola,  
        Arancione,
        Bianco
    }
    public class Huevo
    {
        public Colori? prevColor1 = null;
        public Colori? prevColor2 = null;

        public Colori Colore1;
        public Colori Colore2;

        public void Colora()
        {
            Random r = new Random();
            if (prevColor1 == null || prevColor2 == null)
            {
                Colore1 = (Colori)r.Next(0, 7);
                Colore2 = (Colori)r.Next(0, 7);
                prevColor1 = Colore1;
                prevColor2 = Colore2;
            } else
            {
                do
                {
                    Colore1 = (Colori)r.Next(0, 7);
                    Colore2 = (Colori)r.Next(0, 7);
                } while (Colore1 == prevColor1 || Colore1 == prevColor2 || Colore2 == prevColor1 || Colore2 == prevColor2);
            }
        }
    }
}
