using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Player : User, IPlayer
    {

        private double InitialWorth = 0;
        public bool Continue { get; set; }

        private bool DefaultContinue = true;
        public Player()
        {
            this.Name = Name;
            this.TotalWorth = InitialWorth;
            this.Continue = DefaultContinue;

        }
        public void continueToPlay(string input)
        {
            if (input.ToLower() == "yes")
            {
                this.Continue = true;
            }

            else
            {
                this.Continue = false;
                Console.WriteLine("Game Finished");
                Environment.Exit(0);
            }
        }

    }

}
