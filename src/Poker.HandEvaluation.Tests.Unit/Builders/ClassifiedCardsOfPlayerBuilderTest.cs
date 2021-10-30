using System;
using AutoFixture;
using BluffinMuffin.Poker.HandEvaluation.Builders;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using Com.Ericmas001.MsTest;
using Com.Ericmas001.MsTest.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.Poker.HandEvaluation.Tests.Unit.Builders
{
    [TestClass]
    public class ClassifiedCardsOfPlayerBuilderTest : TestBase<ClassifiedCardsOfPlayerBuilder>
    {
        [TestClass]
        public class Build : ClassifiedCardsOfPlayerBuilderTest
        {
            [TestMethod]
            public void When_PlayerIsNull_Expect_ArgumentNullException()
            {
                //Act
                Action act = () => TestInstance.Build((IPlayerCards)null, AutoFixture.Create<IEvaluationOptions>());

                //Assert
                act.Should().ThrowArgumentNullException("player");
            }
            [TestMethod]
            public void When_ÔptionsIsNull_Expect_ArgumentNullException()
            {
                //Act
                Action act = () => TestInstance.Build(AutoFixture.Create<IPlayerCards>(), null);

                //Assert
                act.Should().ThrowArgumentNullException("options");
            }
            [TestMethod]
            public void When_NullResultsFromEvaluators_Expect_TheyAreExcluded()
            {
                //Arrange


                //Act


                //Assert
                Assert.Inconclusive("TODO");
            }
            [TestMethod]
            public void When_HappyPath_Expect_CorrectlyBuilt()
            {
                //Arrange


                //Act


                //Assert
                Assert.Inconclusive("TODO");
            }
        }
    }
}
