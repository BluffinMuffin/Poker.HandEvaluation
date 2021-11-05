using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.CardSelectors;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Helpers;
using Com.Ericmas001.MsTest;
using Com.Ericmas001.MsTest.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BluffinMuffin.Poker.HandEvaluation.Tests.Unit.CardSelectors
{
    [TestClass]
    public class CardSelectorAllCardsTest : TestBase<CardSelectorAllCards>
    {
        [TestClass]
        public class SelectCards : CardSelectorAllCardsTest
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
                var allCards = AutoFixture.CreateMany<ICard>(10).ToList();
                var player = AutoFixture.Create<IPlayerCards>();
                player.HandCards.Returns(allCards.Take(5));
                player.TableCards.Returns(allCards.Skip(5).Take(5));

                var expected = AutoFixture.CreateMany<IEnumerable<ICard>>().ToList();

                AutoFixture.Freeze<ICardHelper>()
                           .AllCombinations(Arg.Is<IEnumerable<ICard>>(x => x.SequenceEqual(allCards)), 5)
                           .Returns(expected);

                //Act
                var res = TestInstance.SelectCards(player);

                //Assert
                res.Should().BeEquivalentTo(expected);
            }
        }
    }
}
