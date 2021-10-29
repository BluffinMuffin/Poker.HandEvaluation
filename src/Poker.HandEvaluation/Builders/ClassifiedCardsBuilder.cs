using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.Builders
{
    public interface IClassifiedCardsBuilder
    {
        ClassifiedCards Build(IEnumerable<ICard> concernedCards, CardGroupQualityEnum quality, IEvaluationOptions options, IEnumerable<ICard> remainingCards = null);
    }
    public class ClassifiedCardsBuilder : IClassifiedCardsBuilder
    {
        private readonly IClassifiedCardsHelper _classifiedCardsHelper;

        public ClassifiedCardsBuilder(IClassifiedCardsHelper classifiedCardsHelper)
        {
            _classifiedCardsHelper = classifiedCardsHelper;
        }

        public ClassifiedCards Build(IEnumerable<ICard> concernedCards, CardGroupQualityEnum quality, IEvaluationOptions options, IEnumerable<ICard> remainingCards = null)
        {
            if (concernedCards == null)
                return null;

            return new ClassifiedCards(options, _classifiedCardsHelper)
            {
                Quality = quality,
                ConcernedCards = concernedCards,
                RemainingCards = remainingCards ?? new ICard[0]
            };
        }
    }
}
