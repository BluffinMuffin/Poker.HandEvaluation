using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardHelper
    {
        int Compare(ICard x, ICard y, bool suitRankingActivated);
        IEnumerable<IEnumerable<ICard>> AllCombinationsOf5(IEnumerable<ICard> deck);
        IEnumerable<IEnumerable<ICard>> AllCombinationsOf3(IEnumerable<ICard> deck);
        IEnumerable<IEnumerable<ICard>> AllCombinationsOf2(IEnumerable<ICard> deck);
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
        public IEnumerable<IEnumerable<ICard>> AllCombinationsOf5(IEnumerable<ICard> deck)
        {
            var cards = deck?.ToArray();
            if (cards == null || cards.Length < 5)
                throw new ArgumentNullException(nameof(deck));

            for (int a = 0; a < cards.Length; ++a)
                for (int b = a + 1; b < cards.Length; ++b)
                    for (int c = b + 1; c < cards.Length; ++c)
                        for (int d = c + 1; d < cards.Length; ++d)
                            for (int e = d + 1; e < cards.Length; ++e)
                                yield return new[] { cards[a], cards[b], cards[c], cards[d], cards[e] };
        }
        public IEnumerable<IEnumerable<ICard>> AllCombinationsOf3(IEnumerable<ICard> deck)
        {
            var cards = deck?.ToArray();
            if (cards == null || cards.Length < 3)
                throw new ArgumentNullException(nameof(deck));

            for (int a = 0; a < cards.Length; ++a)
                for (int b = a + 1; b < cards.Length; ++b)
                    for (int c = b + 1; c < cards.Length; ++c)
                        yield return new[] { cards[a], cards[b], cards[c] };
        }
        public IEnumerable<IEnumerable<ICard>> AllCombinationsOf2(IEnumerable<ICard> deck)
        {
            var cards = deck?.ToArray();
            if (cards == null || cards.Length < 2)
                throw new ArgumentNullException(nameof(deck));

            for (int a = 0; a < cards.Length; ++a)
                for (int b = a + 1; b < cards.Length; ++b)
                    yield return new[] { cards[a], cards[b] };
        }
    }
}
