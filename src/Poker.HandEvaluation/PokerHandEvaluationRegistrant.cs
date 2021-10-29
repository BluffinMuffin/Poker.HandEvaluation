using System.Diagnostics.CodeAnalysis;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.CardSelectors;
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
            Register<IClassifiedCardsBuilder, ClassifiedCardsBuilder>();
            Register<IClassifiedCardsOfPlayerBuilder, ClassifiedCardsOfPlayerBuilder>();

            Register<ICardSelectorFactory, CardSelectorFactory>();
            Register<CardSelectorAllCards>();
            Register<CardSelectorBest2InHandBest3OnTable>();
            Register<CardSelectorOnlyHand>();

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
