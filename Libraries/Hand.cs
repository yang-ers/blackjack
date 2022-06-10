using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Hand 
    {
        public int HandTotal { get; set; }
        public int HitTotal { get; set; }
        public User user { get; set; }
        public uint BetAmount {get; set; }
        public List<Card> CurrentHand { get; set; } = null!;
        public bool Bust { get; set; } = false;
        public bool Stay { get; set; } = false;
        public bool Blackjack { get; set; }

        private static int beginZero = 0;


        public Hand(User user, uint betAmount)
        {

            this.HandTotal = beginZero;
            this.user = user;
            this.BetAmount = betAmount;
            this.CurrentHand = new List<Card>();
            this.HitTotal = beginZero;

        }


        protected bool checkAces(Card card)
        {
            if (card.Value == "Ace")
            {
                return true;
            }
            else return false; 
             
        }


        public int calculateHandTotal()
        {

            int HandValue = 0;
            int NumberOfAces = 0; 

            foreach (Card card in this.CurrentHand)
            {

                if (checkAces(card))
                {
                    NumberOfAces++;
                }

                int CardValue = Convert.ToInt32(Enum.Parse(typeof(Card.CardValues), card.Value));
                HandValue += CardValue;

            }

            if (HandValue > 21)
            {
                HandValue -= NumberOfAces * 10; 
            }

            this.HandTotal = HandValue; 
            return this.HandTotal;


        }


        public Card addCardToHand(Deck GameDeck)
        {
            var rand = new Random();
            int randIndex = rand.Next(GameDeck.CurrentDeck.Count);

            Card randomCard = GameDeck.CurrentDeck[randIndex];
            randomCard = new Card(randomCard.Value, randomCard.Suit);

            this.CurrentHand?.Add(randomCard);
            GameDeck.CurrentDeck.RemoveAt(randIndex);
            this.HitTotal++;
            calculateHandTotal();

            return randomCard; 
        }


        public void showCurrentHand()
        {

            foreach (Card card in this.CurrentHand)
            {
                Console.WriteLine("You have a: " + card.Value + " of " + card.Suit);
            }
            Console.WriteLine("The total value of your hand is: " + this.HandTotal);
        }

         
        public bool checkBust()
        {

            return this.HandTotal > 21 ? true : false;
        }


        public void playerHit(Deck GameDeck)
        {

            Card card = addCardToHand(GameDeck);
            Console.WriteLine("You receives a " + card.Value + " of " + card.Suit);
        }


        public void BankerHit(Deck GameDeck)
        {
            Card card = addCardToHand(GameDeck);
            Console.WriteLine("Banker receives a " + card.Value + " of " + card.Suit);
            Console.WriteLine("Banker total = " + this.HandTotal); 
        }


        public void dealInitialCardsToPlayer(Deck GameDeck)
        {
            Console.WriteLine("Dealing hands");

            for (int initialDeal = 0; initialDeal < 2; initialDeal++)
            {
                this.playerHit(GameDeck);
            }

            checkIfBlackjack(this); 

        }

        //check if the value of the two initial cards dealt to player equates to 21
        public void checkIfBlackjack (Hand PlayerHand)
        {
            int HandTotal = 0; 
            foreach (Card card in PlayerHand.CurrentHand)
            {
                HandTotal += Convert.ToInt16(Enum.Parse(typeof(Card.CardValues), card.Value)); 
            }

            if (HandTotal == 21 & this.CurrentHand.Count == 2)
            {
                this.Blackjack = true; 
            }
        }

    }
}
