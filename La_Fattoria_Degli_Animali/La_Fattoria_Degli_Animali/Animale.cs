using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace La_Fattoria_Degli_Animali
{
    public abstract class Animale
    {
        public string Nome;
        public string ImmaginePath;
        public string VersoPath;

        public Animale(string nome, string immaginePath, string versoPath)
        {
            Nome = nome;
            ImmaginePath = immaginePath;
            VersoPath = versoPath;
        }

        public string GetVersoPath()
        {
            return VersoPath;
        }
    }

    public class Cane : Animale
    {
        public Cane() : base("Cane", "CaneDefault.png", "CaneVDefault.mp3") { }
    }

    public class Gatto : Animale
    {
        public Gatto() : base("Gatto", "GattoDefault.png", "GattoVDefault.mp3") { }
    }

    public class Mucca : Animale
    {
        public Mucca() : base("Mucca", "MuccaDefault.png", "MuccaVDefault.mp3") { }
    }

}
