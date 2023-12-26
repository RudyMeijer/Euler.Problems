using System.Diagnostics;
namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=54
    ///
    /// analyse:
    /// 
    /// Read poker file and sort cards in ascending order.
    /// In order to sort cards translate cards Ten, Jack, Queen, King, Ace to :;<=> 
    /// 
    /// performance improvements:
    /// 
    /// </summary>
    class Problem54 : Helper, IProblem
    {
        string[][] player1 = ReadFile("text/poker.txt", 0);
        string[][] player2 = ReadFile("text/poker.txt", 5);

        public double Execute()
        {
            var sum = 0;
            for (int i = 0; i < 1000; i++) if (Hand(player1[i]) > Hand(player2[i])) sum++;
            return sum;
        }

        private Rank Hand(string[] player)
        {
            Rank rank = Rank.HighCard;
            var cards = (from card in player select card[0]).ToArray();
            var flush = (from card in player select card[1]).All(c => c == player[0][1]);
            char highestCard = cards[4];
            int cnt = 1;
            for (int i = 0; i < 4; i += cnt)
            {
                cnt = 1;
                for (int j = i + 1; j < 5; j++) if (cards[i] == cards[j]) cnt++; else break;

                if (cnt == 2)
                {
                    if (rank == Rank.OnePair) rank = Rank.TwoPairs;
                    if (rank == Rank.HighCard) rank = Rank.OnePair;
                    if (rank == Rank.ThreeofaKind) rank = Rank.FullHouse;
                    highestCard = cards[i];
                }
                if (cnt == 3)
                {
                    if (rank == Rank.HighCard) rank = Rank.ThreeofaKind;
                    if (rank == Rank.OnePair) rank = Rank.FullHouse;
                }
                if (cnt >= 4) rank = Rank.FourofaKind;
            }
            if (rank == Rank.HighCard && Consecutive(cards))
            {
                rank = (flush) ? (highestCard == '>') ? Rank.RoyalFlush : Rank.StraightFlush : Rank.Straight;
            }
            if (flush && rank < Rank.Flush) rank = Rank.Flush;
            return rank + highestCard;
        }

        public enum Rank
        {
            HighCard = 100,       // Highest value card. 
            OnePair = 200,        // Two cards of the same value. 
            TwoPairs = 300,       // Two different pairs. 
            ThreeofaKind = 400,   // Three cards of the same value. 
            Straight = 500,       // All cards are consecutive values. 
            Flush = 600,          // All cards of the same suit. 
            FullHouse = 700,      // Three of a kind and a pair. 
            FourofaKind = 800,    // Four cards of the same value. 
            StraightFlush = 900,  // All cards are consecutive values of same suit. 
            RoyalFlush = 1000     // Ten, Jack, Queen, King, Ace, in same suit. 
        }
        private static bool Consecutive(char[] cards)
        {
            for (int i = 1; i < 5; i++) if (cards[i] != cards[i - 1] + 1) return false;
            return true;
        }
        private static string[][] ReadFile(string fileName, int skip)
        {
            return (from lines in File.ReadAllLines(fileName)
                    select (from bytes in (lines.Trim().Split(' ')).Skip(skip).Take(5)
                            let card = Translate(bytes[0]) + bytes[1].ToString()
                            orderby card[0]
                            select card).ToArray()).ToArray();
        }
        //
        // In order to sort cards translate cards Ten, Jack, Queen, King, Ace to :;<=> 
        //                    
        private static char Translate(char card)
        {
            if (card <= '9') return card;
            return (char)(':' + "TJQKA".IndexOf(card));// :;<=>
        }
        public new void UnitTest()
        {
            string[] HighCard = { "1C", "3H", "4H", "5H", "6H" };// Highest value card.
            string[] OnePair = { "2C", "2H", "4H", "5H", "6H" };// Two cards of the same value.
            string[] TwoPairs = { "2C", "2H", "4H", "5H", "5H" };// Two different pairs.
            string[] ThreeofaKind = { "3C", "3H", "3H", "5H", "6H" };// Three cards of the same value.
            string[] Straight = { "2C", "3H", "4H", "5H", "6H" };// All cards are consecutive values.
            string[] Flush = { "1H", "3H", "4H", "5H", "6H" };// All cards of the same suit. 
            string[] FullHouse = { "3H", "3H", "3H", "5H", "5H" };// Three of a kind and a pair. 
            string[] FourofaKind = { "4H", "4H", "4H", "4H", "6H" };// Four cards of the same value. 
            string[] StraightFlush = { "2H", "3H", "4H", "5H", "6H" };// All cards are consecutive values of same suit. 
            string[] RoyalFlush = { ":H", ";H", "<H", "=H", ">H" };// Ten, Jack, Queen, King, Ace, in same suit.

            Debug.Assert(Hand(HighCard) == Rank.HighCard + '6', " Ranking <> " + Rank.HighCard);
            Debug.Assert(Hand(OnePair) == Rank.OnePair + '2', " Ranking <> " + Rank.OnePair);
            Debug.Assert(Hand(TwoPairs) == Rank.TwoPairs + '5', " Ranking <> " + Rank.TwoPairs);
            Debug.Assert(Hand(ThreeofaKind) == Rank.ThreeofaKind + '6', " Ranking <> " + Rank.ThreeofaKind);
            Debug.Assert(Hand(Straight) == Rank.Straight + '6', " Ranking <> " + Rank.Straight);
            Debug.Assert(Hand(Flush) == Rank.Flush + '6', " Ranking <> " + Rank.Flush);
            Debug.Assert(Hand(FullHouse) == Rank.FullHouse + '5', " Ranking <> " + Rank.FullHouse);
            Debug.Assert(Hand(FourofaKind) == Rank.FourofaKind + '6', " Ranking <> " + Rank.FourofaKind);
            Debug.Assert(Hand(StraightFlush) == Rank.StraightFlush + '6', " Ranking <> " + Rank.StraightFlush);
            Debug.Assert(Hand(RoyalFlush) == Rank.RoyalFlush + '>', " Ranking <> " + Rank.RoyalFlush);
            //DisplayResults();
        }
        //
        // Only for display
        //
        private void DisplayResults()
        {
            string[] lines = File.ReadAllLines("text/poker.txt");
            for (int i = 0; i < 1000; i++)
            {
                Rank h1 = Hand(player1[i]);
                Rank h2 = Hand(player2[i]);
                Console.WriteLine("{0} {1} {2} ({3} - {4})", i, lines[i], (h1 > h2) ? "win" : "   ", R(h1), R(h2));
            }
        }
        private string R(Rank r)
        {
            char c = (char)((int)r % 100);
            return (r - c).ToString() + " " + ((c <= '9') ? c : "TJQKA"[c - ':']);
        }
    }
}
