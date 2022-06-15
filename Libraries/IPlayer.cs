namespace BlackJack.Libraries
{
    public interface IPlayer : IUser
    {
        bool Continue { get; set; }
        void continueToPlay(string input);
    }
}