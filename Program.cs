﻿// See https://aka.ms/new-console-template for more information




using BlackJack.Libraries;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to you always will win Blackjack, where you have the edge against the house");

            Console.WriteLine("Please enter your name");

            var Player1 = new Player();
            var Banker = new Player.MakeBanker();
            Player1.Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Hello, " + Player1.Name);

            var Continue = true; 

            while (Continue != false)
            {

                if (Continue != true)
                {
                    break; 
                }

                Round CurrentRound = new Round();

                Console.WriteLine("Please enter your bet amount for this hand");
                int BetAmount = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine("Your total chip value is: " + Player1.TotalAmount);
                CurrentRound.endRound();

            }











        }
    }
}