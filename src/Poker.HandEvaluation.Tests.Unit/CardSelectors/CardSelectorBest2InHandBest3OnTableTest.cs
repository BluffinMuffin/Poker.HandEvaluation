using System;
using System.Linq;
using AutoFixture;
using BluffinMuffin.Poker.HandEvaluation.CardSelectors;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;
using Com.Ericmas001.MsTest;
using Com.Ericmas001.MsTest.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.Poker.HandEvaluation.Tests.Unit.CardSelectors
{
    [TestClass]
    public class CardSelectorBest2InHandBest3OnTableTest : TestBase<CardSelectorBest2InHandBest3OnTable>
    {
        [TestClass]
        public class SelectCards : CardSelectorBest2InHandBest3OnTableTest
        {
            [TestMethod]
            public void When_PlayerIsNull_Expect_ArgumentNullException()
            {
                //Act
                Action act = () => TestInstance.SelectCards(null);

                //Assert
                act.Should().ThrowArgumentNullException("player");
            }
            [TestMethod]
            public void When_HappyPath_Expect_CorrectlyBuilt()
            {
                //Arrange
                var player = AutoFixture.Create<IPlayerCards>();

                var expected = AutoFixture.Freeze<ICardHelper>()
                                          .AllCombinations(player.HandCards, 2)
                                          .SelectMany(h => AutoFixture.Freeze<ICardHelper>()
                                                                      .AllCombinations(player.TableCards, 3)
                                                                      .Select(h.Concat));

                //Act
                var res = TestInstance.SelectCards(player);

                //Assert
                res.Should().BeEquivalentTo(expected);
            }
        }
    }
}
