namespace Cheat
{
    enum Suit
    {
        heart,
        diamond,
        spade,
        club
    }
    enum Rank : int
    {
        ace = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10,
        jack = 11,
        queen = 12,
        king = 13
    }


    internal class Card
    {
        private Rank rank;
        private Suit suit;
        private bool selected = false;
        private readonly string name;

        public Card(Rank _rank, Suit _suit)
        {
            rank = _rank;
            suit = _suit;
            name = ParseName();
        }

        private string ParseName()
        {
            string name;
            string rankName = rank.ToString();
            rankName = char.ToUpper(rankName[0]) + rankName.Substring(1);
            string suitName = suit.ToString();
            suitName = char.ToUpper(suitName[0]) + suitName.Substring(1);
            suitName = suitName + "s";
            name = rankName + " of " + suitName;
            return name;
        }

        public override string ToString()
        {
            return ParseName();
        }

        public string GetRank()
        {
            return Convert.RankToSymbol(rank);
        }
        public Rank GetRankEnum()
        {
            return rank;
        }
        public string GetName()
        {
            return name;
        }

        public char GetSuit()
        {
            return Convert.SuitToSymbol(suit);
        }

        public Suit GetSuitEnum()
        {
            return suit;
        }

        public bool GetSelected()
        {
            return selected;
        }

        public void Select()
        {
            if (!selected)
            {
                selected = true;
            }
        }

        public void DeSelect()
        {
            if (selected)
            {
                selected = false;
            }
        }

        public static List<Card> GenerateDeck()
        {
            List<Card> cards = [];
            for (int rank = 1; rank <= 13; rank++)
            {
                cards.Add(new Card((Rank)rank, Suit.heart));
                cards.Add(new Card((Rank)rank, Suit.diamond));
                cards.Add(new Card((Rank)rank, Suit.spade));
                cards.Add(new Card((Rank)rank, Suit.club));
            }
            return cards;
        }
    }
}
