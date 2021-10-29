using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.Services
{
    public interface IPlayerService
    {
        IEnumerable<BestCardsOfPlayer<T>> Sort<T>(IEnumerable<T> players, IEvaluationOptions options) where T : IPlayerCards;
        IEnumerable<RankedPlayerWithBestCards<T>> Rank<T>(IEnumerable<BestCardsOfPlayer<T>> players) where T : IPlayerCards;
    }
    public class PlayerService : IPlayerService
    {
        private readonly IBestCardsOfPlayerBuilder _bestCardsOfPlayerBuilder;
        private readonly IClassifiedCardsOfPlayerBuilder _classifiedCardsOfPlayerBuilder;

        public PlayerService(IBestCardsOfPlayerBuilder bestCardsOfPlayerBuilder, IClassifiedCardsOfPlayerBuilder classifiedCardsOfPlayerBuilder)
        {
            _bestCardsOfPlayerBuilder = bestCardsOfPlayerBuilder;
            _classifiedCardsOfPlayerBuilder = classifiedCardsOfPlayerBuilder;
        }

        public IEnumerable<BestCardsOfPlayer<T>> Sort<T>(IEnumerable<T> players, IEvaluationOptions options) where T : IPlayerCards
        {
            var allPlayers = players?.ToArray();
            if (allPlayers == null || !allPlayers.Any())
                throw new ArgumentNullException(nameof(players));

            if (options == null) throw new ArgumentNullException(nameof(options));

            return allPlayers.Select(p => _classifiedCardsOfPlayerBuilder.Build(p, options))
                                          .Select(_bestCardsOfPlayerBuilder.Build)
                                          .OrderByDescending(x => x.BestCards)
                                          .ToArray();
        }

        public IEnumerable<RankedPlayerWithBestCards<T>> Rank<T>(IEnumerable<BestCardsOfPlayer<T>> players) where T : IPlayerCards
        {
            var sortedPlayers = players?.ToArray();
            if (sortedPlayers == null || !sortedPlayers.Any())
                throw new ArgumentNullException(nameof(players));

            var rank = 1;
            for (int i = 0; i < sortedPlayers.Length; ++i)
            {
                var player = sortedPlayers[i];
                if (i > 0 && player.BestCards.CompareTo(sortedPlayers[i - 1].BestCards) < 0)
                    rank++;
                yield return new RankedPlayerWithBestCards<T>
                {
                    Player = player.Player,
                    BestCards = player.BestCards,
                    Rank = rank
                };
            }
        }
    }
}
