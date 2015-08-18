namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsFourOfAKindTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsFourOfAKindWith4CardsWithEqualFace()
        {
            var card1 = new Card(CardFace.Three, CardSuit.Spades);
            var card2 = new Card(CardFace.Three, CardSuit.Clubs);
            var card3 = new Card(CardFace.Three, CardSuit.Hearts);
            var card4 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsFourOfAKind(hand), true);
        }

        [TestMethod]
        public void TestIsFourOfAKindWith4CardsWithEqualFaceStartWithOtharCard()
        {
            var card1 = new Card(CardFace.King, CardSuit.Spades);
            var card2 = new Card(CardFace.Three, CardSuit.Clubs);
            var card3 = new Card(CardFace.Three, CardSuit.Hearts);
            var card4 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Three, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsFourOfAKind(hand), true);
        }

        [TestMethod]
        public void TestIsFourOfAKindWith3CardsWithEqualFace()
        {
            var card1 = new Card(CardFace.Three, CardSuit.Spades);
            var card2 = new Card(CardFace.Three, CardSuit.Clubs);
            var card3 = new Card(CardFace.Three, CardSuit.Hearts);
            var card4 = new Card(CardFace.Eight, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsFourOfAKind(hand), false);
        }
    }
}
