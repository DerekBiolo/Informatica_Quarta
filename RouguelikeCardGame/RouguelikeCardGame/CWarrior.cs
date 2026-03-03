using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal class CWarrior : CPersonaggio
    {
        //warrior ( 100hp +-5% , 20ap +-5% )
        private static Random r = new Random();
        public CWarrior(string name)
            : base(name,
                  100 + r.Next(-5, 6), // HealthPoints with ±5% variation
                  20 + r.Next(-1, 2),  // AttackPoints with ±5% variation
                  CharacterType.Warrior)
        {
        }
    }
}
