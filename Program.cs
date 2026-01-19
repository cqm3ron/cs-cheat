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

            // Natural Language Parser testing below; I can't actually figure out when it would be useful but
            // i probably should find a use for it cause i want those marks and also it took me like 5 hours straight to make
            // and i fear it would be a retroactive waste of time if i didnt use it for something

            NaturalLanguageParser nlp = new NaturalLanguageParser();
            nlp.ImportMaps("D:\\Documents\\Visual Studio 2022\\Programs\\cs-cheat\\map\\rankmap.json", "D:\\Documents\\Visual Studio 2022\\Programs\\cs-cheat\\map\\suitmap.json");
            while (true)
            {
                nlp.TryParseCard(Console.ReadLine(), out Card? card);
                Console.WriteLine(card);
            }


            // TODO: some vague sense of consistent commenting... why do i have xml comments in one class for some methods and then not at all anywhere else except my many comments in this file?!?!;

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
