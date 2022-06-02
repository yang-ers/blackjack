using System;
using System.Collections.Generic;
using System.Text;


namespace BlackJack.Libraries
{
    public class Deck
    {

        public List<Card> CurrentDeck { get; set; } = null!;
        public int NumberOfCards { get; set; } = 0;

        public Deck()
        {
            this.CurrentDeck = new List<Card>();
        }

        public void addCardtoDeck(Card currentCard)
        {
            this.CurrentDeck.Add(currentCard);
        }

        public void removeCardfromDeck(Card currentCard)
        {
            this.CurrentDeck.Remove(currentCard);
        }



    }
}
