using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class PlayerHand : Hand, IPlayerHand
    {
        public IPlayer Player { get; set; }



        public PlayerHand(IPlayer player, uint betAmount)
        {

            this.HandTotal = beginZero;
            this.Player = player;
            this.BetAmount = betAmount;
            this.CurrentHand = new List<ICard>();
            this.HitTotal = beginZero;

        }

        public void playerHit(IDeck GameDeck)
        {
            ICard card = addCardToHand(GameDeck);
            Console.WriteLine("You receives a " + card.Value + " of " + card.Suit);
        }

        public void dealInitialCardsToPlayer(IDeck GameDeck)
        {
            Console.WriteLine("Dealing hands");

            for (int initialDeal = 0; initialDeal < 2; initialDeal++)
            {
                this.playerHit(GameDeck);
            }

            checkIfBlackjack(this);

        }


    }
}
