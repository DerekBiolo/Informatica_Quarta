using System;
using System.Collections.Generic;

namespace RouguelikeCardGame
{
    internal class CGame
    {
        private readonly List<string> randomNames = CRandomNames.GetRandomNames();
        private readonly List<CPersonaggio> Deck1;
        private readonly List<CPersonaggio> Deck2;
        private readonly Random random = new Random();

        public int playerCoins;
        public bool gameWon;

        public List<string> GameLog { get; set; }
        private int round;

        public CGame()
        {
            Deck1 = new List<CPersonaggio>();
            Deck2 = new List<CPersonaggio>();
            GameLog = new List<string>();
            round = 1;
            playerCoins = 0;
            gameWon = false;
        }

        public void InitializePlayers()
        {
            Deck1.Clear();
            Deck2.Clear();
            GameLog.Clear();
            round = 1;
            playerCoins = 0;
            gameWon = false;

            for (int i = 0; i < 10; i++)
            {
                Deck1.Add(GenerateRandomCharacter());
                Deck2.Add(GenerateRandomCharacter());
            }

            GameLog.Add("Players initialized. Decks are ready.");
        }

        private CPersonaggio GenerateRandomCharacter()
        {
            int characterType = random.Next(0, 5);
            string name = randomNames[random.Next(randomNames.Count)];

            switch (characterType)
            {
                case 0: return new CAssassin(name);
                case 1: return new CPaladin(name);
                case 2: return new CArcher(name);
                case 3: return new CMage(name);
                case 4:
                default: return new CWarrior(name);
            }
        }

        // Plays a single round (called from Continue button)
        public void PlayNextRound(CPersonaggio player1, CPersonaggio player2)
        {
            gameWon = false;

            if (Deck1.Count == 0 || Deck2.Count == 0)
            {
                string winner = Deck1.Count > 0 ? "Player 1" : "Player 2";
                GameLog.Add("=== GAME OVER ===");
                GameLog.Add($"🏆 Winner: {winner}");
                if (winner == "Player 1")
                    GameWin();
                return;
            }

            GameLog.Add($"--- Round {round} ---");
            GameLog.Add($"{player1.GetName()} (HP: {player1.GetHPString()}, AP: {player1.GetAPString()}) " +
                        $"vs {player2.GetName()} (HP: {player2.GetHPString()}, AP: {player2.GetAPString()})");
            GameLog.Add("");

            while (player1.IsAlive() && player2.IsAlive())
            {
                player1.Attack(player2, this);
                if (player2.IsAlive())
                    player2.Attack(player1, this);
            }

            if (player1.IsAlive())
            {
                GameLog.Add($"{player1.GetName()} wins with {player1.GetHPString()} HP left.");
                Deck2.Remove(player2);
            }
            else
            {
                GameLog.Add($"{player2.GetName()} wins with {player2.GetHPString()} HP left.");
                Deck1.Remove(player1);
            }

            GameLog.Add("");
            round++;
        }


        public void GameWin()
        {
            // calcolo punteggio
            int points = 0;
            points += 100; // vittoria base
            points -= (round - 1) * 10; // penalità turni extra
            if (points < 0) points = 0;

            // bonus per carte sopravvissute
            points += Deck1.Count * 50;

            // conversione punti → monete
            playerCoins = Math.Max(1, points / 100);
            gameWon = true;

            GameLog.Add($"Final Score: {points}  →  Coins Earned: {playerCoins}");
        }

        // ----- GETTERS -----

        public List<string> GetLog() => GameLog;
        public List<CPersonaggio> GetDeck1() => Deck1;
        public List<CPersonaggio> GetDeck2() => Deck2;
        public CPersonaggio GetCurrentPlayer1()
        {
            if (Deck1.Count == 0) return null;
            return Deck1[random.Next(Deck1.Count)];
        }
        public CPersonaggio GetCurrentPlayer2()
        {
            if (Deck2.Count == 0) return null;
            return Deck2[random.Next(Deck2.Count)];
        }
        public int GetRound() => round;
        public bool IsGameOver() => (Deck1.Count == 0 || Deck2.Count == 0);
    }
}
