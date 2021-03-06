using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using Com.Ericmas001.Common;

namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public class DefaultEvaluationOptions : IEvaluationOptions
    {
        public virtual bool SuitRankingActivated => false;
        public virtual bool FlushBeatsFullHouse => false;
        public virtual bool AceCanBeUsedAsOneInStraights => true;
        public virtual IEnumerable<CardValueEnum> CardValuesUsed => EnumUtil.AllValues<CardValueEnum>();
        public virtual IEnumerable<CardGroupQualityEnum> CardGroupQualityAvailable => EnumUtil.AllValues<CardGroupQualityEnum>();
        public virtual EvaluationCardSelectorEnum CardSelector => EvaluationCardSelectorEnum.AllCards;
    }
}