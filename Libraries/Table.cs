using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Table
    {
        public int Id { get; set; }
        public List<IPlayer> CurrentPlayers { get; set; } = null!;
        public IBanker Banker { get; set; }
        public Table()
        {
            this.Id = Id++; 
            this.CurrentPlayers = new List<IPlayer>();
            this.Banker = new Banker(); 
        }

        public void instantiatePlayersToTable()
        {

            IPlayer Player1 = new Player();

            Console.WriteLine("Please enter your name");

            Player1.Name = Console.ReadLine();
            Console.WriteLine("Hello, " + Player1.Name);

            this.CurrentPlayers.Add(Player1);
        }
    }
}
