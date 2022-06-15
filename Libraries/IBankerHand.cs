namespace BlackJack.Libraries
{
    public interface IBankerHand : IHand
    {
        IBanker Banker { get; set; }

        void BankerHit(IDeck GameDeck);
    }
}