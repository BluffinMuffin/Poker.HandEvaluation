using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.CardSelectors
{
    public class CardSelectorAllCards
    {
        public IEnumerable<IEnumerable<ICard>> SelectCards(IPlayerCards player)
        {
            yield return player.HandCards.Union(player.TableCards);
        }
    }
}