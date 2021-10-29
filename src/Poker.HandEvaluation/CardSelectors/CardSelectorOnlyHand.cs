using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.CardSelectors
{
    public class CardSelectorOnlyHand
    {
        public IEnumerable<IEnumerable<ICard>> SelectCards(IPlayerCards player)
        {
            yield return player.HandCards;
        }
    }
}