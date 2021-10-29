using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Poker.Common.Contract;
using BluffinMuffin.Poker.HandEvaluation.Contracts;

namespace BluffinMuffin.Poker.HandEvaluation.CardSelectors
{
    public class CardSelectorBest2InHandBest3OnTable
    {
        public IEnumerable<IEnumerable<ICard>> SelectCards(IPlayerCards player)
        {
            var pc = player.HandCards.ToArray();
            var cc = player.TableCards.ToArray();
            for (int i = 0; i < pc.Length; ++i)
                for (int j = i + 1; j < pc.Length; ++j)
                    for (int a = 0; a < cc.Length; ++a)
                        for (int b = a + 1; b < cc.Length; ++b)
                            for (int c = b + 1; c < cc.Length; ++c)
                                yield return new[] { pc[i], pc[j], cc[a], cc[b], cc[c] };
        }
    }
}