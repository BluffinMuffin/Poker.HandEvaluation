using System.Collections.Generic;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.QualityEvaluators
{
    public interface IQualityEvaluatorFactory
    {
        ClassifiedCards Evaluate(CardGroupQualityEnum quality, IPlayerCards player, IEvaluationOptions options);
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

        public QualityEvaluatorFactory(QualityEvaluatorHighCard qualityEvaluatorHighCard,
                                       QualityEvaluatorOnePair qualityEvaluatorOnePair,
                                       QualityEvaluatorTwoPairs qualityEvaluatorTwoPairs,
                                       QualityEvaluatorThreeOfAKind qualityEvaluatorThreeOfAKind,
                                       QualityEvaluatorStraight qualityEvaluatorStraight,
                                       QualityEvaluatorFlush qualityEvaluatorFlush,
                                       QualityEvaluatorFullHouse qualityEvaluatorFullHouse,
                                       QualityEvaluatorFourOfAKind qualityEvaluatorFourOfAKind,
                                       QualityEvaluatorStraightFlush qualityEvaluatorStraightFlush)
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
        }
        public ClassifiedCards Evaluate(CardGroupQualityEnum quality, IPlayerCards player, IEvaluationOptions options)
        {
            switch (quality)
            {
                case CardGroupQualityEnum.HighCard: return _qualityEvaluatorHighCard.Evaluate(player, options);
                case CardGroupQualityEnum.OnePair: return _qualityEvaluatorOnePair.Evaluate(player, options);
                case CardGroupQualityEnum.TwoPairs: return _qualityEvaluatorTwoPairs.Evaluate(player, options);
                case CardGroupQualityEnum.ThreeOfAKind: return _qualityEvaluatorThreeOfAKind.Evaluate(player, options);
                case CardGroupQualityEnum.Straight: return _qualityEvaluatorStraight.Evaluate(player, options);
                case CardGroupQualityEnum.Flush: return _qualityEvaluatorFlush.Evaluate(player, options);
                case CardGroupQualityEnum.FullHouse: return _qualityEvaluatorFullHouse.Evaluate(player, options);
                case CardGroupQualityEnum.FourOfAKind: return _qualityEvaluatorFourOfAKind.Evaluate(player, options);
                case CardGroupQualityEnum.StraightFlush: return _qualityEvaluatorStraightFlush.Evaluate(player, options);
                default:
                    throw new KeyNotFoundException($"Quality '{quality}' has no evaluator");
            }
        }
    }
}