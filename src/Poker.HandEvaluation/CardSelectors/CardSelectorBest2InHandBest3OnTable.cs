using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.CardSelectors
{
    public class CardSelectorBest2InHandBest3OnTable
    {
        private readonly ICardHelper _cardHelper;

        public CardSelectorBest2InHandBest3OnTable(ICardHelper cardHelper)
        {
            _cardHelper = cardHelper;
        }

        public IEnumerable<IEnumerable<ICard>> SelectCards(IPlayerCards player)
        {
            return from hand in _cardHelper.AllCombinationsOf2(player.HandCards).Select(x => x.ToArray())
                   from table in _cardHelper.AllCombinationsOf3(player.TableCards).Select(x => x.ToArray())
                   select hand.Concat(table);
        }
    }
}