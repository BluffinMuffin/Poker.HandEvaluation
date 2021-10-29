using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardGroupQualityHelper
    {
        int Compare(CardGroupQualityEnum x, CardGroupQualityEnum y, bool flushBeatsFullHouse);
        IEnumerable<ICard> FlushIfExists(IEnumerable<ICard> cards);
        IEnumerable<ICard> FourOfAKindIfExists(IEnumerable<ICard> cards);
        IEnumerable<ICard> ThreeOfAKindIfExists(IEnumerable<ICard> cards);
        IEnumerable<IEnumerable<ICard>> AllPairs(IEnumerable<ICard> cards);
    }
    public class CardGroupQualityHelper : ICardGroupQualityHelper
    {
        public int Compare(CardGroupQualityEnum x, CardGroupQualityEnum y, bool flushBeatsFullHouse)
        {
            var res = x.CompareTo(y);
            if (flushBeatsFullHouse)
            {
                if (x == CardGroupQualityEnum.Flush && y == CardGroupQualityEnum.FullHouse)
                    return 1;
                if (x == CardGroupQualityEnum.FullHouse && y == CardGroupQualityEnum.Flush)
                    return -1;
            }

            return res;
        }

        public IEnumerable<ICard> FlushIfExists(IEnumerable<ICard> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));

            return (cards
                    .GroupBy(x => x.Suit)
                    .SingleOrDefault(x => x.Count() == 5) ?? new ICard[0].AsEnumerable())
                .OrderByDescending(x => x);
        }

        public IEnumerable<ICard> FourOfAKindIfExists(IEnumerable<ICard> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));

            return cards
                   .GroupBy(x => x.Value)
                   .SingleOrDefault(x => x.Count() == 4);
        }

        public IEnumerable<ICard> ThreeOfAKindIfExists(IEnumerable<ICard> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));

            return cards
                   .GroupBy(x => x.Value)
                   .SingleOrDefault(x => x.Count() == 3);
        }

        public IEnumerable<IEnumerable<ICard>> AllPairs(IEnumerable<ICard> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));

            return cards
                   .GroupBy(x => x.Value)
                   .Where(x => x.Count() == 2)
                   .OrderByDescending(x => x.First());
        }
    }
}
