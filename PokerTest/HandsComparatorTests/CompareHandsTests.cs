namespace PokerTest.HandsComparatorTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class CompareHandsTests
    {
        private IList<ICard> firstHandCardList;
        private IList<ICard> secondHandCardList;
        private readonly HandsComparator handsComparator = new HandsComparator();

        //Tests When hands strength is differet
        [TestMethod]
        public void TestCompareHandsWithFirstHandStrengthIsHighCardAndSecondHandStrengthIsOnePair()
        {
            Card fCard1 = new Card(CardFace.Two, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Four, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Seven, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Two, CardSuit.Spades);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Four, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Two, CardSuit.Clubs);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);
            
            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithFirstHandStrengthIsFullHouseAndSecondHandStrengthIsThreeOfAKind()
        {
            Card fCard1 = new Card(CardFace.Two, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Four, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Two, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Two, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Two, CardSuit.Spades);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Three, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Three, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Ace, CardSuit.Clubs);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithFirstHandStrengthIsStraightAndSecondHandStrengthIsStraightFlush()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.King, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Ten, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Jack, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Seven, CardSuit.Diamonds);
            Card sCard2 = new Card(CardFace.Ten, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card sCard4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Nine, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        //Tests when cards strength are same

        //High card hands cases
        [TestMethod]
        public void TestCompareHandsWithHighCardToSevenVsHighCardToEight()
        {
            Card fCard1 = new Card(CardFace.Two, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Four, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Seven, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Two, CardSuit.Spades);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Four, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Eight, CardSuit.Clubs);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithHighCardToAceWithKickerSevenVsHighCardToAceWithKickerEight()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Four, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Seven, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Four, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Eight, CardSuit.Clubs);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithEqualHighCardHands()
        {
            Card fCard1 = new Card(CardFace.Ten, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.King, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Eight, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Eight, CardSuit.Spades);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Ten, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.King, CardSuit.Clubs);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.HandsAreEqueal);
        }

        [TestMethod]
        public void TestCompareHandsWithHighCardKingWithKickerQueenVsHighCardKingWithKickerJack()
        {
            Card fCard1 = new Card(CardFace.Ten, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.King, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Eight, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Seven, CardSuit.Spades);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Ten, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.King, CardSuit.Clubs);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        //One pair hands
        [TestMethod]
        public void TestCompareHandsWithEqualOnePairHands()
        {
            Card fCard1 = new Card(CardFace.Eight, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.King, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Ten, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Eight, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.King, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card sCard5 = new Card(CardFace.Eight, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.HandsAreEqueal);
        }

        [TestMethod]
        public void TestCompareHandsWithOnePairOfEightsWithKickerAceVsOnePairOfEightsWithKickerKing()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Eight, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.King, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Eight, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.King, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithOnePairOfFoursVsOnePairOfEights()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.King, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Eight, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.King, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        //Two pairs hands cases
        [TestMethod]
        public void TestCompareHandsWithEqualTwoPairsHands()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Ace, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Ace, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.HandsAreEqueal);
        }

        [TestMethod]
        public void TestCompareHandsWithTwoPairsAcesAndFoursWithKickerQueenVsTwoPairsAcesAndFoursWithKickerJack()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Queen, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Ace, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Ace, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithTwoPairsAcesAndFoursVsTwoPairsAcesAndNines()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Ace, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Ace, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }
        [TestMethod]
        public void TestCompareHandsWithTwoPairsEightsAndFoursVsTwoPairsEightsAndNines()
        {
            Card fCard1 = new Card(CardFace.Eight, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Eight, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Eight, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Eight, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        //case three of a kind hands
        [TestMethod]
        public void TestCompareHandsWithEqualThreeOfAKindHands()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Six, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Six, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.HandsAreEqueal);
        }

        [TestMethod]
        public void TestCompareHandsWithThreeOfAKindOfNineVsThreeOfAKindOfSeven()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Six, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Seven, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Seven, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Seven, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Six, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithThreeOfAKindOfNineWithKickersAceAndSevenVsThreeOfAKindOfNineWithKickersAceAndEight()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Seven, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Eight, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithThreeOfAKindOfNineWithKickersAceAndSevenVsThreeOfAKindOfNineWithKickersKingAndSeven()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Seven, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.King, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Seven, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        //case straight hands
        [TestMethod]
        public void TestCompareHandsWithEqualStraightHands()
        {
            Card fCard1 = new Card(CardFace.Six, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Two, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Three, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Five, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Six, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Two, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.HandsAreEqueal);
        }

        [TestMethod]
        public void TestCompareHandsWithStraightToFiveVsStraightToSix()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Four, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Two, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Three, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Five, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Six, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Two, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithStraightToAceVsStraightToFive()
        {
            Card fCard1 = new Card(CardFace.Jack, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Queen, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.King, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card fCard5 = new Card(CardFace.Ten, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Two, CardSuit.Hearts);
            Card sCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        //case flush hands
        [TestMethod]
        public void TestCompareHandsWithFlushHandsWithEqualCardFaceAndDifferentCardSuits()
        {
            Card fCard1 = new Card(CardFace.Ace, CardSuit.Hearts);
            Card fCard2 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.Two, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.King, CardSuit.Hearts);
            Card fCard5 = new Card(CardFace.Four, CardSuit.Hearts);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Two, CardSuit.Diamonds);
            Card sCard4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithFlushToJackVsFlushToTen()
        {
            Card fCard1 = new Card(CardFace.Six, CardSuit.Hearts);
            Card fCard2 = new Card(CardFace.Three, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.Two, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard5 = new Card(CardFace.Four, CardSuit.Hearts);

            Card sCard1 = new Card(CardFace.Ten, CardSuit.Diamonds);
            Card sCard2 = new Card(CardFace.Three, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Two, CardSuit.Diamonds);
            Card sCard4 = new Card(CardFace.Five, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        // case full house hands
        [TestMethod]
        public void TestCompareHandsWithEqualFullHouseHands()
        {
            Card fCard1 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card fCard2 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card fCard4 = new Card(CardFace.Jack, CardSuit.Clubs);
            Card fCard5 = new Card(CardFace.Jack, CardSuit.Spades);

            Card sCard1 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card sCard2 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Eight, CardSuit.Spades);
            Card sCard4 = new Card(CardFace.Jack, CardSuit.Clubs);
            Card sCard5 = new Card(CardFace.Jack, CardSuit.Spades);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.HandsAreEqueal);
        }

        [TestMethod]
        public void TestCompareHandsWithFullHouseHandsWithThreeJacksAndTwoEightsVsThreeQueensAndTwoEights()
        {
            Card fCard1 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card fCard2 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card fCard4 = new Card(CardFace.Jack, CardSuit.Clubs);
            Card fCard5 = new Card(CardFace.Jack, CardSuit.Spades);

            Card sCard1 = new Card(CardFace.Queen, CardSuit.Diamonds);
            Card sCard2 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Eight, CardSuit.Spades);
            Card sCard4 = new Card(CardFace.Queen, CardSuit.Clubs);
            Card sCard5 = new Card(CardFace.Queen, CardSuit.Spades);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithFullHouseHandsWithThreeKingsAndTwoEightsVsThreeKingsAndTwoFours()
        {
            Card fCard1 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card fCard2 = new Card(CardFace.King, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card fCard4 = new Card(CardFace.King, CardSuit.Clubs);
            Card fCard5 = new Card(CardFace.King, CardSuit.Spades);

            Card sCard1 = new Card(CardFace.King, CardSuit.Diamonds);
            Card sCard2 = new Card(CardFace.Four, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.King, CardSuit.Spades);
            Card sCard4 = new Card(CardFace.King, CardSuit.Clubs);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Spades);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        // case four of a kind hands
        [TestMethod]
        public void TestCompareHandsWithFourOfAKindOfKingsVsFourOfAKindOfTens()
        {
            Card fCard1 = new Card(CardFace.Four, CardSuit.Hearts);
            Card fCard2 = new Card(CardFace.King, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.King, CardSuit.Diamonds);
            Card fCard4 = new Card(CardFace.King, CardSuit.Clubs);
            Card fCard5 = new Card(CardFace.King, CardSuit.Spades);

            Card sCard1 = new Card(CardFace.Ten, CardSuit.Hearts);
            Card sCard2 = new Card(CardFace.Ten, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Ten, CardSuit.Spades);
            Card sCard4 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Spades);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithFourOfAKindOfJacksVsFourOfAKindOfAces()
        {
            Card fCard1 = new Card(CardFace.Jack, CardSuit.Spades);
            Card fCard2 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card fCard4 = new Card(CardFace.Jack, CardSuit.Clubs);
            Card fCard5 = new Card(CardFace.King, CardSuit.Spades);

            Card sCard1 = new Card(CardFace.Ace, CardSuit.Hearts);
            Card sCard2 = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Ace, CardSuit.Spades);
            Card sCard4 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card sCard5 = new Card(CardFace.Four, CardSuit.Spades);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }

        //case straight flush hands
        [TestMethod]
        public void TestCompareHandsWithStraightFlushHandsWithEqualCardFaceAndDifferentCardSuits()
        {
            Card fCard1 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card fCard2 = new Card(CardFace.King, CardSuit.Hearts);
            Card fCard3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card fCard4 = new Card(CardFace.Ten, CardSuit.Hearts);
            Card fCard5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Card sCard1 = new Card(CardFace.King, CardSuit.Diamonds);
            Card sCard2 = new Card(CardFace.Nine, CardSuit.Diamonds);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card sCard4 = new Card(CardFace.Ten, CardSuit.Diamonds);
            Card sCard5 = new Card(CardFace.Queen, CardSuit.Diamonds);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.FirstHandWins);
        }

        [TestMethod]
        public void TestCompareHandsWithStraightFlushHandToFiveVsStraightFlushHandToKing()
        {
            Card fCard1 = new Card(CardFace.Two, CardSuit.Clubs);
            Card fCard2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card fCard3 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card fCard4 = new Card(CardFace.Five, CardSuit.Clubs);
            Card fCard5 = new Card(CardFace.Four, CardSuit.Clubs);

            Card sCard1 = new Card(CardFace.Nine, CardSuit.Clubs);
            Card sCard2 = new Card(CardFace.King, CardSuit.Clubs);
            Card sCard3 = new Card(CardFace.Jack, CardSuit.Clubs);
            Card sCard4 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card sCard5 = new Card(CardFace.Queen, CardSuit.Clubs);

            firstHandCardList = new List<ICard>();
            firstHandCardList.Add(fCard1);
            firstHandCardList.Add(fCard2);
            firstHandCardList.Add(fCard3);
            firstHandCardList.Add(fCard4);
            firstHandCardList.Add(fCard5);

            secondHandCardList = new List<ICard>();
            secondHandCardList.Add(sCard1);
            secondHandCardList.Add(sCard2);
            secondHandCardList.Add(sCard3);
            secondHandCardList.Add(sCard4);
            secondHandCardList.Add(sCard5);

            Hand firstHand = new Hand(firstHandCardList);
            Hand secondHand = new Hand(secondHandCardList);

            Assert.AreEqual(handsComparator.CompareHands(firstHand, secondHand), WinningHand.SeconHandWins);
        }
    }
}
