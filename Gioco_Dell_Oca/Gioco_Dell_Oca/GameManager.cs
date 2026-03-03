using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gioco_Dell_Oca
{
    public enum TipologiaCasella
    {
        Normale,
        Oca,
        Ponte,
        Casa,
        Prigione,
        Labirinto,
        Scheletro,
        Arrivo
    }
    public class GameManager
    {
        public static GameManager Instance;
        public int Dice1Value = 1;
        public int Dice2Value = 1;
        private Form1 form;
        public Player CurrentPlayer;
        public Label lblPunteggio;

        public Dictionary<int, TipologiaCasella> CaselleSpeciali = new Dictionary<int, TipologiaCasella>()
        {
            {5, TipologiaCasella.Oca},
            {9, TipologiaCasella.Oca},
            {17, TipologiaCasella.Oca},
            {27, TipologiaCasella.Oca},
            {37, TipologiaCasella.Oca},
            {45, TipologiaCasella.Oca},
            {55, TipologiaCasella.Oca},
            {6, TipologiaCasella.Ponte},
            {19, TipologiaCasella.Casa},
            {31, TipologiaCasella.Prigione},
            {42, TipologiaCasella.Labirinto},
            {58, TipologiaCasella.Scheletro},
            {63, TipologiaCasella.Arrivo}
        };

        public Tabella Tabella;

        public GameManager()
        {
            Tabella = new Tabella();
            Instance = this;
            form = Form1.Instance;
        }

        public void InizializzaGioco()
        {
            Tabella.AddCaselle(CaselleSpeciali);
            Tabella.InizializzaForm();
            lblPunteggio = Tabella.lblPunteggio;
        }

        public void RollDices()
        {

            Player currentPlayer = form.IsPlayer1Turn ? form.Player1 : form.Player2;
            CurrentPlayer = currentPlayer;

            //controllo se il giocatore è bloccato
            if(currentPlayer.TurniFermi > 0)
            {

                currentPlayer.TurniFermi--;
                MessageBox.Show($"{currentPlayer.Name} è bloccato per altri {currentPlayer.TurniFermi + 1} turni!", "Turno Saltato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.IsPlayer1Turn = !form.IsPlayer1Turn;
                lblPunteggio.Text = form.IsPlayer1Turn ? $"{form.Player1.Name}'s Turn" : $"{form.Player2.Name}'s Turn";
                return;
            }
            //animazione daddo
            AnimazioneDado();

            Random r = new Random();
            Dice1Value = r.Next(1, 7);
            Dice2Value = r.Next(1, 7);
            int total = Dice1Value + Dice2Value;

            // alla fine se il player sfora, non lo faccio vincere ma lo muovo da fine a quanto gli manca - 63
            int currentPlayerCell = currentPlayer.CurrentCellIndex;
            int destination = currentPlayerCell + total;

            // Rimbalzo finale
            if (destination > 63)
            {
                int overflow = destination - 63; // quanto hai sforato
                destination = 63 - overflow;     // rimbalzo indietro
            }

            total = destination - currentPlayerCell;


            // Aggiorna le immagini dei dadi
            Panel dice1 = form.Controls.OfType<Panel>().FirstOrDefault(p => (string)p.Tag == "Dice1");
            Panel dice2 = form.Controls.OfType<Panel>().FirstOrDefault(p => (string)p.Tag == "Dice2");

            try { dice1.BackgroundImage = Image.FromFile($"Dice{Dice1Value}.png"); }
            catch { dice1.BackgroundImage = null; dice1.BackColor = Color.Red; }

            try { dice2.BackgroundImage = Image.FromFile($"Dice{Dice2Value}.png"); }
            catch { dice2.BackgroundImage = null; dice2.BackColor = Color.Red; }

            // Calcola la nuova posizione
            int currentCellNumber = currentPlayer.CurrentCellIndex;

            int newCellNumber = currentCellNumber + total;
            currentPlayer.CasellaAttuale = newCellNumber;

            // Gestisci il superamento dell'ultima casella
            int maxCellNumber = 63;
            if (newCellNumber > maxCellNumber)
            {
                newCellNumber = maxCellNumber;
            }

            // Muovi il giocatore
            MuoviGiocatoreACasella(currentPlayer, newCellNumber);
            // Cambia turno (verrà cambiato anche negli eventi se necessario)
            form.IsPlayer1Turn = !form.IsPlayer1Turn;
            lblPunteggio.Text = form.IsPlayer1Turn ? $"{form.Player1.Name}'s Turn" : $"{form.Player2.Name}'s Turn";
        }

        private void AnimazioneDado()
        {
            Panel dice1 = form.Controls.OfType<Panel>().FirstOrDefault(p => (string)p.Tag == "Dice1");
            Panel dice2 = form.Controls.OfType<Panel>().FirstOrDefault(p => (string)p.Tag == "Dice2");
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int val1 = r.Next(1, 7);
                int val2 = r.Next(1, 7);
                try { dice1.BackgroundImage = Image.FromFile($"Dice{val1}.png"); }
                catch { dice1.BackgroundImage = null; dice1.BackColor = Color.Red; }
                try { dice2.BackgroundImage = Image.FromFile($"Dice{val2}.png"); }
                catch { dice2.BackgroundImage = null; dice2.BackColor = Color.Red; }
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);
            }
        }

        // Metodo pubblico per muovere un giocatore a una casella specifica
        public void MuoviGiocatoreACasella(Player player, int targetCellNumber)
        {
            if (targetCellNumber < 1) targetCellNumber = 1;
            if (targetCellNumber > 63) targetCellNumber = 63;

            // movimento solo logico senza effetti
            for (int i = player.CurrentCellIndex + 1; i <= targetCellNumber; i++)
            {
                Casella casellaPassata = Tabella.Caselle.FirstOrDefault(c => c.Numero == i);
                if (casellaPassata != null)
                {
                    player.SetPosition(new Point(
                        casellaPassata.Panel.Location.X + (casellaPassata.Panel.Width - player.PedinaPanel.Width) / 2,
                        casellaPassata.Panel.Location.Y + (casellaPassata.Panel.Height - player.PedinaPanel.Height) / 2
                    ));

                    Application.DoEvents();
                    System.Threading.Thread.Sleep(150); // effetto di movimento se vuoi
                }
            }

            player.CurrentCellIndex = targetCellNumber;

            Casella targetCasella = Tabella.Caselle.FirstOrDefault(c => c.Numero == targetCellNumber);
            if (targetCasella != null)
            {
                player.SetPosition(new Point(
                    targetCasella.Panel.Location.X + (targetCasella.Panel.Width - player.PedinaPanel.Width) / 2,
                    targetCasella.Panel.Location.Y + (targetCasella.Panel.Height - player.PedinaPanel.Height) / 2
                ));

                //nell'ultima scateno evento
                targetCasella.PlayerLands(player);
            }
        }

        // Metodo chiamato quando un giocatore vince
        public void FinePartita(Player vincitore)
        {
            DialogResult result = MessageBox.Show(
                $"🏆 {vincitore.Name} ha vinto!\n\nVuoi giocare ancora?",
                "FINE PARTITA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Riavvia il gioco
                Application.Restart();
            }
            else
            {
                // Chiudi l'applicazione
                Application.Exit();
            }
        }
    }
}