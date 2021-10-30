using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public interface IQualityEvaluatorFactory
    {
        ClassifiedCards Evaluate(CardGroupQualityEnum quality, IEnumerable<ICard> cards, IEvaluationOptions options);
    }
    public class QualityEvaluatorFactory : IQualityEvaluatorFactory
    {
        private readonly QualityEvaluatorHighCard _qualityEvaluatorHighCard;
        private readonly QualityEvaluatorOnePair _qualityEvaluatorOnePair;
        private readonly QualityEvaluatorTwoPairs _qualityEvaluatorTwoPairs;
        private readonly QualityEvaluatorThreeOfAKind _qualityEvaluatorThreeOfAKind;
        private readonly QualityEvaluatorStraight _qualityEvaluatorStraight;
        private readonly QualityEvaluatorFlush _qualityEvaluatorFlush;
        private readonly QualityEvaluatorFullHouse _qualityEvaluatorFullHouse;
        private readonly QualityEvaluatorFourOfAKind _qualityEvaluatorFourOfAKind;
        private readonly QualityEvaluatorStraightFlush _qualityEvaluatorStraightFlush;
        private readonly QualityEvaluatorRoyalFlush _qualityEvaluatorRoyalFlush;

        public QualityEvaluatorFactory(QualityEvaluatorHighCard qualityEvaluatorHighCard,
                                       QualityEvaluatorOnePair qualityEvaluatorOnePair,
                                       QualityEvaluatorTwoPairs qualityEvaluatorTwoPairs,
                                       QualityEvaluatorThreeOfAKind qualityEvaluatorThreeOfAKind,
                                       QualityEvaluatorStraight qualityEvaluatorStraight,
                                       QualityEvaluatorFlush qualityEvaluatorFlush,
                                       QualityEvaluatorFullHouse qualityEvaluatorFullHouse,
                                       QualityEvaluatorFourOfAKind qualityEvaluatorFourOfAKind,
                                       QualityEvaluatorStraightFlush qualityEvaluatorStraightFlush,
                                       QualityEvaluatorRoyalFlush qualityEvaluatorRoyalFlush)
        {
            _qualityEvaluatorHighCard = qualityEvaluatorHighCard;
            _qualityEvaluatorOnePair = qualityEvaluatorOnePair;
            _qualityEvaluatorTwoPairs = qualityEvaluatorTwoPairs;
            _qualityEvaluatorThreeOfAKind = qualityEvaluatorThreeOfAKind;
            _qualityEvaluatorStraight = qualityEvaluatorStraight;
            _qualityEvaluatorFlush = qualityEvaluatorFlush;
            _qualityEvaluatorFullHouse = qualityEvaluatorFullHouse;
            _qualityEvaluatorFourOfAKind = qualityEvaluatorFourOfAKind;
            _qualityEvaluatorStraightFlush = qualityEvaluatorStraightFlush;
            _qualityEvaluatorRoyalFlush = qualityEvaluatorRoyalFlush;
        }
        public ClassifiedCards Evaluate(CardGroupQualityEnum quality, IEnumerable<ICard> cards, IEvaluationOptions options)
        {
            switch (quality)
            {
                case CardGroupQualityEnum.HighCard: return _qualityEvaluatorHighCard.Evaluate(cards, options);
                case CardGroupQualityEnum.OnePair: return _qualityEvaluatorOnePair.Evaluate(cards, options);
                case CardGroupQualityEnum.TwoPairs: return _qualityEvaluatorTwoPairs.Evaluate(cards, options);
                case CardGroupQualityEnum.ThreeOfAKind: return _qualityEvaluatorThreeOfAKind.Evaluate(cards, options);
                case CardGroupQualityEnum.Straight: return _qualityEvaluatorStraight.Evaluate(cards, options);
                case CardGroupQualityEnum.Flush: return _qualityEvaluatorFlush.Evaluate(cards, options);
                case CardGroupQualityEnum.FullHouse: return _qualityEvaluatorFullHouse.Evaluate(cards, options);
                case CardGroupQualityEnum.FourOfAKind: return _qualityEvaluatorFourOfAKind.Evaluate(cards, options);
                case CardGroupQualityEnum.StraightFlush: return _qualityEvaluatorStraightFlush.Evaluate(cards, options);
                case CardGroupQualityEnum.RoyalFlush: return _qualityEvaluatorRoyalFlush.Evaluate(cards, options);
                default:
                    throw new KeyNotFoundException($"Quality '{quality}' has no evaluator");
            }
        }
    }
}