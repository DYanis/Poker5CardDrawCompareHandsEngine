namespace PokerTest.HandStrengthRecognizerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;
   
    [TestClass]
    public class IsValidHandTests
    {
        private IList<ICard> cardList;
        private readonly HandStrengthRecognizer pokerHandsChecker = new HandStrengthRecognizer();

        [TestMethod]
        public void TestHandsChekerIsValidHandWithValidHand()
        {
            var card1 = new Card(CardFace.King, CardSuit.Spades);
            var card2 = new Card(CardFace.Three, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ten, CardSuit.Clubs);
            var card4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsValidHand(hand),true);
        }

        [TestMethod]
        public void TestHandsChekerIsValidHandWith2SameCards()
        {
            var card1 = new Card(CardFace.King, CardSuit.Spades);
            var card2 = new Card(CardFace.Six, CardSuit.Clubs);            
            var card3 = new Card(CardFace.Ten, CardSuit.Clubs);
            var card4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            var card5 = new Card(CardFace.King, CardSuit.Spades);
            
            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsValidHand(hand), false);
        }

        [TestMethod]
        public void TestHandsChekerIsValidHandWithHandContainsOnly4Cards()
        {
            var card1 = new Card(CardFace.King, CardSuit.Spades);
            var card2 = new Card(CardFace.Three, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ten, CardSuit.Clubs);
            var card4 = new Card(CardFace.Queen, CardSuit.Diamonds);

            cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);

            Hand hand = new Hand(cardList);
            Assert.AreEqual(pokerHandsChecker.IsValidHand(hand), false);
        } 
    }
}
