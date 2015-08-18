namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsStraightTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsStreightWithAceToFive()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Two, CardSuit.Clubs);
            var card3 = new Card(CardFace.Three, CardSuit.Hearts);
            var card4 = new Card(CardFace.Four, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Five, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraight(hand), true);
        }

        [TestMethod]
        public void TestIsStreightWithTwoToSix()
        {
            var card1 = new Card(CardFace.Six, CardSuit.Spades);
            var card2 = new Card(CardFace.Two, CardSuit.Clubs);
            var card3 = new Card(CardFace.Three, CardSuit.Hearts);
            var card4 = new Card(CardFace.Four, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Five, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraight(hand), true);
        }

        [TestMethod]
        public void TestIsStreightWithTenToAce()
        {
            var card1 = new Card(CardFace.Queen, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.King, CardSuit.Hearts);
            var card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Ten, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraight(hand), true);
        }

        [TestMethod]
        public void TestIsStreightWithQueenAceTwoJackTen()
        {
            var card1 = new Card(CardFace.Queen, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.Two, CardSuit.Hearts);
            var card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Ten, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraight(hand), false);
        }

        [TestMethod]
        public void TestIsStreightWithTwoAceThreeFourSix()
        {
            var card1 = new Card(CardFace.Two, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.Three, CardSuit.Hearts);
            var card4 = new Card(CardFace.Four, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraight(hand), false);
        }

        [TestMethod]
        public void TestIsStreightWithTenEightJackEightKing()
        {
            Card card1 = new Card(CardFace.Ten, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Eight, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Jack, CardSuit.Hearts);
            Card card4 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.King, CardSuit.Diamonds);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsStraight(hand), false);
        }
    }
}
