using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.CardSelectors
{
    public class CardSelectorAllCards
    {
        private readonly ICardHelper _cardHelper;

        public CardSelectorAllCards(ICardHelper cardHelper)
        {
            _cardHelper = cardHelper;
        }

        public IEnumerable<IEnumerable<ICard>> SelectCards(IPlayerCards player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));

            return _cardHelper.AllCombinations(player.HandCards.Concat(player.TableCards), 5);
        }
    }
}