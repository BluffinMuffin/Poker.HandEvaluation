using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation
{
    public interface IPokerHandEvaluator
    {
        object EvaluateCardsOfPlayers(IEnumerable<IPlayerCards> players, IEvaluationOptions options = null);
    }
    public class PokerHandEvaluator : IPokerHandEvaluator
    {
        public object EvaluateCardsOfPlayers(IEnumerable<IPlayerCards> players, IEvaluationOptions options = null)
        {
            var allPlayers = players?.ToArray();
            if (allPlayers == null || !allPlayers.Any())
                throw new ArgumentNullException(nameof(players));

            var evaluationOptions = options ?? new DefaultEvaluationOptions();

            throw new System.NotImplementedException();
        }
    }
}
