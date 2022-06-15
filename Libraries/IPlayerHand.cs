namespace BlackJack.Libraries
{
    public interface IPlayerHand : IHand
    {
        IPlayer Player { get; set; }

        void dealInitialCardsToPlayer(IDeck GameDeck);
        void playerHit(IDeck GameDeck);
    }
}