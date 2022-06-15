namespace BlackJack.Libraries
{
    public interface IDeck
    {
        List<ICard> CurrentDeck { get; set; }
        int NumberOfCards { get; set; }

        void addCardtoDeck(ICard currentCard);
        IDeck initializeDeck(IDeck GameDeck);
        void removeCardfromDeck(ICard currentCard);
    }
}