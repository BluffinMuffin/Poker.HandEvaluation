using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public class QualityEvaluatorOnePair
    {
        private readonly ICardGroupQualityHelper _cardGroupQualityHelper;
        private readonly IClassifiedCardsBuilder _classifiedCardsBuilder;

        public QualityEvaluatorOnePair(ICardGroupQualityHelper cardGroupQualityHelper, IClassifiedCardsBuilder classifiedCardsBuilder)
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

            var two = _cardGroupQualityHelper.AllPairs(allCards).FirstOrDefault()?.ToArray();

            if (two == null)
                return null;

            return _classifiedCardsBuilder.Build(two, CardGroupQualityEnum.OnePair, options, allCards.Except(two).OrderByDescending(x => x.Value).Take(3));
        }
    }
}