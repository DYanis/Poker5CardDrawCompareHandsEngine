namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsFlushTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsFlushWith5CardsWithEqualSuit()
        {
            var card1 = new Card(CardFace.King, CardSuit.Diamonds);
            var card2 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card3 = new Card(CardFace.Ten, CardSuit.Diamonds);
            var card4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Diamonds);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsFlush(hand), true);
        }

        [TestMethod]
        public void TestIsFlushWith4CardsWithEqualSuit()
        {
            var card1 = new Card(CardFace.King, CardSuit.Diamonds);
            var card2 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card3 = new Card(CardFace.Ten, CardSuit.Diamonds);
            var card4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Spades);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsFlush(hand), false);
        }
    }
}
