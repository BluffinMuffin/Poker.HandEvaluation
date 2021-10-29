using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public interface IEvaluationOptions
    {
        bool SuitRankingActivated { get; }
        bool FlushBeatsFullHouse { get; }
        bool AceCanBeUsedAsOneInStraights { get; }
        EvaluationCardSelectorEnum CardSelector { get; }
        IEnumerable<CardValueEnum> CardValuesUsed { get; }
        IEnumerable<CardGroupQualityEnum> CardGroupQualityAvailable { get; }
    }
}
