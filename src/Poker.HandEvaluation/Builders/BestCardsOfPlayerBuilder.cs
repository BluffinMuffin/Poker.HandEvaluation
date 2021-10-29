using System.Linq;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.Builders
{
    public interface IBestCardsOfPlayerBuilder
    {
        BestCardsOfPlayer<T> Build<T>(ClassifiedCardsOfPlayer<T> pcc) where T : IPlayerCards;
    }
    public class BestCardsOfPlayerBuilder : IBestCardsOfPlayerBuilder
    {
        public BestCardsOfPlayer<T> Build<T>(ClassifiedCardsOfPlayer<T> pcc) where T : IPlayerCards
        {
            return new BestCardsOfPlayer<T>
            {
                Player = pcc.Player,
                BestCards = pcc.ClassifiedCards.OrderByDescending(cc => cc).FirstOrDefault()
            };
        }
    }
}
