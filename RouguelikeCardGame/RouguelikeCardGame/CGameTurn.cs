using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal class CGameTurn
    {
        protected CPersonaggio Player1;
        protected CPersonaggio Player2;
        private List<string> log;
        public CGameTurn(CPersonaggio player1, CPersonaggio player2)
        {
            Player1 = player1;
            Player2 = player2;
            log = new List<string>();
        }

        //public List<string> Combat()
        //{
        //    int turn = 1;
        //    while (Player1.IsAlive() && Player2.IsAlive())
        //    {
        //        log.Add($"--- Turn {turn} ---");

        //        //player one attacks player two
        //        Player1.Attack(Player2);
        //        log.Add($"{Player1.GetName()} attacked {Player2.GetName()} dealing :{Player1.GetAPString()} Damage. Health left for {Player2.GetName()} : {Player2.GetHPString()} HP");

        //        if (!Player2.IsAlive())
        //        {
        //            break;
        //        }

        //        Player2.Attack(Player1);
        //        log.Add($"{Player2.GetName()} attacked {Player1.GetName()} dealing :{Player2.GetAPString()} Damage. Health left for {Player1.GetName()} : {Player1.GetHPString()} HP");
        //        turn++;
        //    }

        //    string winner = Player1.IsAlive() ? Player1.GetName() : Player2.GetName();
        //    log.Add($"The winner is: {winner}, \n Winner winner chicken dinner");
        //    return log;
        //}
    }
}
