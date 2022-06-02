using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Player
    {
        public string Name { get; set; } = null!;
        public double TotalAmount { get; set; } // total amount of chips they have

        private double initialAmount = 0;

        public Player()
        {
            Name = Name;
            TotalAmount = initialAmount;
        }


        internal class MakeBanker : Player
        {
            private double bankerAmount = 999999;
            public MakeBanker()
            {
                Name = Name;
                TotalAmount = bankerAmount;

            }
        }
    }
}
