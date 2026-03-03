using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediali
{
    internal class CVideo : CAudioFile, IBrightness, IComparable<CVideo>
    {
        public int brightnessLevel;
        public int minutesDuration;
        public int secondsDuration;

        public CVideo(string fileName, int volumeLevel, int minutesDuration, int secondsDuration, int brightnessLevel)
            : base(fileName, volumeLevel, secondsDuration, minutesDuration)
        {
            this.brightnessLevel = brightnessLevel;
            this.minutesDuration = minutesDuration + secondsDuration / 60;
            this.secondsDuration = secondsDuration % 60;
        }

        // implemento  i nuovi void
        public void IncreaseBrightness()
        {
            if (brightnessLevel < 100)
            {
                brightnessLevel += 10;
            }
        }

        public void DecreaseBrightness()
        {
            if (brightnessLevel > 0)
            {
                brightnessLevel -= 10;
            }
        }

        public int CompareTo(CVideo? other)
        {
            if (other == null) return 1;
            int totalDuration1 = this.secondsDuration + (this.minutesDuration * 60);
            int totalDuration2 = other.secondsDuration + (other.minutesDuration * 60);
            return totalDuration1.CompareTo(totalDuration2);
        }

        public override string Stringfy()
        {
            return $"{base.Stringfy()}Brightness Level: {brightnessLevel}, Duration: {minutesDuration} minutes and {secondsDuration} seconds.";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" at brightness level: {brightnessLevel} for duration: {minutesDuration} minutes and {secondsDuration} seconds.");
        }
    }
}
