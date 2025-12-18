using System.Text;

namespace Cheat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // remove after testing finished
            //Settings.Initialise();
            Deck deck = new Deck(true);
            deck.Shuffle();
            Deck[] playerDecks = deck.Deal(2);
            //Console.ReadKey();

            Display.ScrollMenu(playerDecks[0]);

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
