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


            NaturalLanguageParser nlp = new();
            while (true)
            {
                nlp.TryParseCard(Console.ReadLine(), out Card? card);
                Console.WriteLine(card);
            }


            Console.ReadKey();

            //Settings settings = new();
            Settings defaultSettings = new(true, 2);

            Game game = new(defaultSettings); // change to settings later
            game.Play();

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
