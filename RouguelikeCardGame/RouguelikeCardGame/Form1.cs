using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RouguelikeCardGame
{
    public partial class Form1 : Form
    {
        // === Fields ===
        private CGame game;
        private CPersonaggio currentPlayer1;
        private CPersonaggio currentPlayer2;
        private int playerCoins = 0;
        private bool hasTakenCoins = false;

        // === Constructor ===
        public Form1()
        {
            InitializeComponent();
            ApplyTheme();
        }

        // === Form Events ===
        private void Form1_Load(object sender, EventArgs e)
        {
            Lst_GameLogVisualizer.Items.Clear();
            Lst_Deck1Visual.Items.Clear();
            Lst_Deck2Visual.Items.Clear();

            // Enable owner-draw mode for custom highlighting
            Lst_Deck1Visual.DrawMode = DrawMode.OwnerDrawFixed;
            Lst_Deck2Visual.DrawMode = DrawMode.OwnerDrawFixed;

            Lst_Deck1Visual.DrawItem += Lst_Deck_DrawItem;
            Lst_Deck2Visual.DrawItem += Lst_Deck_DrawItem;
        }

        // === Button: Start Game ===
        private void Btn_StartGame_Click(object sender, EventArgs e)
        {
            game = new CGame();
            game.InitializePlayers();

            currentPlayer1 = null;
            currentPlayer2 = null;
            hasTakenCoins = false;

            UpdateGameLog();
            UpdateDeckVisuals();
            UpdateUI();

            MessageBox.Show("Game initialized! Click 'Continue' to start the first round.");

            Btn_StartGame.BackColor = Color.LightGreen;
            Btn_StartGame.Text = "Restart Game";

            Btn_Continue.BackColor = Color.LightBlue;
        }

        // === Button: Continue ===
        private void Btn_Continue_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("Start the game first!");
                return;
            }

            // Store current fighters for highlighting
            currentPlayer1 = game.GetCurrentPlayer1();
            currentPlayer2 = game.GetCurrentPlayer2();

            // Play the round using the selected characters
            game.PlayNextRound(currentPlayer1, currentPlayer2);

            if (game.gameWon && !hasTakenCoins)
            {
                hasTakenCoins = true;
                playerCoins += game.playerCoins;
            }

            UpdateGameLog();
            UpdateDeckVisuals();
            UpdateUI();
        }

        // === UI Updates ===
        private void UpdateUI()
        {
            Lbl_PlayerCoins.Text = $"Coins: {playerCoins}";
            Lbl_Turn.Text = $"Turn: {game.GetRound()}";
        }

        private void UpdateGameLog()
        {
            Lst_GameLogVisualizer.Items.Clear();

            foreach (string log in game.GetLog())
                Lst_GameLogVisualizer.Items.Add(log);

            // Auto-scroll to the last item
            if (Lst_GameLogVisualizer.Items.Count > 0)
                Lst_GameLogVisualizer.TopIndex = Lst_GameLogVisualizer.Items.Count - 1;
        }

        private void ApplyTheme()
        {
            // === Colori base ===
            Color bgColor = Color.FromArgb(30, 30, 40);          // sfondo principale
            Color panelColor = Color.FromArgb(45, 45, 60);       // sfondo pannelli e liste
            Color textColor = Color.Gainsboro;                   // testo principale
            Color accentColor = Color.Gold;                      // accento per titoli e pulsanti
            Color borderColor = Color.FromArgb(70, 70, 90);      // bordi

            // === Form ===
            this.BackColor = bgColor;
            this.ForeColor = textColor;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // === Bottoni ===
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = accentColor;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.BackColor = Color.FromArgb(55, 55, 75);
                    btn.ForeColor = accentColor;
                    btn.Font = new Font("Segoe UI Semibold", 10);
                    btn.Cursor = Cursors.Hand;

                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(70, 70, 95);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(55, 55, 75);
                }

                // === Liste ===
                else if (c is ListBox lst)
                {
                    lst.BackColor = panelColor;
                    lst.ForeColor = textColor;
                    lst.BorderStyle = BorderStyle.FixedSingle;
                    lst.Font = new Font("Consolas", 9);
                }

                // === Label ===
                else if (c is Label lbl)
                {
                    lbl.ForeColor = accentColor;
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }

            // === Game log speciale ===
            Lst_GameLogVisualizer.BackColor = Color.FromArgb(25, 25, 35);
            Lst_GameLogVisualizer.ForeColor = Color.FromArgb(230, 230, 230);
            Lst_GameLogVisualizer.Font = new Font("Consolas", 9);
        }


        private void UpdateDeckVisuals()
        {
            // Deck 1
            Lst_Deck1Visual.Items.Clear();
            foreach (var character in game.GetDeck1())
            {
                string info = $"{character.GetName()} ({character.GetType().Name}) HP: {character.GetHPString()}";
                Lst_Deck1Visual.Items.Add(info);
            }

            // Deck 2
            Lst_Deck2Visual.Items.Clear();
            foreach (var character in game.GetDeck2())
            {
                string info = $"{character.GetName()} ({character.GetType().Name}) HP: {character.GetHPString()}";
                Lst_Deck2Visual.Items.Add(info);
            }
        }

        // === Custom Drawing for Decks ===
        private void Lst_Deck_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var listBox = sender as ListBox;
            e.DrawBackground();

            string itemText = listBox.Items[e.Index].ToString();

            CPersonaggio character = listBox == Lst_Deck1Visual
                ? game.GetDeck1()[e.Index]
                : game.GetDeck2()[e.Index];

            bool isCurrent = character == currentPlayer1 || character == currentPlayer2;
            Brush textBrush = isCurrent ? Brushes.OrangeRed : Brushes.Black;

            e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
    }
}
