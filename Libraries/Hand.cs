using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public abstract class Hand : IHand
    {
        public int HandTotal { get; set; }
        public int HitTotal { get; set; }
        public uint BetAmount { get; set; }
        public List<ICard> CurrentHand { get; set; } = null!; 
        public bool Bust { get; set; } = false;
        public bool Stay { get; set; } = false;
        public bool Blackjack { get; set; }

        protected int beginZero = 0;
        protected bool checkAces(ICard card)
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

            foreach (ICard card in this.CurrentHand)
            {

                if (checkAces(card))
                {
                    NumberOfAces++;
                }

                int CardValue = Convert.ToInt32(Enum.Parse(typeof(Enums.CardValues), card.Value));
                HandValue += CardValue;

            }

            if (HandValue > 21)
            {
                HandValue -= NumberOfAces * 10;
            }

            this.HandTotal = HandValue;
            return this.HandTotal;


        }


        public ICard addCardToHand(IDeck GameDeck)
        {
            var rand = new Random();
            int randIndex = rand.Next(GameDeck.CurrentDeck.Count);

            ICard randomCard = GameDeck.CurrentDeck[randIndex];
            randomCard = new Card(randomCard.Value, randomCard.Suit);

            this.CurrentHand?.Add(randomCard);
            GameDeck.CurrentDeck.RemoveAt(randIndex);
            this.HitTotal++;
            calculateHandTotal();

            return randomCard;
        }


        public void showCurrentHand()
        {

            foreach (ICard card in this.CurrentHand)
            {
                Console.WriteLine("You have a: " + card.Value + " of " + card.Suit);
            }
            Console.WriteLine("The total value of your hand is: " + this.HandTotal);
        }


        public bool checkBust()
        {

            return this.HandTotal > 21 ? true : false;
        }


        //check if the value of the two initial cards dealt to player equates to 21
        public void checkIfBlackjack(IHand hand)
        {
            int HandTotal = 0;
            foreach (ICard card in hand.CurrentHand)
            {
                HandTotal += Convert.ToInt16(Enum.Parse(typeof(Enums.CardValues), card.Value));
            }

            if (HandTotal == 21 & this.CurrentHand.Count == 2)
            {
                this.Blackjack = true;
            }
        }

    }
}
