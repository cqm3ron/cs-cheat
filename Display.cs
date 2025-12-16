namespace Cheat
{
    internal class Display
    {
        public static int CardsPerLine = SetCardsPerLine();
        public const int CardWidth = 11;
        public const int CardHeight = 7;

        public static void Deck(Deck deck, int startPosition, int endPosition)
        {
            if (endPosition > deck.Length - 1)
            {
                endPosition = deck.Length - 1;
            }

            Card current;
            for (int i = startPosition; i < endPosition; i++)
            {
                current = deck.GetCard(i);
                Card(current);
            }
        }

        public static void Card(Card card, bool selected = false)
        {
            string rightRank, leftRank;
            string rank = card.GetRank();
            char suit = card.GetSuit();

            if (rank == "10")
            {
                rightRank = rank;
                leftRank = rank;
            }
            else
            {
                rightRank = rank + " ";
                leftRank = " " + rank;
            }
            if (selected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write("┌─────────┐");
            NextLine();
            Console.Write($"│{leftRank}       │");
            NextLine();
            Console.Write("│         │");
            NextLine();
            Console.Write($"│    {suit}    │");
            NextLine();
            Console.Write("│         │");
            NextLine();
            Console.Write($"│       {rightRank}│");
            NextLine();
            Console.Write("└─────────┘");
            NextLine();
            NextCard();
            Console.ResetColor();
        }

        private static void NextLine()
        {
            Console.SetCursorPosition(Console.GetCursorPosition().Left - CardWidth, Console.GetCursorPosition().Top + 1);
        }

        private static void NextCard()
        {
            Console.SetCursorPosition(Console.GetCursorPosition().Left + CardWidth, Console.GetCursorPosition().Top - CardHeight);
        }

        private static int SetCardsPerLine()
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int cardsPerLine = windowWidth / CardWidth;
            return cardsPerLine;
        }

        public static void ScrollMenu(Deck deck)
        {
            int hovered = 0;
            List<int> selected = new List<int>();
            int currentStart = 0;
            int currentEnd;
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                // Update cards per line in case the console was resized.
                CardsPerLine = SetCardsPerLine();
                if (CardsPerLine <= 0)
                {
                    CardsPerLine = 1;
                }

                currentEnd = Math.Min(currentStart + CardsPerLine, deck.Length);

                if (currentStart >= deck.Length) // If start is out of range, move to last page start.
                {
                    if (deck.Length == 0)
                    {
                        currentStart = 0;
                        currentEnd = 0;
                    }
                    else
                    {
                        int pages = (deck.Length + CardsPerLine - 1) / CardsPerLine; // ceiling
                        currentStart = Math.Max(0, (pages - 1) * CardsPerLine);
                        currentEnd = deck.Length;
                    }
                }

                if (currentStart < 0)
                {
                    currentStart = 0;
                    currentEnd = Math.Min(CardsPerLine, deck.Length);
                }

                Console.Clear();
                Display.Deck(deck, currentStart, currentEnd);

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    // Go to next page if possible
                    if (currentStart + CardsPerLine < deck.Length)
                    {
                        currentStart += CardsPerLine;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    // Go to previous page if possible
                    currentStart = Math.Max(0, currentStart - CardsPerLine);
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

            }
        }
    }
}
