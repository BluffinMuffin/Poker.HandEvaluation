using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public class QualityEvaluatorTwoPairs
    {
        private readonly ICardGroupQualityHelper _cardGroupQualityHelper;
        private readonly IClassifiedCardsBuilder _classifiedCardsBuilder;

        public QualityEvaluatorTwoPairs(ICardGroupQualityHelper cardGroupQualityHelper, IClassifiedCardsBuilder classifiedCardsBuilder)
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

            var pairs = _cardGroupQualityHelper.AllPairs(allCards).ToArray();
            if (pairs.Length != 2)
                return null;

            var concerned = pairs[0].Concat(pairs[1]).ToArray();

            return _classifiedCardsBuilder.Build(concerned, CardGroupQualityEnum.TwoPairs, options, allCards.Except(concerned).OrderByDescending(x => x.Value).Take(1));
        }
    }
}