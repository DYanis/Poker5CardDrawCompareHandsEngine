namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsHighCardTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsHighCardWith5DifferendCards()
        {
            var card1 = new Card(CardFace.Jack, CardSuit.Spades);
            var card2 = new Card(CardFace.Ten, CardSuit.Clubs);
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
            Assert.AreEqual(pokerHandsChecker.IsHighCard(hand), true);
        }

        [TestMethod]
        public void TestIsHighCardWithOnePairHandOfJacks()
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
            Assert.AreEqual(pokerHandsChecker.IsHighCard(hand), false);
        }
    }
}
