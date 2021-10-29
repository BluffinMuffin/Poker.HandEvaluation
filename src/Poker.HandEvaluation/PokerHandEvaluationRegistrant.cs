using System.Diagnostics.CodeAnalysis;
using Com.Ericmas001.DependencyInjection.Registrants;

namespace BluffinMuffin.Poker.HandEvaluation
{
    [ExcludeFromCodeCoverage]
    public class PokerHandEvaluationRegistrant : AbstractRegistrant
    {
        protected override void RegisterEverything()
        {
            Register<IPokerHandEvaluator, PokerHandEvaluator>();
        }
    }
}
