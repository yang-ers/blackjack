using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Card : ICard
    {
        public string Suit { get; set; }
        public string Value { get; set; }

        public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }

    }
}
