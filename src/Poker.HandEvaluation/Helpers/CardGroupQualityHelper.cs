using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardGroupQualityHelper
    {
        int Compare(CardGroupQualityEnum x, CardGroupQualityEnum y, bool flushBeatsFullHouse);
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
    }
}
