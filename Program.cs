// See https://aka.ms/new-console-template for more information




using BlackJack.Libraries;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to you always will win Blackjack, where you have the edge against the house");

            Table CurrentTable = new Table();
            CurrentTable.instantiatePlayersToTable();
            IPlayer Player1 = CurrentTable.CurrentPlayers[0]; 

            while (Player1.Continue == true)
            {

                if (Player1.Continue != true)
                {
                    break; 
                }

                Round CurrentRound = new Round();
                CurrentRound.instantiateRound(CurrentTable); 


                Console.WriteLine("Your total chip value is: $" + Player1.TotalWorth);
                Console.WriteLine("Would you like to play another round? (Yes/No)");
                var PlayNextRoundInput = Console.ReadLine(); 
                Player1.continueToPlay(PlayNextRoundInput);

            }

        }
    }
}