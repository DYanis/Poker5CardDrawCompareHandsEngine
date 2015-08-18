namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsTwoPairsTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsTwoPairsWithAllDifferentCards()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Two, CardSuit.Clubs);
            var card3 = new Card(CardFace.Five, CardSuit.Hearts);
            var card4 = new Card(CardFace.Eight, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsTwoPairs(hand), false);
        }

        [TestMethod]
        public void TestIsTwoPairsWith2JacksAnd2Eights()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card3 = new Card(CardFace.Eight, CardSuit.Hearts);
            var card4 = new Card(CardFace.Eight, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsTwoPairs(hand), true);
        }

        [TestMethod]
        public void TestIsTwoPairsWith4Jacks()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card3 = new Card(CardFace.Jack, CardSuit.Hearts);
            var card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsTwoPairs(hand), false);
        }

        [TestMethod]
        public void TestIsTwoPairsWith2Jacks()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card3 = new Card(CardFace.Nine, CardSuit.Hearts);
            var card4 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsTwoPairs(hand), false);
        }
    }
}
