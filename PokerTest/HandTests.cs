namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;
    using Poker.Interfaces;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestHandToStringWithKingSpadesThreeClubsTenClubsQueenDiamondsAndSixClubs()
        {
            var card1 = new Card(CardFace.King, CardSuit.Spades);
            var card2 = new Card(CardFace.Three, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ten, CardSuit.Clubs);
            var card4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            var card5 = new Card(CardFace.Six, CardSuit.Clubs);

            var cardList = new List<ICard>();
            cardList.Add(card1);
            cardList.Add(card2);
            cardList.Add(card3);
            cardList.Add(card4);
            cardList.Add(card5);

            Hand hand = new Hand(cardList);
            string correctResult = hand.Cards[0].ToString() + hand.Cards[1] + hand.Cards[2] + hand.Cards[3] + hand.Cards[4];

            Assert.AreEqual(hand.ToString(), correctResult);
        }
    }
}
