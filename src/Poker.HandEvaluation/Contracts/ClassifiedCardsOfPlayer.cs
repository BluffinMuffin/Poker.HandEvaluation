using System.Collections.Generic;

namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public class ClassifiedCardsOfPlayer<T>
    {
        public T Player { get; set; }
        public IEnumerable<ClassifiedCards> ClassifiedCards { get; set; }
    }
}