using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardGroupQualityHelper
    {
        int Compare(CardGroupQualityEnum x, CardGroupQualityEnum y, bool flushBeatsFullHouse);
        IEnumerable<ICard> FlushIfExists(IEnumerable<ICard> cards);
        IEnumerable<ICard> StraightIfExists(IEnumerable<ICard> cards, bool aceCanBeUsedAsOneInStraights);
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
            if (cards == null) return null;

            var flush = cards
                        .GroupBy(x => x.Suit)
                        .SingleOrDefault(x => x.Count() == 5);

            if (flush == null)
                return null;

            return flush.OrderByDescending(x => x.Value);
        }

        public IEnumerable<ICard> StraightIfExists(IEnumerable<ICard> cards, bool aceCanBeUsedAsOneInStraights)
        {
            var allCards = cards?.OrderByDescending(x => x.Value).ToArray();
            if (allCards == null) return null;

            if (allCards[0].Value - allCards[4].Value == 4 &&
                allCards[0].Value - allCards[3].Value == 3 &&
                allCards[0].Value - allCards[2].Value == 2 &&
                allCards[0].Value - allCards[1].Value == 1)
                return allCards;

            if (aceCanBeUsedAsOneInStraights && allCards[0].Value == CardValueEnum.Ace
                                             && allCards[4].Value == CardValueEnum.Two
                                             && allCards[3].Value == CardValueEnum.Three
                                             && allCards[2].Value == CardValueEnum.Four
                                             && allCards[1].Value == CardValueEnum.Five)
                return allCards.Skip(1).Concat(allCards.Take(1));

            return null;
        }

        public IEnumerable<ICard> FourOfAKindIfExists(IEnumerable<ICard> cards)
        {
            if (cards == null) return null;

            return cards
                   .GroupBy(x => x.Value)
                   .SingleOrDefault(x => x.Count() == 4);
        }

        public IEnumerable<ICard> ThreeOfAKindIfExists(IEnumerable<ICard> cards)
        {
            if (cards == null) return null;

            return cards
                   .GroupBy(x => x.Value)
                   .SingleOrDefault(x => x.Count() == 3);
        }

        public IEnumerable<IEnumerable<ICard>> AllPairs(IEnumerable<ICard> cards)
        {
            if (cards == null) return null;

            return cards
                   .GroupBy(x => x.Value)
                   .Where(x => x.Count() == 2)
                   .OrderByDescending(x => x.First().Value);
        }
    }
}
