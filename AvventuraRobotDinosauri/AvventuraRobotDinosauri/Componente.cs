using System;
using System.Collections.Generic;
using System.Text;

namespace AvventuraRobotDinosauri
{
    //singolo componente
    internal class Componente
    {
        public string Name { get; set; }
        public Componente(string name)
            { this.Name = name; }
    }
}
