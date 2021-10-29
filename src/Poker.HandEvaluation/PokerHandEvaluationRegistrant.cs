using System.Diagnostics.CodeAnalysis;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Helpers;
using BluffinMuffin.Poker.HandEvaluation.QualityEvaluators;
using BluffinMuffin.Poker.HandEvaluation.Services;
using Com.Ericmas001.DependencyInjection.Registrants;

namespace BluffinMuffin.Poker.HandEvaluation
{
    [ExcludeFromCodeCoverage]
    public class PokerHandEvaluationRegistrant : AbstractRegistrant
    {
        protected override void RegisterEverything()
        {
            Register<IPokerHandEvaluator, PokerHandEvaluator>();

            Register<IBestCardsOfPlayerBuilder, BestCardsOfPlayerBuilder>();
            Register<IClassifiedCardsOfPlayerBuilder, ClassifiedCardsOfPlayerBuilder>();

            Register<IClassifiedCardsHelper, ClassifiedCardsHelper>();
            Register<ICardGroupQualityHelper, CardGroupQualityHelper>();
            Register<ICardHelper, CardHelper>();

            Register<IQualityEvaluatorFactory, QualityEvaluatorFactory>();
            Register<QualityEvaluatorFlush>();
            Register<QualityEvaluatorFourOfAKind>();
            Register<QualityEvaluatorFullHouse>();
            Register<QualityEvaluatorHighCard>();
            Register<QualityEvaluatorOnePair>();
            Register<QualityEvaluatorStraight>();
            Register<QualityEvaluatorStraightFlush>();
            Register<QualityEvaluatorThreeOfAKind>();
            Register<QualityEvaluatorTwoPairs>();

            Register<IPlayerService, PlayerService>();
        }
    }
}
