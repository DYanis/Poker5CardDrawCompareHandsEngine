namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsStraightFlushTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsStraightFlushWithStraightAceToFiveOfSpades()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Two, CardSuit.Spades);
            var card3 = new Card(CardFace.Three, CardSuit.Spades);
            var card4 = new Card(CardFace.Four, CardSuit.Spades);
            var card5 = new Card(CardFace.Five, CardSuit.Spades);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraightFlush(hand), true);
        }

        [TestMethod]
        public void TestIsStraightFlushWithStraightTenToAceOfClubs()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card2 = new Card(CardFace.Queen, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ten, CardSuit.Clubs);
            var card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card5 = new Card(CardFace.King, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraightFlush(hand), true);
        }

        [TestMethod]
        public void TestIsStraightFlushWithOnlyStraightHand()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card2 = new Card(CardFace.Queen, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ten, CardSuit.Clubs);
            var card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card5 = new Card(CardFace.King, CardSuit.Diamonds);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraightFlush(hand), false);
        }

        [TestMethod]
        public void TestIsStraightFlushWithOnlyFlushHand()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card2 = new Card(CardFace.King, CardSuit.Clubs);
            var card3 = new Card(CardFace.Queen, CardSuit.Clubs);
            var card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            var card5 = new Card(CardFace.Nine, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraightFlush(hand), false);
        }
    }
}
