namespace Poker
{
    using System;  
    using System.Collections.Generic;
    using System.Linq;

    using Poker.Enumerations;
    using Poker.Interfaces;

    public class HandsComparator : IHandsComparator
    {
        public WinningHand CompareHands(IHand firstHand, IHand secondHand)
        {
            var handStrengthRecognizer = new HandStrengthRecognizer();
            HandStrength firstHandStrenght = handStrengthRecognizer.RecognizeHandStrength(firstHand);
            HandStrength secondHandStrength = handStrengthRecognizer.RecognizeHandStrength(secondHand);

            if (firstHandStrenght == secondHandStrength)
            {
                switch (firstHandStrenght)
                {
                    case HandStrength.HighCard:
                        {
                            return this.FindWinningHandByKickers(firstHand.Cards.ToList(), secondHand.Cards.ToList());
                        }

                    case HandStrength.OnePair:
                        {
                            return this.CompareOnePairHands(firstHand, secondHand);
                        }

                    case HandStrength.TwoPairs:
                        {
                            return this.CompareTwoPairsHands(firstHand, secondHand);
                        }

                    case HandStrength.ThreeOfAKind:
                        {
                            return this.CompareThreeOfAKindHands(firstHand, secondHand);
                        }

                    case HandStrength.Straight:
                        {
                            return this.CompareStraightHands(firstHand, secondHand);
                        }

                    case HandStrength.Flush:
                        {
                            return this.CompareFlushHands(firstHand, secondHand);
                        }

                    case HandStrength.FullHouse:
                        {
                            return this.CompareFullHouseHands(firstHand, secondHand);
                        }

                    case HandStrength.FourOfAKind:
                        {
                            return this.CompareFourOfAKindHands(firstHand, secondHand);
                        }

                    case HandStrength.StraightFlush:
                        {
                            return this.CompareStraightFlushHands(firstHand, secondHand);
                        }

                    default:
                        {
                            throw new ArgumentException("Invalid hand strength!");
                        }
                }
            }

            return firstHandStrenght > secondHandStrength ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
        }

        private WinningHand CompareStraightFlushHands(IHand firstHand, IHand secondHand)
        {
            WinningHand straightWinningHand = this.CompareStraightHands(firstHand, secondHand);

            if (straightWinningHand != WinningHand.HandsAreEqueal)
            {
                return straightWinningHand;
            }
            else
            {
                return firstHand.Cards[0].Suit > secondHand.Cards[0].Suit ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
        }

        private WinningHand CompareOnePairHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandKickers = new List<ICard>();
            List<ICard> secondHandKickers = new List<ICard>();
            ICard firstHandPairCard = firstHand.Cards[0]; // default value
            ICard secondHandPairCard = firstHand.Cards[0]; // default value

            for (int i = 0; i < 5; i++)
            {
                if (firstHand.Cards.Count(x => x.Face == firstHand.Cards[i].Face) == 2)
                {
                    firstHandPairCard = firstHand.Cards[i];
                    continue;
                }

                firstHandKickers.Add(firstHand.Cards[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                if (secondHand.Cards.Count(x => x.Face == secondHand.Cards[i].Face) == 2)
                {
                    secondHandPairCard = secondHand.Cards[i];
                    continue;
                }

                secondHandKickers.Add(secondHand.Cards[i]);
            }

            if (firstHandPairCard.Face != secondHandPairCard.Face)
            {
                ////return by pair strength
                return firstHandPairCard.Face > secondHandPairCard.Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else
            {
                ////return by kickers strength
                return this.FindWinningHandByKickers(firstHandKickers, secondHandKickers);
            }
        }

        private WinningHand CompareFlushHands(IHand firstHand, IHand secondHand)
        {
            var firstHandOrderedCards = firstHand.Cards.OrderByDescending(x => x.Face).ToList();
            var secondHandOrderedCards = secondHand.Cards.OrderByDescending(x => x.Face).ToList();

            if (firstHandOrderedCards[0].Face != secondHandOrderedCards[0].Face)
            {
                return firstHandOrderedCards[0].Face > secondHandOrderedCards[0].Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else
            {
                return firstHandOrderedCards[0].Suit > secondHandOrderedCards[0].Suit ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
        }

        private WinningHand CompareTwoPairsHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandKickers = new List<ICard>();
            List<ICard> secondHandKickers = new List<ICard>();
            ICard firstHandFirstPairCard = firstHand.Cards[0]; // default value
            ICard firstHandSecondPairCard = firstHand.Cards[0]; // default value
            ICard secondHandFirstPairCard = firstHand.Cards[0]; // default value                           
            ICard secondHandSecondPairCard = firstHand.Cards[0]; // default value

            bool isTaken = false;
            for (int i = 0; i < 5; i++)
            {
                if (firstHand.Cards.Count(x => x.Face == firstHand.Cards[i].Face) == 2)
                {
                    if (!isTaken)
                    {
                        firstHandFirstPairCard = firstHand.Cards[i];
                        isTaken = true;
                    }

                    if (firstHand.Cards[i].Face != firstHandFirstPairCard.Face)
                    {
                        firstHandSecondPairCard = firstHand.Cards[i];
                    }

                    continue;
                }

                firstHandKickers.Add(firstHand.Cards[i]);
            }

            isTaken = false;
            for (int i = 0; i < 5; i++)
            {
                if (secondHand.Cards.Count(x => x.Face == secondHand.Cards[i].Face) == 2)
                {
                    if (!isTaken)
                    {
                        secondHandFirstPairCard = secondHand.Cards[i];
                        isTaken = true;
                    }

                    if (secondHand.Cards[i].Face != secondHandFirstPairCard.Face)
                    {
                        secondHandSecondPairCard = secondHand.Cards[i];
                    }

                    continue;
                }

                secondHandKickers.Add(secondHand.Cards[i]);
            }

            if (firstHandFirstPairCard.Face != secondHandFirstPairCard.Face)
            {
                ////return by first pair strength
                return firstHandFirstPairCard.Face > secondHandFirstPairCard.Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else if (firstHandSecondPairCard.Face != secondHandSecondPairCard.Face)
            {
                ////return by second pair strength
                return firstHandSecondPairCard.Face > secondHandSecondPairCard.Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else
            {
                ////return by kickers strength
                return this.FindWinningHandByKickers(firstHandKickers, secondHandKickers);
            }
        }

        private WinningHand CompareThreeOfAKindHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandKickers = new List<ICard>();
            List<ICard> secondHandKickers = new List<ICard>();
            ICard firstHandThreeOfAKindCard = firstHand.Cards[0]; // default value
            ICard secondHandThreeOfAKindCard = firstHand.Cards[0]; // default value

            for (int i = 0; i < 5; i++)
            {
                if (firstHand.Cards.Count(x => x.Face == firstHand.Cards[i].Face) == 3)
                {
                    firstHandThreeOfAKindCard = firstHand.Cards[i];
                    continue;
                }

                firstHandKickers.Add(firstHand.Cards[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                if (secondHand.Cards.Count(x => x.Face == secondHand.Cards[i].Face) == 3)
                {
                    secondHandThreeOfAKindCard = secondHand.Cards[i];
                    continue;
                }

                secondHandKickers.Add(secondHand.Cards[i]);
            }

            if (firstHandThreeOfAKindCard.Face != secondHandThreeOfAKindCard.Face)
            {
                ////return by pair strength
                return firstHandThreeOfAKindCard.Face > secondHandThreeOfAKindCard.Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else
            {
                ////return by kickers strength
                return this.FindWinningHandByKickers(firstHandKickers, secondHandKickers);
            }
        }

        private WinningHand CompareFourOfAKindHands(IHand firstHand, IHand secondHand)
        {
            ICard firstHandFourOfAKindCard = firstHand.Cards[0]; // default value
            ICard secondHandFourOfAKindCard = secondHand.Cards[0]; // default value

            for (int i = 0; i < 5; i++)
            {
                if (firstHand.Cards.Count(x => x.Face == firstHand.Cards[i].Face) == 4)
                {
                    firstHandFourOfAKindCard = firstHand.Cards[i];
                    break;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (secondHand.Cards.Count(x => x.Face == secondHand.Cards[i].Face) == 4)
                {
                    secondHandFourOfAKindCard = secondHand.Cards[i];
                    break;
                }
            }

            return firstHandFourOfAKindCard.Face > secondHandFourOfAKindCard.Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
        }

        private WinningHand CompareFullHouseHands(IHand firstHand, IHand secondHand)
        {
            ICard firstHandPairCard = firstHand.Cards[0]; // default value
            ICard firstHandThreeOfAKindCard = firstHand.Cards[0]; // default value
            ICard secondHandPairCard = firstHand.Cards[0]; // default value                           
            ICard secondHandThreeOfAKindCard = firstHand.Cards[0]; // default value

            for (int i = 0; i < 5; i++)
            {
                if (firstHand.Cards.Count(x => x.Face == firstHand.Cards[i].Face) == 2)
                {
                    firstHandPairCard = firstHand.Cards[i];
                }

                if (firstHand.Cards.Count(x => x.Face == firstHand.Cards[i].Face) == 3)
                {
                    firstHandThreeOfAKindCard = firstHand.Cards[i];
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (secondHand.Cards.Count(x => x.Face == secondHand.Cards[i].Face) == 2)
                {
                    secondHandPairCard = secondHand.Cards[i];
                }

                if (secondHand.Cards.Count(x => x.Face == secondHand.Cards[i].Face) == 3)
                {
                    secondHandThreeOfAKindCard = secondHand.Cards[i];
                }
            }

            if (firstHandThreeOfAKindCard.Face != secondHandThreeOfAKindCard.Face)
            {
                ////return by three of a kind strength
                return firstHandThreeOfAKindCard.Face > secondHandThreeOfAKindCard.Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else if (firstHandPairCard.Face != secondHandPairCard.Face)
            {
                ////return by pair strength
                return firstHandPairCard.Face > secondHandPairCard.Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else
            {
                return WinningHand.HandsAreEqueal;
            }
        }

        private WinningHand CompareStraightHands(IHand firstHand, IHand secondHand)
        {
            var firstHandOrderedCards = firstHand.Cards.OrderBy(x => x.Face).ToList();
            var secondHandOrderedCards = secondHand.Cards.OrderBy(x => x.Face).ToList();

            if (firstHandOrderedCards.Count(x => x.Face == CardFace.Ace) == 1)
            {
                firstHandOrderedCards.Insert(0, new Card(CardFace.Two, CardSuit.Clubs));
            }

            if (secondHandOrderedCards.Count(x => x.Face == CardFace.Ace) == 1)
            {
                secondHandOrderedCards.Insert(0, new Card(CardFace.Two, CardSuit.Clubs));
            }

            if (firstHandOrderedCards[2].Face != secondHandOrderedCards[2].Face)
            {
                return firstHandOrderedCards[2].Face > secondHandOrderedCards[2].Face ? WinningHand.FirstHandWins : WinningHand.SeconHandWins;
            }
            else
            {
                return WinningHand.HandsAreEqueal;
            }
        }

        private WinningHand FindWinningHandByKickers(List<ICard> firstHand, List<ICard> secondHand)
        {
            var firstHandSortedCards = firstHand.OrderByDescending(x => x.Face).ToArray();
            var secondHandSortedCards = secondHand.OrderByDescending(x => x.Face).ToArray();

            for (int i = 0; i < firstHand.Count; i++)
            {
                if (firstHandSortedCards[i].Face > secondHandSortedCards[i].Face)
                {
                    return WinningHand.FirstHandWins;
                }

                if (firstHandSortedCards[i].Face < secondHandSortedCards[i].Face)
                {
                    return WinningHand.SeconHandWins;
                }
            }

            return WinningHand.HandsAreEqueal;
        }
    }
}
