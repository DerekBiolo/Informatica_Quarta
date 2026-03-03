using System;
using System.Windows.Forms;

namespace Gioco_Dell_Oca
{

    public class CasellaEventArgs : EventArgs //classe che uso per le info dell'evento per la cella speciale
    {
        public Player Giocatore { get; set; }
        public int NumeroCasella { get; set; }
        public TipologiaCasella Tipologia { get; set; }

        public CasellaEventArgs(Player giocatore, int numero, TipologiaCasella tipo)
        {
            Giocatore = giocatore;
            NumeroCasella = numero;
            Tipologia = tipo;
        }
    }

    public class Casella
    {
        public int Numero;
        public string FiguraPath;
        public Panel Panel;
        public TipologiaCasella Tipologia;

        //evento che gestisce le interazioni con la casella
        public event EventHandler<CasellaEventArgs> OnPlayerLanded;

        public Casella(int n, string f)
        {
            Numero = n;
            FiguraPath = f;
            Panel = null;
            Tipologia = TipologiaCasella.Normale;
        }

        public Casella(int n, string f, TipologiaCasella tipo)
        {
            Numero = n;
            FiguraPath = f;
            Panel = null;
            Tipologia = tipo;
        }

        public void PlayerLands(Player giocatore)
        {
            OnPlayerLanded?.Invoke(this, new CasellaEventArgs(giocatore, Numero, Tipologia));
        }
    }
}