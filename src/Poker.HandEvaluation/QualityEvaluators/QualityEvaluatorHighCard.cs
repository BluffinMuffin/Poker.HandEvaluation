using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public class QualityEvaluatorHighCard
    {
        private readonly IClassifiedCardsBuilder _classifiedCardsBuilder;

        public QualityEvaluatorHighCard(IClassifiedCardsBuilder classifiedCardsBuilder)
        {
            _classifiedCardsBuilder = classifiedCardsBuilder;
        }

        public ClassifiedCards Evaluate(IEnumerable<ICard> cards, IEvaluationOptions options)
        {
            var allCards = cards?.OrderByDescending(x => x).ToArray();
            if (allCards == null || !allCards.Any())
                throw new ArgumentNullException(nameof(cards));

            if (options == null) throw new ArgumentNullException(nameof(options));

            return _classifiedCardsBuilder.Build(allCards.Take(1), CardGroupQualityEnum.HighCard, options, allCards.Skip(1).Take(4));
        }
    }
}