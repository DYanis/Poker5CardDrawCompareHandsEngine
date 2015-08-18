namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsOnePairTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsOnePairWithPairOfJacks()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            var card4 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsOnePair(hand), true);
        }

        [TestMethod]
        public void TestIsOnePairWith3Jacks()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card3 = new Card(CardFace.Jack, CardSuit.Hearts);
            var card4 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsOnePair(hand), false);
        }

        [TestMethod]
        public void TestIsOnePairWith2Jacksand2Quens()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Ten, CardSuit.Clubs);
            var card3 = new Card(CardFace.Queen, CardSuit.Hearts);
            var card4 = new Card(CardFace.Six, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Two, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsOnePair(hand), false);
        }

        [TestMethod]
        public void TestIsOnePairWith4Jacks()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card3 = new Card(CardFace.Queen, CardSuit.Hearts);
            var card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Jack, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsOnePair(hand), false);
        }

        [TestMethod]
        public void TestIsOnePairWith3JacksAnd2Quens()
        {
            var card1 = new Card(CardFace.Queen, CardSuit.Spades);
            var card2 = new Card(CardFace.Queen, CardSuit.Clubs);
            var card3 = new Card(CardFace.Jack, CardSuit.Hearts);
            var card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Jack, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsOnePair(hand), true);
        }
    }
}
