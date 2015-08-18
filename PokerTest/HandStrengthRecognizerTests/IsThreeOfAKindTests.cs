namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class IsThreeOfAKindTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestIsThreeOfAKindWithAllDifferentCards()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Five, CardSuit.Clubs);
            var card3 = new Card(CardFace.Four, CardSuit.Hearts);
            var card4 = new Card(CardFace.Two, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Jack, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsThreeOfAKind(hand), false);
        }

        [TestMethod]
        public void TestIsThreeOfAKindWith2Aces()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.Four, CardSuit.Hearts);
            var card4 = new Card(CardFace.Three, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsThreeOfAKind(hand), false);
        }

       [TestMethod]
       public void TestIsThreeOfAKindWith3Aces()
       {
           var card1 = new Card(CardFace.Ace, CardSuit.Spades);
           var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
           var card3 = new Card(CardFace.Ace, CardSuit.Hearts);
           var card4 = new Card(CardFace.Three, CardSuit.Diamonds);
           var card5 = new Card(CardFace.Six, CardSuit.Clubs);
      
           cardList = new List<ICard>();
           cardList.Add(card1);
           cardList.Add(card2);
           cardList.Add(card3);
           cardList.Add(card4);
           cardList.Add(card5);

           Hand hand = new Hand(cardList);
           Assert.AreEqual(pokerHandsChecker.IsThreeOfAKind(hand), true);
       }
      
       [TestMethod]
       public void TestIsThreeOfAKindWith3AcesAnd2Jacks()
       {
           var card1 = new Card(CardFace.Ace, CardSuit.Spades);
           var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
           var card3 = new Card(CardFace.Ace, CardSuit.Hearts);
           var card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
           var card5 = new Card(CardFace.Jack, CardSuit.Clubs);
      
           cardList = new List<ICard>();
           cardList.Add(card1);
           cardList.Add(card2);
           cardList.Add(card3);
           cardList.Add(card4);
           cardList.Add(card5);

           Hand hand = new Hand(cardList);
           Assert.AreEqual(pokerHandsChecker.IsThreeOfAKind(hand), true);
       }
    }
}
