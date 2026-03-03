using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FileMultimediali
{
    internal class CAudioFile : CMultimediaFile , IVolume
    {
        public int volumeLevel;
        public int durationInSeconds;
        public int durationInMinutes;

        public CAudioFile(string fileName, int volumeLevel, int durationInSeconds, int durationInMinutes) : base(fileName)
        {
            this.volumeLevel = volumeLevel;
            this.durationInMinutes = durationInMinutes + durationInSeconds / 60;
            this.durationInSeconds = durationInSeconds % 60;
        }

        // implemento i void
        public void IncreaseVolume()
        {
            if (volumeLevel < 100)
            {
                volumeLevel += 10;
            }
        }
        public void DecreaseVolume()
        {
            if (volumeLevel > 0)
            {
                volumeLevel -= 10;
            }
        }


        public override void Play()
        {
            if (volumeLevel > 0)
            {
                WriteLine($"Playing audio file: {FileName} at volume level: {volumeLevel}");
            }
            else
            {
                WriteLine($"Audio file: {FileName} is not playable.");
            }
        }

        public override string Stringfy()
        {
             return $"{base.Stringfy()}Volume Level: {volumeLevel}, Duration: {durationInMinutes} minutes and {durationInSeconds} seconds.";
        }
    }
}
