using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battaglia_Navale_V2
{
    public class Cella
    {
        public int X;
        public int Y;
        public StatusCella Status;
        public ANave Nave;

        public event CellaEventHandler OnCambioStato;

        public Cella(int x, int y)
        {
            X = x;
            Y = y;
            Status = StatusCella.Vuota;
            Nave = null;
        }

        public void PosizionaNave(ANave nave)
        {
            Nave = nave;
            Status = StatusCella.Nave;
            OnCambioStato?.Invoke(this);
        }

        public bool Attacca()
        {

            if (Status == StatusCella.Nave && Nave == null)
            {
                Nave.Colpita();
                Status = StatusCella.Colpita;
                OnCambioStato?.Invoke(this);
                return true;
            }
            else if (Status == StatusCella.Vuota)
            {
                Status = StatusCella.Mancata;
                OnCambioStato?.Invoke(this);
            }
            return false;
        }

        public void SegnaAffondata()
        {
            Status = StatusCella.Affondata;
            OnCambioStato?.Invoke(this);
        }
    }
}
