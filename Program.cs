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
            Console.ReadKey();
            Display.ScrollMenu(playerDecks[0]);
        }
    }
}
