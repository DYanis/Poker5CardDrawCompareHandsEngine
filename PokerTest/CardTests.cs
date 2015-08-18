namespace PokerTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;
    using Poker.Enumerations;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestCardToStringWithJackDiamonds()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);

            Assert.AreEqual(card.ToString(), "CardFace: " + CardFace.Jack + "\n" + "CardSuit: " + CardSuit.Diamonds + "\n");
        }

        [TestMethod]
        public void TestCardEqualWithSameFaceAndSameSuitCards()
        {
            Card firstCard = new Card(CardFace.Four, CardSuit.Clubs);
            Card secondCard = new Card(CardFace.Four, CardSuit.Clubs);

            Assert.AreEqual(firstCard.Equals(secondCard), true);
        }

        [TestMethod]
        public void TestCardEqualWithDifferentFaceAndDifferentSuitCards()
        {
            Card firstCard = new Card(CardFace.Four, CardSuit.Clubs);
            Card secondCard = new Card(CardFace.King, CardSuit.Hearts);

            Assert.AreEqual(firstCard.Equals(secondCard), false);
        }

        [TestMethod]
        public void TestCardEqualWithSameFaceAndDifferentSuitCards()
        {
            Card firstCard = new Card(CardFace.Four, CardSuit.Hearts);
            Card secondCard = new Card(CardFace.Four, CardSuit.Clubs);

            Assert.AreEqual(firstCard.Equals(secondCard), false);
        }

        [TestMethod]
        public void TestCardEqualWithDifferentFaceAndSameSuitCards()
        {
            Card firstCard = new Card(CardFace.Four, CardSuit.Clubs);
            Card secondCard = new Card(CardFace.King, CardSuit.Clubs);

            Assert.AreEqual(firstCard.Equals(secondCard), false);
        } 
    }
}
