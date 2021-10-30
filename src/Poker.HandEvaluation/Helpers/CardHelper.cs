using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardHelper
    {
        int Compare(ICard x, ICard y, bool suitRankingActivated);
        IEnumerable<IEnumerable<ICard>> AllCombinations(IEnumerable<ICard> deck, int nbCards);
    }
    public class CardHelper : ICardHelper
    {
        public int Compare(ICard x, ICard y, bool suitRankingActivated)
        {
            var res = ((int)x.Value).CompareTo(y.Value);

            if (res == 0 && suitRankingActivated)
                return ((int)x.Suit).CompareTo(y.Suit);

            return res;
        }
        public IEnumerable<IEnumerable<ICard>> AllCombinations(IEnumerable<ICard> deck, int nbCards)
        {
            var allCards = deck?.ToArray();
            if (allCards == null || allCards.Length < nbCards)
                throw new ArgumentNullException(nameof(deck));

            return Possibilities(allCards, 0, nbCards);

            IEnumerable<IEnumerable<ICard>> Possibilities(ICard[] cards, int start, int remaining)
            {
                for (int i = start; i < cards.Length; ++i)
                    if (remaining == 1)
                        yield return new[] { cards[i] };
                    else
                        foreach (var c in Possibilities(cards, i + 1, remaining - 1))
                            yield return new[] { cards[i] }.Concat(c);
            }
        }
    }
}
