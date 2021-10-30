using System;
using AutoFixture;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;
using Com.Ericmas001.MsTest;
using Com.Ericmas001.MsTest.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BluffinMuffin.Poker.HandEvaluation.Tests.Unit.Builders
{
    [TestClass]
    public class BestCardsOfPlayerBuilderTest : TestBase<BestCardsOfPlayerBuilder>
    {
        [TestClass]
        public class Build : BestCardsOfPlayerBuilderTest
        {
            [TestMethod]
            public void When_ClassifiedCardsOfPlayerIsNull_Expect_ArgumentNullException()
            {
                //Act
                Action act = () => TestInstance.Build<IPlayerCards>(null);

                //Assert
                act.Should().ThrowArgumentNullException("classifiedCardsOfPlayer");
            }
            [TestMethod]
            public void When_MultipleClassifiedCards_Expect_BestCardToHaveTheBest()
            {
                //Arrange
                AutoFixture.Freeze<IClassifiedCardsHelper>()
                           .Compare(Arg.Any<ClassifiedCards>(), Arg.Any<ClassifiedCards>(), Arg.Any<IEvaluationOptions>())
                           .Returns(x => x.ArgAt<ClassifiedCards>(0).Quality.CompareTo(x.ArgAt<ClassifiedCards>(1).Quality));

                var best = AutoFixture.Build<ClassifiedCards>().With(x => x.Quality, CardGroupQualityEnum.RoyalFlush).Create();
                var medium = AutoFixture.Build<ClassifiedCards>().With(x => x.Quality, CardGroupQualityEnum.ThreeOfAKind).Create();
                var lowest = AutoFixture.Build<ClassifiedCards>().With(x => x.Quality, CardGroupQualityEnum.HighCard).Create();
                var pcc = AutoFixture.Build<ClassifiedCardsOfPlayer<IPlayerCards>>()
                                     .With(x => x.ClassifiedCards, new[] { medium, best, lowest })
                                     .Create();

                //Act
                var res = TestInstance.Build(pcc);

                //Assert
                res.BestCards.Should().Be(best);
            }
            [TestMethod]
            public void When_NoClassifiedCards_Expect_BestCardsToBeNull()
            {
                //Arrange
                var pcc = AutoFixture.Build<ClassifiedCardsOfPlayer<IPlayerCards>>()
                                     .With(x => x.ClassifiedCards, new ClassifiedCards[0])
                                     .Create();

                //Act
                var res = TestInstance.Build(pcc);

                //Assert
                res.BestCards.Should().BeNull();
            }
            [TestMethod]
            public void When_HappyPath_Expect_CorrectlyBuilt()
            {
                //Arrange
                var expected = new
                {
                    Player = AutoFixture.Create<IPlayerCards>(),
                    BestCards = AutoFixture.Create<ClassifiedCards>()
                };
                var pcc = AutoFixture.Build<ClassifiedCardsOfPlayer<IPlayerCards>>()
                                     .With(x => x.Player, expected.Player)
                                     .With(x => x.ClassifiedCards, new[] { expected.BestCards })
                                     .Create();

                //Act
                var res = TestInstance.Build(pcc);

                //Assert
                res.Should().BeEquivalentTo(expected);
                expected.Should().BeEquivalentTo(res);
            }
        }
    }
}
