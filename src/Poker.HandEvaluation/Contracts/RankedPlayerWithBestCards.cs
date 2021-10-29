namespace BluffinMuffin.Poker.HandEvaluation.Contracts
{
    public class RankedPlayerWithBestCards<T> : BestCardsOfPlayer<T>
    {
        public int Rank { get; set; }
    }
}