namespace Poker.Interfaces
{
    using Poker.Enumerations;

    public interface ICard
    {
        CardFace Face { get; }

        CardSuit Suit { get; }

        string ToString();
    }
}
