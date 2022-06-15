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
        private int NumberOfDecks { get; set; } = 1; //todo 
        public List<IPlayer> CurrentPlayers { get; set; } = null!; 
        public bool RoundActive { get; set; } = true;
        public List<Hand> Hands { get; set; } = null!;
        public Deck GameDeck { get; set; } = null!; 
        public Round()
        {
            this.CurrentPlayers = new List<IPlayer>(); 
            this.NumberOfDecks = NumberOfDecks;
            this.RoundActive = RoundActive;
            this.Hands = new List<Hand>();
            this.GameDeck = GameDeck; 
        }

        public void checkWin(Hand BankerHand, Hand PlayerHand)
        {
            if (PlayerHand.Blackjack == true)
            {
                BankerHand.user.TotalWorth -= PlayerHand.BetAmount * 1.5;
                PlayerHand.user.TotalWorth += PlayerHand.BetAmount * 1.5;
                Console.WriteLine("You hit Blackjack! You win 1.5x!");
            }

            else if (BankerHand.HandTotal > PlayerHand.HandTotal & BankerHand.checkBust() != true | PlayerHand.checkBust() == true)
            {
                BankerHand.user.TotalWorth += PlayerHand.BetAmount;
                PlayerHand.user.TotalWorth -= PlayerHand.BetAmount;
                Console.WriteLine("Banker wins!");
            }
            else if (BankerHand.HandTotal < PlayerHand.HandTotal | (PlayerHand.checkBust() == false & BankerHand.checkBust() == true))
            {
                BankerHand.user.TotalWorth -= PlayerHand.BetAmount;
                PlayerHand.user.TotalWorth += PlayerHand.BetAmount;
                Console.WriteLine("You win!");
            }

            else if (BankerHand.HandTotal.Equals(PlayerHand.HandTotal))
            {
                BankerHand.user.TotalWorth += BankerHand.BetAmount;
                PlayerHand.user.TotalWorth += PlayerHand.BetAmount;
                Console.WriteLine("Push, no one wins");
            }

        }

        public uint checkBet()
        {
            Console.WriteLine("Please enter your bet amount for this hand");

            uint BetAmount;

            var bet = Console.ReadLine();

            if (uint.TryParse(bet, out BetAmount))
            {
                return BetAmount = Convert.ToUInt16(bet);
            }
            else
            {
                while (uint.TryParse(bet, out BetAmount) != true)
                {
                    Console.WriteLine("Please enter your bet amount for this hand in positive numbers only!");
                    bet = Console.ReadLine();
                }

                return BetAmount = Convert.ToUInt16(bet);

            }
        }

        public void instantiateRound(Table CurrentTable)
        {

            IDeck GameDeck = new Deck();
            GameDeck = GameDeck.initializeDeck(GameDeck);

            uint PlayerBet = this.checkBet();

            IBanker Banker = CurrentTable.Banker;
            IPlayer Player1 = CurrentTable.CurrentPlayers[0];

            Hand BankerHand = new Hand(Banker, PlayerBet);
            Hand PlayerHand = new Hand(Player1, PlayerBet);

            this.Hands.Add(BankerHand);
            this.Hands.Add(PlayerHand);
            this.playRound(GameDeck);

        }

        public void playRound(IDeck GameDeck)
        {
            Hand BankerHand = this.Hands[0];
            Hand PlayerHand = this.Hands[1]; //todo hardcode place
            PlayerHand.dealInitialCardsToPlayer(GameDeck);
            BankerHand.BankerHit(GameDeck);
            PlayerHand.showCurrentHand();

            while (PlayerHand.checkBust() is not true & BankerHand.checkBust() is not true)
            {
                Console.WriteLine("Insert the letter 'h' to HIT");

                var hit = Console.ReadLine();

                if (hit == "h")
                {
                    PlayerHand.playerHit(GameDeck);
                    PlayerHand.showCurrentHand();
                }
                else
                {
                    while (BankerHand.HandTotal <= 21
                        & BankerHand.HandTotal <= 17)
                    {
                        BankerHand.BankerHit(GameDeck);
                    }

                    break;
                }

            }

            this.checkWin(BankerHand, PlayerHand);
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
