using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public class QualityEvaluatorFullHouse
    {
        private readonly ICardGroupQualityHelper _cardGroupQualityHelper;
        private readonly IClassifiedCardsBuilder _classifiedCardsBuilder;

        public QualityEvaluatorFullHouse(ICardGroupQualityHelper cardGroupQualityHelper, IClassifiedCardsBuilder classifiedCardsBuilder)
        {
            _cardGroupQualityHelper = cardGroupQualityHelper;
            _classifiedCardsBuilder = classifiedCardsBuilder;
        }

        public ClassifiedCards Evaluate(IEnumerable<ICard> cards, IEvaluationOptions options)
        {
            var allCards = cards?.ToArray();
            if (allCards == null || !allCards.Any())
                throw new ArgumentNullException(nameof(cards));

            if (options == null) throw new ArgumentNullException(nameof(options));

            var three = _cardGroupQualityHelper.ThreeOfAKindIfExists(allCards)?.ToArray();
            var two = _cardGroupQualityHelper.AllPairs(allCards).SingleOrDefault()?.ToArray();

            if (three == null || two == null)
                return null;

            return _classifiedCardsBuilder.Build(three.Concat(two), CardGroupQualityEnum.FullHouse, options);
        }
    }
}