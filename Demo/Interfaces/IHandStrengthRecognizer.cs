namespace Poker.Interfaces
{
    using Poker.Enumerations;

    public interface IHandStrengthRecognizer
    {
        bool IsValidHand(IHand hand);

        bool IsStraightFlush(IHand hand);

        bool IsFourOfAKind(IHand hand);

        bool IsFullHouse(IHand hand);

        bool IsFlush(IHand hand);

        bool IsStraight(IHand hand);

        bool IsThreeOfAKind(IHand hand);

        bool IsTwoPairs(IHand hand);

        bool IsOnePair(IHand hand);

        bool IsHighCard(IHand hand);

        HandStrength RecognizeHandStrength(IHand hand);
    }
}
