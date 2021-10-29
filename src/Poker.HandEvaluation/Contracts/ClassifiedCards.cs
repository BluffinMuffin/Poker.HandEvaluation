using System;
using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Helpers;

namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public class ClassifiedCards : IComparer<ClassifiedCards>, IComparable<ClassifiedCards>
    {
        private readonly IEvaluationOptions _options;
        private readonly IClassifiedCardsHelper _classifiedCardsHelper;
        public CardGroupQualityEnum Quality { get; set; }
        public IEnumerable<ICard> Cards { get; set; }

        public ClassifiedCards(IEvaluationOptions options, IClassifiedCardsHelper classifiedCardsHelper)
        {
            _options = options;
            _classifiedCardsHelper = classifiedCardsHelper;
        }

        public int Compare(ClassifiedCards x, ClassifiedCards y) => _classifiedCardsHelper.Compare(x, y, _options);

        public int CompareTo(ClassifiedCards other) => _classifiedCardsHelper.Compare(this, other, _options);
    }
}