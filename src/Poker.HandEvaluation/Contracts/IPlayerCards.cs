using System.Collections.Generic;
using Poker.Common.Contract;

namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public interface IPlayerCards
    {
        IEnumerable<ICard> HandCards { get; }
        IEnumerable<ICard> TableCards { get; }
    }
}
