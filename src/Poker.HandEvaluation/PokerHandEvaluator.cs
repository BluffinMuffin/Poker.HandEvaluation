using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Services;

namespace BluffinMuffin.Poker.HandEvaluation
{
    public interface IPokerHandEvaluator
    {
        IEnumerable<RankedPlayerWithBestCards<T>> EvaluateCardsOfPlayers<T>(IEnumerable<T> players, IEvaluationOptions options = null) where T : IPlayerCards;
    }
    public class PokerHandEvaluator : IPokerHandEvaluator
    {
        private readonly IPlayerService _playerService;

        public PokerHandEvaluator(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IEnumerable<RankedPlayerWithBestCards<T>> EvaluateCardsOfPlayers<T>(IEnumerable<T> players, IEvaluationOptions options = null) where T : IPlayerCards
        {
            var allPlayers = players?.ToArray();
            if (allPlayers == null || !allPlayers.Any())
                throw new ArgumentNullException(nameof(players));

            return _playerService.Rank(_playerService.Sort(allPlayers, options ?? new DefaultEvaluationOptions()));
        }
    }
}
