using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public abstract class User
    {
        public string Name { get; set; } = null!;
        public double TotalWorth { get; set; }

    }
}
