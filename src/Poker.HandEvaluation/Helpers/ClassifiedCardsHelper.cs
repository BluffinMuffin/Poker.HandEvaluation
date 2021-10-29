using System;
using System.Linq;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.Helpers
{
    public interface IClassifiedCardsHelper
    {
        int Compare(ClassifiedCards x, ClassifiedCards y, IEvaluationOptions options);
    }
    public class ClassifiedCardsHelper : IClassifiedCardsHelper
    {
        private readonly ICardGroupQualityHelper _cardGroupQualityHelper;
        private readonly ICardHelper _cardHelper;

        public ClassifiedCardsHelper(ICardGroupQualityHelper cardGroupQualityHelper, ICardHelper cardHelper)
        {
            _cardGroupQualityHelper = cardGroupQualityHelper;
            _cardHelper = cardHelper;
        }

        public int Compare(ClassifiedCards x, ClassifiedCards y, IEvaluationOptions options)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y) || y.Cards == null || !y.Cards.Any()) return 1;
            if (ReferenceEquals(null, x) || x.Cards == null || !x.Cards.Any()) return -1;

            if (x.Quality != y.Quality)
                return _cardGroupQualityHelper.Compare(x.Quality, y.Quality, options);

            var xCards = x.Cards.ToArray();
            var yCards = y.Cards.ToArray();

            for (int i = 0; i < Math.Min(xCards.Length, yCards.Length); ++i)
            {
                var res = _cardHelper.Compare(xCards[i], yCards[i], options);
                if (res != 0)
                    return res;
            }
            return 0;
        }
    }
}
