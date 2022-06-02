using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }

        public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }

        public enum CardValues
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 10,
            Queen = 10,
            King = 10,
            Ace = 1 | 11

        }

        public enum CardSuits
        {
            Hearts,
            Spades,
            Clovers,
            Diamonds
        }




    }
}
