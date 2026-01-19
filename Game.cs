namespace Cheat
{
    class Game
    {
        private Deck deck;
        private int playerCount;
        private int currentPlayer = 0;
        private Deck[] playerDecks;

        public Game(Settings settings)
        {
            playerCount = settings.playerCount;
            // Initialise Deck(s)
            int extraDecksNeeded = 1;
            extraDecksNeeded = (int)Math.Ceiling((playerCount - 4) / 4f);
            deck = new(true); // generates prefilled deck
            if (extraDecksNeeded > 0) for (int i = 0; i < extraDecksNeeded; i++) deck.AddDeck(); // Adds more decks if more than 4 players
            deck.Shuffle();
            playerDecks = deck.Deal(playerCount); // deals deck between players

        }

        public void Play()
        {
            int currentPlayer = 0;

            while (true) // add end condition sometime idk
            {
                Display.ScrollMenu(playerDecks[currentPlayer]); // display current player's deck and options
                playerDecks[currentPlayer].ResetSelectedCards(); // temporary because nothing else happens after this
                NextPlayer();
            }
        }

        private void NextPlayer()
        {
            currentPlayer = (currentPlayer + 1) % playerCount;
        }
    }
}