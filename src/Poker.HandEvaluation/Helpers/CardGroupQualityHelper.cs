using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardGroupQualityHelper
    {
        int Compare(CardGroupQualityEnum x, CardGroupQualityEnum y, IEvaluationOptions options);
    }
    public class CardGroupQualityHelper : ICardGroupQualityHelper
    {
        public int Compare(CardGroupQualityEnum x, CardGroupQualityEnum y, IEvaluationOptions options)
        {
            var res = x.CompareTo(y);
            if (options.FlushBeatsFullHouse)
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
