namespace Cheat
{
    internal class Deck
    {
        // Properties

        private static readonly Random rand = new Random();
        private List<Card> cards = new List<Card>();
        private int selectedCardCount;
        private int deckCount;
        public int SelectedCards
        {
            get
            {
                int selectedCount = 0;
                foreach (Card card in cards)
                {
                    if (card.GetSelected())
                    {
                        selectedCount++;
                    }
                }
                return selectedCount;
            }
        }
        public int Count { get { return cards.Count; } }

        // Constructors

        public Deck(bool fill = false)
        {
            if (fill)
            {
                cards = Card.GenerateDeck();
                deckCount = 1;
            }
            else
            {
                cards = new List<Card>();
                deckCount = 0;
            }
        }

        public Deck(Deck deck)
        {
            cards = deck.cards;
        }

        // Getters

        public int GetNumberOfDecks()
        {
            return deckCount;
        }

        public int GetSelectedCardCount()
        {
            return selectedCardCount;
        }

        public Card GetCard(int index) // 0-based because consistency is boring
        {
            return cards[index];
        }

        public List<Card> GetCards()
        {
            List<Card> _cards = []; // visual studio isnt happy with this apparently it can be simplified, maybe i should look into that?
            foreach (Card card in cards)
            {
                _cards.Add(card);
            }
            return _cards;
        }

        // Setters & Resetters

        public void SetSelectedCardCount(int value)
        {
            selectedCardCount = value;
        }

        public void ResetSelectedCards()
        {
            foreach (Card card in cards)
            {
                if (card.GetSelected())
                {
                    card.DeSelect();
                }
            }
            selectedCardCount = 0;
        }

        // Misc Methods

        public void AddDeck()
        {
            cards.AddRange(Card.GenerateDeck());
            deckCount++;
        }

        public Deck[] Deal(int players = 2) // var players is 1-based because i want it to be, default 2 (assumes user has friends; unlikely)
        {
            if (players > 8)
            {
                // add more decks or something idk how
                // maybe i should add a players parameter earlier on so it does that while generating deck
            }

            int current = rand.Next(1, players + 1); // choose a random starting player to avoid consistency in who has more cards
            Deck[] playerDecks = new Deck[players]; // {PlayerDeck1, PlayerDeck2, etc.}

            for (int i = 0; i < players; i++)
            {
                playerDecks[i] = new Deck();
            }

            while (Count > 0)
            {
                playerDecks[current - 1].cards.Add(cards[0]);
                cards.RemoveAt(0);
                current++;
                if (current > players)
                {
                    current = 1;
                }
            }

            foreach (Deck deck in playerDecks)
            {
                deck.Sort();
            }

            return playerDecks;
        }

        public void Shuffle() // uses Fisher-Yates shuffle
        {
            int j;
            for (int i = 0; i < cards.Count - 2; i++)
            {
                Card temp;
                j = rand.Next(i, cards.Count);
                temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public void Sort()
        {
            cards = cards.OrderBy(c => c.GetRankEnum()).ThenBy(c => c.GetSuitEnum()).ToList();
        } // ok so the fact this is directly under a shuffle method is quite ironic

    }
}
