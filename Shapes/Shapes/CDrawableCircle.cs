using System;
using System.Drawing;
using static System.Console;

namespace Shapes
{
    internal class CDrawableCircle : CCircle, IDrawable, IEquatable<CDrawableCircle>
    {
        public Color Color { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public CDrawableCircle(double radius) : base(radius) { }

        // Implementazione IDrawable
        public void SetColor(Color color) => Color = color;
        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Draw()
        {

            // Convertiamo System.Drawing.Color in ConsoleColor
            Console.ForegroundColor = ConsoleColorFromColor(Color);

            // Simuliamo la posizione verticale
            for (int i = 0; i < Y; i++)
                WriteLine();

            // Disegno ASCII del cerchio
            for (int y = -(int)raggio; y <= (int)raggio; y++)
            {
                // Spazio per la posizione orizzontale
                Write(new string(' ', X));

                for (int x = -(int)raggio; x <= (int)raggio; x++)
                {
                    if (x * x + y * y <= raggio * raggio)
                        Write("*");
                    else
                        Write(" ");
                }
                WriteLine();
            }

            // Ripristiniamo colore di default
            Console.ResetColor();
        }

        // Metodo helper per convertire System.Drawing.Color in ConsoleColor
        private ConsoleColor ConsoleColorFromColor(Color color)
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


        // Implementazione IEquatable
        public bool Equals(CDrawableCircle? other)
        {
            if (other == null) return false;
            return this.raggio == other.raggio &&
                   this.Color.Equals(other.Color) &&
                   this.X == other.X &&
                   this.Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CDrawableCircle);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(raggio, Color, X, Y);
        }
    }
}
