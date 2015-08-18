namespace Poker
{
    using System;
    using System.Linq;

    using Poker.Enumerations;
    using Poker.Interfaces;
    
    public class HandStrengthRecognizer : IHandStrengthRecognizer
    {
        public bool IsValidHand(IHand hand)
        {
            bool isCorrectHand = true;

            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (hand.Cards[i].Equals(hand.Cards[j]))
                    {
                        isCorrectHand = false;
                    }
                }
            }

            return isCorrectHand;
        }

        public bool IsStraightFlush(IHand hand)
        {
            return this.IsStraight(hand) && this.IsFlush(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            return this.IsRightTimesOfRepeat(hand, 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            bool haveThreeOfAKind = this.IsRightTimesOfRepeat(hand, 3);
            bool haveOtherOnePair = false;

            int counter = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        counter++;
                    }
                }

                if (counter == 2)
                {
                    haveOtherOnePair = true;
                    break;
                }

                counter = 0;
            }

            return haveThreeOfAKind && haveOtherOnePair;
        }

        public bool IsFlush(IHand hand)
        {
            var suit = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            var sortedHand = hand.Cards.OrderBy(x => x.Face).ToArray();

            for (int i = 0; i < 4; i++)
            {
                // check for straight Ace to Five
                if (i == 3 && sortedHand[0].Face == CardFace.Two && sortedHand[4].Face == CardFace.Ace)
                {
                    return true;
                }

                if (sortedHand[i].Face + 1 != sortedHand[i + 1].Face)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            return this.IsRightTimesOfRepeat(hand, 3);
        }

        public bool IsTwoPairs(IHand hand)
        {
            int counter = 0;
            int pairsCounter = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        counter++;
                    }

                    if (counter == 2)
                    {
                        pairsCounter++;
                        counter = 0;
                    }
                }
            }

            if (pairsCounter / 2 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            return this.IsRightTimesOfRepeat(hand, 2);
        }

        public bool IsHighCard(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var currentCard = hand.Cards[i];

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (hand.Cards[j].Face == currentCard.Face)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public HandStrength RecognizeHandStrength(IHand hand)
        {
            HandStrength handStrength = HandStrength.HighCard;

            if (!IsValidHand(hand))
            {
                throw new ArgumentException("this hand is not valid: " + hand.ToString());
            }

            if (IsStraightFlush(hand))
            {
                handStrength = HandStrength.StraightFlush;
                return handStrength;
            }

            if (IsFourOfAKind(hand))
            {
                handStrength = HandStrength.FourOfAKind;
                return handStrength;
            }

            if (IsFullHouse(hand))
            {
                handStrength = HandStrength.FullHouse;
                return handStrength;
            }

            if (IsFlush(hand))
            {
                handStrength = HandStrength.Flush;
                return handStrength;
            }

            if (IsStraight(hand))
            {
                handStrength = HandStrength.Straight;
                return handStrength;
            }

            if (IsThreeOfAKind(hand))
            {
                handStrength = HandStrength.ThreeOfAKind;
                return handStrength;
            }

            if (IsTwoPairs(hand))
            {
                handStrength = HandStrength.TwoPairs;
                return handStrength;
            }

            if (IsOnePair(hand))
            {
                handStrength = HandStrength.OnePair;
                return handStrength;
            }

            return handStrength;
        }

        private bool IsRightTimesOfRepeat(IHand hand, int times)
        {
            int couter = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        couter++;
                    }
                }

                if (couter == times)
                {
                    return true;
                }

                couter = 0;
            }

            return false;
        }   
    }
}
