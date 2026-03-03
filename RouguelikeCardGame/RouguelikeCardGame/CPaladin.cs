using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal class CPaladin : CPersonaggio
    {
        //paladin ( 120hp +-5% , 15ap +-5% )
        private static Random r = new Random();
        public CPaladin(string name)
            : base(name,
                  120 + r.Next(-6, 7), // HealthPoints with ±5% variation
                  15 + r.Next(-1, 2),  // AttackPoints with ±5% variation
                  CharacterType.Paladin)
        {
        }
    }
}
