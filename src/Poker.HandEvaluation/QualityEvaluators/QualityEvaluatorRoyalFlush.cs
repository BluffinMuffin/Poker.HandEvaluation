using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public class QualityEvaluatorRoyalFlush
    {
        private readonly ICardGroupQualityHelper _cardGroupQualityHelper;
        private readonly IClassifiedCardsBuilder _classifiedCardsBuilder;

        public QualityEvaluatorRoyalFlush(ICardGroupQualityHelper cardGroupQualityHelper, IClassifiedCardsBuilder classifiedCardsBuilder)
        {
            _cardGroupQualityHelper = cardGroupQualityHelper;
            _classifiedCardsBuilder = classifiedCardsBuilder;
        }

        public ClassifiedCards Evaluate(IEnumerable<ICard> cards, IEvaluationOptions options)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));
            if (options == null) throw new ArgumentNullException(nameof(options));

            var straightflush = _cardGroupQualityHelper.StraightIfExists(_cardGroupQualityHelper.FlushIfExists(cards), options.AceCanBeUsedAsOneInStraights)?.ToArray();
            if (straightflush?[0].Value != CardValueEnum.Ace)
                return null;
            return _classifiedCardsBuilder.Build(straightflush, CardGroupQualityEnum.RoyalFlush, options);
        }
    }
}