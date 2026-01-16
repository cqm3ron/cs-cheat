using System.Text;

namespace Cheat
{
    internal class Settings
    {

        public bool useUnicode { get; private set; }
        public int playerCount { get; private set; }

        public static Settings Current { get; private set; }
        public static readonly Settings Default = new Settings(_useUnicode: true, _playerCount: 4);

        public Settings()
        {
            Initialise();
            Current = this;
        }

        public Settings(bool? _useUnicode = null, int? _playerCount = null)
        {
            Console.OutputEncoding = Encoding.UTF8;
            useUnicode = _useUnicode ?? GetUnicodeSupport();
            playerCount = _playerCount ?? GetPlayerCount();
            Current = this;
        }

        private void Initialise()
        {
            useUnicode = GetUnicodeSupport();
            playerCount = GetPlayerCount();
        }

        private bool GetUnicodeSupport()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Please press [ENTER] if these symbols render correctly:");
            Console.WriteLine("Heart - ♥");
            Console.WriteLine("Diamond - ♦");
            Console.WriteLine("Spade - ♠");
            Console.WriteLine("Club - ♣");
            Console.WriteLine("If you see boxes or nothing at all, please enter \"TEXT\" & press [ENTER].");
            Console.WriteLine("Otherwise, just press [ENTER]");
            string input = Console.ReadLine() ?? ""; // avoids input ever being null because null values will cause issues

            if (input.ToLower().Contains("text"))
            {
                Console.WriteLine("Display will use letters H, D, S & C");
                return false;
            }
            else
            {
                Console.WriteLine("Display will use Unicode symbols.");
                return true;
            }
        }
        private int GetPlayerCount()
        {
            Console.Write("How many players? Min 2, max 12: ");
            string input;
            bool successfulParse = false;
            int playerCount = -1; 

            while (!successfulParse)
            {
                input = Console.ReadLine() ?? "";
                successfulParse = int.TryParse(input, out playerCount);
                if (successfulParse)
                {
                    if (playerCount < 2 || playerCount > 12)
                    {
                        successfulParse = false;
                        Console.Write("Please enter a number between 2 and 12: ");
                    }
                }
            }

            return playerCount;
        }
    }
}
