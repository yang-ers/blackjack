// See https://aka.ms/new-console-template for more information




using BlackJack.Libraries;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to you always will win Blackjack, where you have the edge against the house");
            Console.WriteLine("Please enter your name");
            
            Player Player1 = new Player();
            Banker Banker = new Banker();
            Player1.Name = Console.ReadLine();
            Console.WriteLine("Hello, " + Player1.Name);

            while (Player1.Continue == true)
            {

                if (Player1.Continue != true)
                {
                    break; 
                }

                Round CurrentRound = new Round();

                Console.WriteLine("Please enter your bet amount for this hand");
                String bet = "";
                uint BetAmount;

                bet = Console.ReadLine();

                if (uint.TryParse(bet, out BetAmount))
                {
                    BetAmount = Convert.ToUInt16(bet);
                } 
                else
                {
                    while (uint.TryParse(bet, out BetAmount) != true)
                    {
                        Console.WriteLine("Please enter your bet amount for this hand in positive numbers only!");
                        bet = Console.ReadLine();
                    }
                }

                var BankerHand = new Hand(Banker, BetAmount);
                var PlayerHand = new Hand(Player1, BetAmount);

                Deck GameDeck = CurrentRound.initializeDeck();

                Console.WriteLine("Game deck initialized");
                Console.WriteLine("Dealing hands");

                //deals two cards to each person including banker and remove from current deck
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

                CurrentRound.checkWin(BankerHand, PlayerHand);
                Console.WriteLine("Your total chip value is: $" + Player1.TotalWorth);
                Console.WriteLine("Would you like to play another round? (Yes/No)");
                var PlayNextRound = Console.ReadLine(); 
                Player1.ContinueToPlay(PlayNextRound);

            }











        }
    }
}