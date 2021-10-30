using System;
using System.Linq;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.Builders
{
    public interface IBestCardsOfPlayerBuilder
    {
        BestCardsOfPlayer<T> Build<T>(ClassifiedCardsOfPlayer<T> classifiedCardsOfPlayer) where T : IPlayerCards;
    }
    public class BestCardsOfPlayerBuilder : IBestCardsOfPlayerBuilder
    {
        public BestCardsOfPlayer<T> Build<T>(ClassifiedCardsOfPlayer<T> classifiedCardsOfPlayer) where T : IPlayerCards
        {
            if (classifiedCardsOfPlayer == null) throw new ArgumentNullException(nameof(classifiedCardsOfPlayer));

            return new BestCardsOfPlayer<T>
            {
                Player = classifiedCardsOfPlayer.Player,
                BestCards = classifiedCardsOfPlayer.ClassifiedCards.OrderByDescending(cc => cc).FirstOrDefault()
            };
        }
    }
}
