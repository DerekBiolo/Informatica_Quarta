using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Console;

namespace Shapes
{
    internal class CDrawableRectangle : CRectangle, IDrawable, IEquatable<CDrawableRectangle>
    {
        public Color color;
        public int x; 
        public int y;

        public CDrawableRectangle(double width, double height) : base(width, height) { }

        public void SetColor(Color c)
        {
            color = c;
        }

        public void SetPosition(int xpos, int ypos)
        {
            x = xpos;
            y = ypos;
        }

        public void Draw()
        {

            // Convertiamo System.Drawing.Color in ConsoleColor
            Console.ForegroundColor = consolecolorfromcolor(color);

            // Posizione verticale
            for (int i = 0; i < y; i++)
                WriteLine();

            // Disegno ASCII del rettangolo usando larghezza e altezza
            for (int i = 0; i < (int)altezza; i++)
            {
                // Posizione orizzontale
                Write(new string(' ', x));

                // Riga del rettangolo
                WriteLine(new string('*', (int)larghezza));
            }

            // Ripristina colore di default
            Console.ResetColor();
        }

        // Helper per convertire System.Drawing.Color in ConsoleColor
        private ConsoleColor consolecolorfromcolor(Color color)
        {
            return color.Name.ToLower() switch
            {
                "red" => ConsoleColor.Red,
                "green" => ConsoleColor.Green,
                "blue" => ConsoleColor.Blue,
                "yellow" => ConsoleColor.Yellow,
                "cyan" => ConsoleColor.Cyan,
                "magenta" => ConsoleColor.Magenta,
                "white" => ConsoleColor.White,
                "black" => ConsoleColor.Black,
                _ => ConsoleColor.Gray
            };
        }


        public bool Equals(CDrawableRectangle? other)
        {
            if (other == null) return false;
            return this.larghezza == other.larghezza && this.altezza == other.altezza && this.x == other.x && this.y == other.y && this.color.Equals(other.color);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(larghezza, altezza, x, y, color);
        }
    }
}
