using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class CRectangle : AShape
    {
        public double larghezza;
        public double altezza;

        public CRectangle(double l, double a)
        {
            larghezza = l;
            altezza = a;
        }

        public override double GetArea()
        {
            return larghezza * altezza;
        }

        public override double GetPerimeter()
        {
            return 2 * (larghezza + altezza);
        }

    }
}
