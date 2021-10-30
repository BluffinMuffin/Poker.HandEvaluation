using System;
using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public class QualityEvaluatorStraightFlush
    {
        private readonly ICardGroupQualityHelper _cardGroupQualityHelper;
        private readonly IClassifiedCardsBuilder _classifiedCardsBuilder;

        public QualityEvaluatorStraightFlush(ICardGroupQualityHelper cardGroupQualityHelper, IClassifiedCardsBuilder classifiedCardsBuilder)
        {
            _cardGroupQualityHelper = cardGroupQualityHelper;
            _classifiedCardsBuilder = classifiedCardsBuilder;
        }

        public ClassifiedCards Evaluate(IEnumerable<ICard> cards, IEvaluationOptions options)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));
            if (options == null) throw new ArgumentNullException(nameof(options));

            return _classifiedCardsBuilder.Build(_cardGroupQualityHelper.StraightIfExists(_cardGroupQualityHelper.FlushIfExists(cards), options.AceCanBeUsedAsOneInStraights), CardGroupQualityEnum.StraightFlush, options);
        }
    }
}