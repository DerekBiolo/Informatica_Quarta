using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal class CMage : CPersonaggio
    {
        //mage ( 70hp+- 5% , 30ap+-5% )
        private static Random r = new Random();
        public CMage(string name)
            : base(name,
                  70 + r.Next(-4, 5), // HealthPoints with ±5% variation
                  30 + r.Next(-2, 3), // AttackPoints with ±5% variation
                  CharacterType.Mage)
        {
        }
    }
}
