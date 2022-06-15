using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Banker : User, IBanker
    {
        public new string Name { get; set; } = "Banker";
        private double InitialAmount { get; set; } = 99999;

        public Banker()
        {
            this.TotalWorth = InitialAmount;
        }

    }
}
