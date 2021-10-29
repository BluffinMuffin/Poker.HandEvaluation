using System.Collections.Generic;
using Com.Ericmas001.Common;
using Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public class DefaultEvaluationOptions : IEvaluationOptions
    {
        public virtual bool SuitRankingActivated => false;
        public virtual bool AceCanBeUsedAsOneInStraights => true;
        public virtual IEnumerable<CardValueEnum> CardValuesUsed => EnumUtil.AllValues<CardValueEnum>();
        public virtual IEnumerable<CardGroupQualityEnum> CardGroupQualityAvailable => EnumUtil.AllValues<CardGroupQualityEnum>();
        public virtual EvaluationCardSelectorEnum CardSelector => EvaluationCardSelectorEnum.AllCards;
        public virtual EvaluationHandRankerEnum HandRanker => EvaluationHandRankerEnum.Standard;
    }
}