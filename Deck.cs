using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cheat
{
    internal class Deck
    {
        private static readonly Random rand = new Random();
        private readonly List<Card> cards = new List<Card>();

        public Deck(bool fill = false)
        {
            if (fill)
            {
                cards = Card.GenerateDeck();
            }
            else
            {
                cards = new List<Card>();
            }
        }

        public Deck (Deck deck)
        {
            cards = deck.cards;
        }

        public int Length { get { return cards.Count; } }

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

            while (Length > 0)
            {
                playerDecks[current - 1].cards.Add(cards[0]);
                cards.RemoveAt(0);
                current++;
                if (current > players)
                {
                    current = 1;
                }
            }

            return playerDecks;
        }

        public Card GetCard(int index) // 0-based because consistency is boring
        {
            return cards[index];
        }

        public List<Card> GetCards()
        {
            List<Card> _cards = new List<Card>();
            foreach (Card card in cards)
            {
                _cards.Add(card);
            }
            return _cards;
        }
    }
}
