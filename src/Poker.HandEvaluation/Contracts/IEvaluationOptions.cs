using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public interface IEvaluationOptions
    {
        bool SuitRankingActivated { get; }
        bool AceCanBeUsedAsOneInStraights { get; }
        IEnumerable<CardValueEnum> CardValuesUsed { get; }
        IEnumerable<CardGroupQualityEnum> CardGroupQualityAvailable { get; }
        EvaluationCardSelectorEnum CardSelector { get; }
        EvaluationHandRankerEnum HandRanker { get; }
    }
}
