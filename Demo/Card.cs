namespace Poker
{
    using System;
    
    using Poker.Enumerations;
    using Poker.Interfaces;

    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            return "CardFace: " + this.Face + "\n" + "CardSuit: " + this.Suit + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Card card = obj as Card;

            if (this.Face == card.Face && this.Suit == card.Suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
