using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal class CArcher : CPersonaggio
    {
        private static Random r = new Random();
        // archer ( 80hp+- 5% , 25ap+-5% )
        public CArcher(string name)
            : base(name,
                  80 + r.Next(-4, 5), // HealthPoints with ±5% variation
                  25 + r.Next(-2, 3), // AttackPoints with ±5% variation
                  CharacterType.Archer)
        {
        }
    }
}
