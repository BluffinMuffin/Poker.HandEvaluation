using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.CardSelectors
{
    public class CardSelectorOnlyHand
    {
        private readonly ICardHelper _cardHelper;

        public CardSelectorOnlyHand(ICardHelper cardHelper)
        {
            _cardHelper = cardHelper;
        }

        public IEnumerable<IEnumerable<ICard>> SelectCards(IPlayerCards player)
        {
            return _cardHelper.AllCombinations(player.HandCards, 5);
        }
    }
}