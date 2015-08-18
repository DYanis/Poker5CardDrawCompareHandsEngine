namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class HandStrengthRecognizerTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandStrengthRecognizerWithFiveSameFaceCards()
        {
            Card card1 = new Card(CardFace.Three, CardSuit.Spades);
            Card card2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Three, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Three, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Three, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            pokerHandsChecker.RecognizeHandStrength(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandStrengthRecognizerWithTwoSameFaceAndSameSuitCards()
        {
            Card card1 = new Card(CardFace.Three, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Six,  CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            pokerHandsChecker.RecognizeHandStrength(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHandStrengthRecognizerWithOnlyFourCards()
        {
            Card card1 = new Card(CardFace.Three, CardSuit.Spades);
            Card card2 = new Card(CardFace.Three, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Three, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Three, CardSuit.Diamonds);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);

            Hand hand = new Hand(cardList);
            pokerHandsChecker.RecognizeHandStrength(hand);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerWithHighCardHand()
        {
            Card card1 = new Card(CardFace.Three, CardSuit.Spades);
            Card card2 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.HighCard);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerWithOnePairHand()
        {
            Card card1 = new Card(CardFace.Three, CardSuit.Spades);
            Card card2 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Eight, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.OnePair);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerWithTwoPairsHand()
        {
            Card card1 = new Card(CardFace.Six, CardSuit.Spades);
            Card card2 = new Card(CardFace.Six, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Eight, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.TwoPairs);
        }
        
        [TestMethod]
        public void TestHandStrengthRecognizerWithThreeOfAKindHand()
        {
            Card card1 = new Card(CardFace.Eight, CardSuit.Spades);
            Card card2 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Eight, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.ThreeOfAKind);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerWithStraightHand()
        {
            Card card1 = new Card(CardFace.Eight, CardSuit.Spades);
            Card card2 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Nine, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Seven, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.Straight);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerWithFlushHand()
        {
            Card card1 = new Card(CardFace.Eight, CardSuit.Spades);
            Card card2 = new Card(CardFace.Ace, CardSuit.Spades);
            Card card3 = new Card(CardFace.Nine, CardSuit.Spades);
            Card card4 = new Card(CardFace.Jack, CardSuit.Spades);
            Card card5 = new Card(CardFace.Seven, CardSuit.Spades);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.Flush);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerWithFullHouseHand()
        {
            Card card1 = new Card(CardFace.Six, CardSuit.Spades);
            Card card2 = new Card(CardFace.Six, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Six, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Eight, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.FullHouse);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerWithFourOfAKindHand()
        {
            Card card1 = new Card(CardFace.Six, CardSuit.Spades);
            Card card2 = new Card(CardFace.Six, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Six, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Six, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Eight, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.FourOfAKind);
        }

        [TestMethod]
        public void TestHandStrengthRecognizerStraightFlushHand()
        {
            Card card1 = new Card(CardFace.Two, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Three, CardSuit.Clubs);
            Card card4 = new Card(CardFace.Four, CardSuit.Clubs);
            Card card5 = new Card(CardFace.Five, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.RecognizeHandStrength(hand), HandStrength.StraightFlush);
        }
    }
}