using System.Linq;
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

        public ClassifiedCardsOfPlayerBuilder(IQualityEvaluatorFactory qualityEvaluatorFactory)
        {
            _qualityEvaluatorFactory = qualityEvaluatorFactory;
        }

        public ClassifiedCardsOfPlayer<T> Build<T>(T player, IEvaluationOptions options) where T : IPlayerCards
        {
            return new ClassifiedCardsOfPlayer<T>
            {
                Player = player,
                ClassifiedCards = options.CardGroupQualityAvailable
                                         .Select(q => _qualityEvaluatorFactory.Evaluate(q, player, options))
                                         .Where(x => x != null)
                                         .ToArray()
            };
        }
    }
}
