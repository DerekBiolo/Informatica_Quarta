using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Security.Permissions;

namespace Battaglia_Navale_V2
{
    internal class SoundManager
    {
        SoundPlayer player;
        public void PlayHitSound()
        {
            player = new SoundPlayer("hit.wav");
        }

        public void PlayMissSound()
        {
            player = new SoundPlayer("miss.wav");
        }

        public void PlaySunkSound()
        {
            player = new SoundPlayer("sunk.wav");
        }
    }
}
