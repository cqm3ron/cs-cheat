namespace Cheat
{
    enum Suit
    {
        //suit (str): The suit of the card ('♠', '♥', '♦', '♣').
        heart,
        diamond,
        spade,
        club
    }
    enum Rank : int
    {
        ace=1,
        two=2,
        three=3,
        four=4,
        five=5,
        six=6,
        seven=7,
        eight=8,
        nine=9,
        ten=10,
        jack=11,
        queen=12,
        king=13
    }


    internal class Card
    {
        private string rank;
        private char suit;
        private bool selected = false;

        public Card(Rank _rank, Suit _suit)
        {
            rank = Convert.RankToSymbol(_rank);
            suit = Convert.SuitToSymbol(_suit);
        }

        public string GetRank()
        {
            return rank;
        }

        public char GetSuit()
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

        //public override string ToString()
        //{
        //    return Display.Card(this);
        //}

        public static List<Card> GenerateDeck()
        {
            List<Card> cards = new List<Card>();
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
