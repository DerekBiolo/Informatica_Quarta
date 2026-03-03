using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurePiane
{
    internal class CRettangolo : IFiguraPiana
    {
        public double Larghezza { get; set; }
        public double Altezza { get; set; }

        public CRettangolo(double larghezza, double altezza)
        {
            Larghezza = larghezza;
            Altezza = altezza;
        }

        public double CalcolaPerimetro()
        {
            return 2 * (Larghezza + Altezza);
        }

        public double CalcolaArea()
        {
            return Larghezza * Altezza;
        }
    }
}
