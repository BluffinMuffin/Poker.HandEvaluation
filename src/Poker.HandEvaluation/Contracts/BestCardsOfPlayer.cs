namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public class BestCardsOfPlayer<T>
    {
        public T Player { get; set; }
        public ClassifiedCards BestCards { get; set; }
    }
}