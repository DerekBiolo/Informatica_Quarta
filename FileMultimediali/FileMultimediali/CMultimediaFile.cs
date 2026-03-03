using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FileMultimediali
{
    abstract class CMultimediaFile
    {
        protected string FileName;

        public CMultimediaFile(string fileName)
        {
            FileName = fileName;
        }

        public abstract void Play();

        public virtual string Stringfy(){
            return $"File Name: {FileName}, ";
        }

        public string GetFileName(){
            return FileName;
        }
    }
}
