using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using BluffinMuffin.Poker.Common;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.Common.Helpers;
using BluffinMuffin.Poker.HandEvaluation;
using BluffinMuffin.Poker.HandEvaluation.Contracts;
using BluffinMuffin.Poker.HandEvaluation.Services;
using Com.Ericmas001.DependencyInjection.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Poker.HandEvaluation.DatasetTest
{
    [TestClass]
    public class EnormousTest
    {
        private UnityContainer _container;
        private IStringCardHelper _stringCardHelper;
        private IPlayerService _playerService;
        public EnormousTest()
        {
            _container = new UnityContainer();
            new PokerCommonRegistrant().RegisterTypes(_container, null);
            new PokerHandEvaluationRegistrant().RegisterTypes(_container, null);
            _stringCardHelper = _container.Resolve<IStringCardHelper>();
            _playerService = _container.Resolve<IPlayerService>();
        }
        private static readonly string[] _values = { "", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private static readonly string[] _suits = { "", "H", "S", "D", "C" };

        private ICard Card(string[] sections, int i)
        {
            return _stringCardHelper.StringToCard(_values[int.Parse(sections[i + 1])] + _suits[int.Parse(sections[i])]);
        }

        [TestMethod]
        public void Test200KCombinations()
        {
            const int DIVISOR = 5;
            var coolNumber = RandomNumberGenerator.GetInt32(DIVISOR);
            var options = new DefaultEvaluationOptions();
            var exceptions = new List<Exception>();
            var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data", "poker-hand-testing.data"));
            for (int i = 0; i < lines.Length; ++i)
            {
                if (i % DIVISOR != coolNumber)
                    continue;

                var sections = lines[i].Split(',');
                var cards = new[] { Card(sections, 0), Card(sections, 2), Card(sections, 4), Card(sections, 6), Card(sections, 8) };
                var expected = (CardGroupQualityEnum)int.Parse(sections[10]);
                try
                {
                    var sorted = _playerService.Sort(new[] { new Player(cards) }, options);
                    Assert.AreEqual(expected, sorted.Single().BestCards.Quality);
                }
                catch (Exception e)
                {
                    exceptions.Add(new Exception($"{Environment.NewLine}{Environment.NewLine}>> Test [{string.Join(",", cards.Select(x => _stringCardHelper.CardToString(x)))}] failed to output '{expected}'{Environment.NewLine}{e}"));
                }

                if (exceptions.Count >= 25)
                    break;
            }

            if (exceptions.Any())
                throw new AggregateException($"{exceptions.Count} tests failed", exceptions);
        }
    }

    public class Player : IPlayerCards
    {
        public Player(IEnumerable<ICard> handCards)
        {
            HandCards = handCards;
        }

        public IEnumerable<ICard> HandCards { get; }
        public IEnumerable<ICard> TableCards => new ICard[0];
    }
}
