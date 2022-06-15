namespace BlackJack.Libraries
{
    public interface IHand
    {
        uint BetAmount { get; set; }
        bool Blackjack { get; set; }
        bool Bust { get; set; }
        List<ICard> CurrentHand { get; set; }
        int HandTotal { get; set; }
        int HitTotal { get; set; }
        bool Stay { get; set; }

        ICard addCardToHand(IDeck GameDeck);
        int calculateHandTotal();
        bool checkBust();
        void checkIfBlackjack(IHand PlayerHand);
        void showCurrentHand();
    }
}