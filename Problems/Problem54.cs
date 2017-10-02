using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=54
    ///
    /// analyse:
    /// 
    /// performance improvements:
    /// 
    /// </summary>
    class Problem54 : Helper, IProblem
    {
        string[][] player1 = getHand("poker.txt", 0);
        string[][] player2 = getHand("poker.txt", 5);

        public double Execute()
        {
            long sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (Winner(player1[i], player2[i])) sum++;
            }
            return sum;
        }

        private bool Winner(string[] p1, string[] p2)
        {
            return Hand(p1) > Hand(p2);
        }
        enum Rank
        {
            HighCard,       // Highest value card. 
            OnePair,        // Two cards of the same value. 
            TwoPairs,       // Two different pairs. 
            ThreeofaKind,   // Three cards of the same value. 
            Straight,       // All cards are consecutive values. 
            Flush,          // All cards of the same suit. 
            FullHouse,      // Three of a kind and a pair. 
            FourofaKind,    // Four cards of the same value. 
            StraightFlush,  // All cards are consecutive values of same suit. 
            RoyalFlush,     // Ten, Jack, Queen, King, Ace, in same suit. 
        }
        private int Hand(string[] player)
        {
            var suit = player[0][1];
            var highCard = player[4][0];
            var cards = (from card in player select card[0]).ToArray();
            var flush = (from card in player select card[1]).All(c => c==suit);
            return 0;
        }
        private static string[][] getHand(string fileName, int skip)
        {
            return (from lines in File.ReadAllLines(fileName)
                    select (from bytes in (lines.Trim().Split(' ')).Skip(skip).Take(5)
                            orderby bytes
                            select bytes).ToArray()).ToArray();
        }
    }
}