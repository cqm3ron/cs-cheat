using System.Text;

namespace Cheat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * "https://en.wikipedia.org/wiki/Cheat_(game)"
             * helpful (has rules and that)
             */


            Console.OutputEncoding = Encoding.UTF8; // remove after testing finished
            //Settings.Initialise();
            int playerCount = 5; // add procedure to settings.cs to get & parse playercount
            int extraDecksNeeded = 1;

            extraDecksNeeded = (int)Math.Ceiling((playerCount - 4f) / 4f);
            
            Deck deck = new Deck(true);

            for (int i = 0; i < extraDecksNeeded; i++) deck.AddDeck(); // Adds more decks if more than 4 players

            deck.Shuffle();
            Deck[] playerDecks = deck.Deal(playerCount);
            
            
            Console.ReadKey();

            Game.HandleTurn(playerDecks, deck);

            /* if all selected cards are same rank,
             * auto-fill user input for NOT cheat
             * still allow user to choose to cheat
             * some form of language parsing for inputs
             * detect what cards the user is trying to claim
             * maybe ask user if they want to cheat, then give input?
             * perhaps an arrowkey scrollable menu to select the rank & number they want to claim
             * whilst also displaying the list of cards they have selected
             * stop allowing to select more than 5
             * i think that's it for now */

        }
    }
}
