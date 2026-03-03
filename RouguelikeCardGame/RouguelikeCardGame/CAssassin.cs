using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal class CAssassin : CPersonaggio
    {
        private static Random r = new Random();
        //assassin ( 90hp+- 5% , 35ap+-5% )
        public CAssassin(string name)
            : base(name,
                  60 + r.Next(-3, 4), // HealthPoints with ±5% variation
                  35 + r.Next(-2, 3), // AttackPoints with ±5% variation
                  CharacterType.Assassin)
        {
        }
    }
}
