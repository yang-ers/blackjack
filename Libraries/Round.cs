using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Round
    {
        public int NumberOfPlayers { get; set; }
        public int NumberOfDecks { get; set; }
        //public List<Player> Players { get; set; } = null!; 
        public const int Players = 2; //hardcoded to 2 for banker and player1
        public bool RoundActive { get; set; } = true;
        public List<Hand> Hands { get; set; } = null!;
        public Round()
        {
            this.NumberOfPlayers = NumberOfPlayers;
            this.NumberOfDecks = NumberOfDecks;
            this.RoundActive = RoundActive;
            this.Hands = Hands; 
        }

        //inserts 52 cards into deck based on enum functions in card class
        public Deck initializeDeck()
        {
            Deck GameDeck = new Deck();
            Console.WriteLine("Initializing Deck");
            foreach (var cardVal in Enum.GetValues(typeof(Card.CardValues)))
            {
                foreach (var cardSuit in Enum.GetValues(typeof(Card.CardSuits)))
                {
                    var cardV = Convert.ToString(cardVal);
                    var cardS = Convert.ToString(cardSuit);
                    var currentCard = new Card(cardV, cardS);
                    GameDeck.addCardtoDeck(currentCard);

                }
            }

            return GameDeck;
        }


        public void checkWin(Hand BankerHand, Hand PlayerHand)
        {

            if (BankerHand.HandTotal > PlayerHand.HandTotal & BankerHand.checkBust() != true | PlayerHand.checkBust() == true)
            {
                BankerHand.user.TotalAmount += PlayerHand.BetAmount;
                PlayerHand.user.TotalAmount -= PlayerHand.BetAmount;
                Console.WriteLine("Banker wins!");
            }
            else if (BankerHand.HandTotal < PlayerHand.HandTotal | (PlayerHand.checkBust() == false & BankerHand.checkBust() == true))
            {
                BankerHand.user.TotalAmount -= PlayerHand.BetAmount;
                PlayerHand.user.TotalAmount += PlayerHand.BetAmount;
                Console.WriteLine("You win!");
            }

            else if (BankerHand.HandTotal.Equals(PlayerHand.HandTotal))
            {
                BankerHand.user.TotalAmount += BankerHand.BetAmount;
                PlayerHand.user.TotalAmount += PlayerHand.BetAmount;
                Console.WriteLine("Push, no one wins");
            }

        }

        public void endRound()
        {

            this.RoundActive = false;

        }

        //number of slots to be GUI'd each player can place bets over multiple slots, multiple players can place over multiple slots and follow each other

        //public void initializeSlots(int NumberOfPlayers)
        //{
        //    this.Players = new List<Player>();

        //    Player.MakeBanker Banker = new Player.MakeBanker(); 

        //}

    }
}
