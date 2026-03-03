using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediali
{
    internal class CImmagine : CMultimediaFile , IBrightness
    {
        public int brigtness = 0;

        public CImmagine(string fileName, int brigtness) : base(fileName)
        {
            this.brigtness = brigtness;
        }

        public void IncreaseBrigtness()
        {
            if (brigtness < 100)
            {
                brigtness += 10;
            }
        }

        public void DecreaseBrightness()
        {
            if (brigtness > 0)
            {
                brigtness -= 10;
            }
        }

        public override string Stringfy()
        {
            return $"{base.Stringfy()}Brightness Level: {brigtness}.";
        }

        public override void Play() { }

    }
}
