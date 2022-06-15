using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class BankerHand : Hand, IBankerHand
    {
        public IBanker Banker { get; set; } 

        public BankerHand()
        {

            this.HandTotal = beginZero;
            this.Banker = new Banker(); 
            this.CurrentHand = new List<ICard>();
            this.HitTotal = beginZero;

        }
        public void BankerHit(IDeck GameDeck)
        {
            ICard card = addCardToHand(GameDeck);
            Console.WriteLine("Banker receives a " + card.Value + " of " + card.Suit);
            Console.WriteLine("Banker total = " + this.HandTotal);
        }

    }
}
