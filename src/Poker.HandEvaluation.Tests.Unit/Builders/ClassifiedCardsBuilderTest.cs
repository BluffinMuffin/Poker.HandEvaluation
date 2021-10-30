using System;
using System.Linq;
using AutoFixture;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using Com.Ericmas001.MsTest;
using Com.Ericmas001.MsTest.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.Poker.HandEvaluation.Tests.Unit.Builders
{
    [TestClass]
    public class ClassifiedCardsBuilderTest : TestBase<ClassifiedCardsBuilder>
    {
        [TestClass]
        public class Build : ClassifiedCardsBuilderTest
        {
            [TestMethod]
            public void When_ConcernedIsNull_Expect_Null()
            {
                //Act
                var res = TestInstance.Build(null, AutoFixture.Create<CardGroupQualityEnum>(), AutoFixture.Create<IEvaluationOptions>(), AutoFixture.CreateMany<ICard>());

                //Assert
                res.Should().BeNull();
            }
            [TestMethod]
            public void When_OptionsIsNull_Expect_ArgumentNullException()
            {
                //Act
                Action act = () => TestInstance.Build(AutoFixture.CreateMany<ICard>(), AutoFixture.Create<CardGroupQualityEnum>(), null, AutoFixture.CreateMany<ICard>());

                //Assert
                act.Should().ThrowArgumentNullException("options");
            }
            [TestMethod]
            public void When_RemainingIsNull_Expect_CorrectlyBuiltWithOnlyConcerned()
            {
                //Arrange
                var concerned = AutoFixture.CreateMany<ICard>().ToList();

                //Act
                var res = TestInstance.Build(concerned, AutoFixture.Create<CardGroupQualityEnum>(), AutoFixture.Create<IEvaluationOptions>());

                //Assert
                res.Cards.Should().BeEquivalentTo(concerned);
            }
            [TestMethod]
            public void When_HappyPath_Expect_CorrectlyBuilt()
            {
                //Arrange
                var concerned = AutoFixture.CreateMany<ICard>().ToList();
                var remaining = AutoFixture.CreateMany<ICard>().ToList();
                var expected = new
                {
                    Quality = AutoFixture.Create<CardGroupQualityEnum>(),
                    Cards = concerned.Concat(remaining)
                };

                //Act
                var res = TestInstance.Build(concerned, expected.Quality, AutoFixture.Create<IEvaluationOptions>(), remaining);

                //Assert
                res.Should().BeEquivalentTo(expected);
                expected.Should().BeEquivalentTo(res);
            }
        }
    }
}
