using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    internal interface IDrawable
    {
        void SetColor(Color color);
        void SetPosition(int x, int y);
        void Draw();
    }
}
