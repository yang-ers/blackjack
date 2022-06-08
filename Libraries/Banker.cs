using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    internal class Banker : User
    {

        private double InitialAmount = 99999; 

        public Banker()
        {
            this.Name = "Banker"; 
            this.TotalWorth = InitialAmount;
        }
    }
}
