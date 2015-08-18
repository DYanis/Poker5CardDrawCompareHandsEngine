namespace Poker.Interfaces
{
    using Poker.Enumerations;

    public interface IHandsComparator
    {
        WinningHand CompareHands(IHand firstHand, IHand secondHand);
    }
}
