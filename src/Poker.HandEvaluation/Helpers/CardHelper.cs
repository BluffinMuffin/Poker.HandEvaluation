using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface ICardHelper
    {
        int Compare(ICard x, ICard y, bool suitRankingActivated);
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
    }
}
