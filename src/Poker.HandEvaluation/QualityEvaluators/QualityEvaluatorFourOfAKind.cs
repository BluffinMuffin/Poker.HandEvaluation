using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public class QualityEvaluatorFourOfAKind
    {
        private readonly ICardGroupQualityHelper _cardGroupQualityHelper;
        private readonly IClassifiedCardsBuilder _classifiedCardsBuilder;

        public QualityEvaluatorFourOfAKind(ICardGroupQualityHelper cardGroupQualityHelper, IClassifiedCardsBuilder classifiedCardsBuilder)
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

            var four = _cardGroupQualityHelper.FourOfAKindIfExists(allCards)?.ToArray();
            if (four == null)
                return null;

            return _classifiedCardsBuilder.Build(four, CardGroupQualityEnum.FourOfAKind, options, allCards.Except(four).OrderByDescending(x => x.Value).Take(1));
        }
    }
}