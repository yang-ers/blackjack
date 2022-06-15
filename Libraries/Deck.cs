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


        //inserts 52 cards into deck based on enum functions in card class
        public Deck initializeDeck(Deck GameDeck)
        {
            
            foreach (var cardVal in Enum.GetNames(typeof(Enums.CardValues)))
            {
                foreach (var cardSuit in Enum.GetValues(typeof(Enums.CardSuits)))
                {
                    var cardV = Convert.ToString(cardVal);
                    var cardS = Convert.ToString(cardSuit);
                    var currentCard = new Card(cardV, cardS);
                    GameDeck.addCardtoDeck(currentCard);

                }
            }

            Console.WriteLine("Game deck shuffled");

            return GameDeck;
        }


    }
}
