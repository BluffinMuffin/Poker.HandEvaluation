using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardHelper
    {
        int Compare(ICard x, ICard y, IEvaluationOptions options);
    }
    public class CardHelper : ICardHelper
    {
        public int Compare(ICard x, ICard y, IEvaluationOptions options)
        {
            var res = ((int)x.Value).CompareTo(y.Value);

            if (res == 0 && options.SuitRankingActivated)
                return ((int)x.Suit).CompareTo(y.Suit);

            return res;
        }
    }
}
