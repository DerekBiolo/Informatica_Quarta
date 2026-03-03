using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Battaglia_Navale_V2
{
    internal class GameManager
    {
        public Player p1;
        public Player p2;
        public Player currentPlayer;
        public FaseGioco FaseAttuale;

        public event GameEventHandler OnGameStateChanged;
        public event EventHandler<string> OnGameLog;

        private SoundManager soundManager;

        public GameManager()
        {
            soundManager = new SoundManager();
            InizializeGame();
        }

        private void InizializeGame()
        {
            p1 = new Player("Giocatore 1", TipoPlayer.Normale);
            p2 = new Player("Giocatore 2", TipoPlayer.Normale);

            p1.Tabella.OnCambioCella += OnCellaStatusCambiato;
            p2.Tabella.OnCambioCella += OnCellaStatusCambiato;

            FaseAttuale = FaseGioco.Posizionamento;
            OnGameStateChanged?.Invoke(FaseAttuale);
            currentPlayer = p1;
        }

        private void OnCellaStatusCambiato(Cella cella)
        {
            string messaggio = "";

            switch (cella.Status)
            {
                case StatusCella.Colpita:
                    messaggio = $"Colpito in posizione ({cella.X},{cella.Y})";
                    soundManager.PlayHitSound();
                    break;
                case StatusCella.Mancata:
                    messaggio = "Acqua!";
                    soundManager.PlayMissSound();
                    break;
                case StatusCella.Affondata:
                    messaggio = $"Nave affondata in posizione ({cella.X},{cella.Y})";
                    break;
            }

            OnGameLog?.Invoke(this, messaggio);
        }

        public void IniziaBattaglia()
        {
            FaseAttuale = FaseGioco.Battaglia;
            currentPlayer = p1;
            OnGameStateChanged?.Invoke(FaseAttuale);
        }

        public void CambiaTurno()
        {
            currentPlayer = (currentPlayer == p1) ? p2 : p1;
        }

        public bool IsGameOver()
        {
            return p1.FlottaRimasta == 0 || p2.FlottaRimasta == 0;
        }
    }
}
