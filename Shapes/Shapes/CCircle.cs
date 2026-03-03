using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class CCircle : AShape
    {
        public double raggio;
        public CCircle(double r)
        {
            raggio = r;
        }
        public override double GetArea()
        {
            return Math.PI * raggio * raggio;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * raggio;
        }
    }
}
