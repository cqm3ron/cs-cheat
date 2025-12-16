using System.Text;

namespace Cheat
{
    internal class Settings
    {
        public static bool useUnicode = true;
        public static void Initialise()
        {
            string input;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Please press ENTER if these symbols render correctly:");
            Console.WriteLine("Heart - ♥");
            Console.WriteLine("Diamond - ♦");
            Console.WriteLine("Spade - ♠");
            Console.WriteLine("Club - ♣");
            Console.WriteLine("If you see boxes or nothing at all, please enter \"TEXT\" & press [ENTER].");
            Console.WriteLine("Otherwise, just press [ENTER]");
            input = Console.ReadLine();
            if (input.ToLower().Contains("text"))
            {
                useUnicode = false;
                Console.WriteLine("Display will use letters H, D, S & C");
            }
            else
            {
                Console.WriteLine("Display will use Unicode symbols.");
            }
        }
    }
}
