using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.CardSelectors
{
    public interface ICardSelectorFactory
    {
        IEnumerable<IEnumerable<ICard>> SelectCards(EvaluationCardSelectorEnum selector, IPlayerCards player);
    }
    public class CardSelectorFactory : ICardSelectorFactory
    {
        private readonly CardSelectorAllCards _cardSelectorAllCards;
        private readonly CardSelectorBest2InHandBest3OnTable _cardSelectorBest2InHandBest3OnTable;
        private readonly CardSelectorOnlyHand _cardSelectorOnlyHand;

        public CardSelectorFactory(CardSelectorAllCards cardSelectorAllCards, CardSelectorBest2InHandBest3OnTable cardSelectorBest2InHandBest3OnTable, CardSelectorOnlyHand cardSelectorOnlyHand)
        {
            _cardSelectorAllCards = cardSelectorAllCards;
            _cardSelectorBest2InHandBest3OnTable = cardSelectorBest2InHandBest3OnTable;
            _cardSelectorOnlyHand = cardSelectorOnlyHand;
        }

        public IEnumerable<IEnumerable<ICard>> SelectCards(EvaluationCardSelectorEnum selector, IPlayerCards player)
        {
            switch (selector)
            {
                case EvaluationCardSelectorEnum.AllCards: return _cardSelectorAllCards.SelectCards(player);
                case EvaluationCardSelectorEnum.Best2InHandBest3OnTable: return _cardSelectorBest2InHandBest3OnTable.SelectCards(player);
                case EvaluationCardSelectorEnum.OnlyHand: return _cardSelectorOnlyHand.SelectCards(player);
                default:
                    throw new KeyNotFoundException($"Selector '{selector}' has no implementation");
            }
        }
    }
}