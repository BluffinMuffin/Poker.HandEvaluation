using System;
using System.Linq;
using BluffinMuffin.Poker.HandEvaluation.CardSelectors;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.QualityEvaluators;

namespace BluffinMuffin.Poker.HandEvaluation.Builders
{
    public interface IClassifiedCardsOfPlayerBuilder
    {
        ClassifiedCardsOfPlayer<T> Build<T>(T player, IEvaluationOptions options) where T : IPlayerCards;
    }
    public class ClassifiedCardsOfPlayerBuilder : IClassifiedCardsOfPlayerBuilder
    {
        private readonly IQualityEvaluatorFactory _qualityEvaluatorFactory;
        private readonly ICardSelectorFactory _cardSelectorFactory;

        public ClassifiedCardsOfPlayerBuilder(IQualityEvaluatorFactory qualityEvaluatorFactory, ICardSelectorFactory cardSelectorFactory)
        {
            _qualityEvaluatorFactory = qualityEvaluatorFactory;
            _cardSelectorFactory = cardSelectorFactory;
        }

        public ClassifiedCardsOfPlayer<T> Build<T>(T player, IEvaluationOptions options) where T : IPlayerCards
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (options == null) throw new ArgumentNullException(nameof(options));

            return new ClassifiedCardsOfPlayer<T>
            {
                Player = player,
                ClassifiedCards = _cardSelectorFactory.SelectCards(options.CardSelector, player)
                                                      .SelectMany(sc => options.CardGroupQualityAvailable
                                                                               .Select(q => _qualityEvaluatorFactory.Evaluate(q, sc, options))
                                                                               .Where(x => x != null))
                                                      .ToArray()
            };
        }
    }
}
