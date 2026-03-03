using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurePiane
{
    internal class CCerchio : IFiguraPiana
    {
        public double Raggio { get; set; }

        public CCerchio(double raggio)
        {
            Raggio = raggio;
        }

        public double CalcolaPerimetro()
        {
            return 2 * Math.PI * Raggio;
        }

        public double CalcolaArea()
        {
            return Math.PI * Raggio * Raggio;
        }
    }
}
