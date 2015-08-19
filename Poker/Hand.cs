namespace Poker
{
    using System;
    using System.Collections.Generic;

    using Poker.Interfaces;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            return this.Cards[0].ToString() + this.Cards[1] + this.Cards[2] + this.Cards[3] + this.Cards[4];
        }
    }
}
