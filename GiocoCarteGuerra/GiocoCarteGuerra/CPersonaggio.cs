using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoCarteGuerra
{
    internal class CPersonaggio
    {
        protected string Nome;
        protected int PuntiVita;

        public CPersonaggio(string nome, int puntiVita)
        {
            Nome = nome;
            PuntiVita = puntiVita;
        }

        public string GetNome()
        {
            return Nome;
        }

        public virtual int Attacca()
        {
            return 5;
        }

        public void SubisciDanno(int danno)
        {
            PuntiVita -= danno;
        }

        public bool IsLiving()
        {
            return PuntiVita > 0;
        }
    }
}
