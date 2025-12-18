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

        public static void ShortEmptyCard()
        {
            Console.Write("           ");
            NextLine();
            Console.Write("           ");
            NextLine();
            Console.Write("           ");
            NextLine();
            Console.Write("           ");
            NextLine();
            Console.Write("           ");
            NextLine();
            Console.Write("           ");
            NextLine();
            Console.Write("           ");
            NextLine();
            NextCard();
            Console.ResetColor();
        }
        public static void ShortCard(Card card)
        {
                string rightRank, leftRank;
                string rank = card.GetRank();
                char suit = card.GetSuit();
                bool selected = card.GetSelected();    


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
                Console.Write("           ");
                NextLine();
                Console.Write("┌─────────┐");
                NextLine();
                Console.Write($"│{leftRank}       │");
                NextLine();
                Console.Write($"│    {suit}    │");
                NextLine();
                Console.Write($"│       {rightRank}│");
                NextLine();
                Console.Write("└─────────┘");
                NextLine();
                Console.Write("           ");
                NextLine();
                NextCard();
                Console.ResetColor();
        }
        public static void Card(Card card)
        {
            string rightRank, leftRank;
            string rank = card.GetRank();
            char suit = card.GetSuit();
            bool selected = card.GetSelected();

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
            int current = 0;
            ConsoleKeyInfo inputKey;
            Card selectedCard;
            
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                BigCard(deck, current);
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 7, Console.GetCursorPosition().Top);
                DisplaySelectedCards(deck);

                inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.RightArrow)
                {
                    if (current < deck.Length - 1)
                    {
                        current++;
                    }
                }
                else if (inputKey.Key == ConsoleKey.LeftArrow)
                {
                    if (current > 0)
                    {
                        current--;
                    }
                }
                else if (inputKey.Key == ConsoleKey.Enter || inputKey.Key == ConsoleKey.Spacebar)
                {
                    selectedCard = deck.GetCard(current);
                    if (selectedCard.GetSelected())
                    {
                        selectedCard.DeSelect();
                    }
                    else
                    {
                        selectedCard.Select();
                    }
                }
            }
        }

        public static void BigCard(Deck deck, int card)
        {
            Card middleCard = deck.GetCard(card);
            Card previousCard = null, nextCard = null;

            if (card > 0)
            {
                previousCard = deck.GetCard(card - 1);
            }
            if (card < deck.Length - 1)
            {
               nextCard = deck.GetCard(card + 1);
            }
            if (previousCard != null)
            {
                Display.ShortCard(previousCard);
            }
            else
            {
                Display.ShortEmptyCard();
            }
            if (nextCard != null)
            {
                Console.SetCursorPosition(Console.GetCursorPosition().Left + (CardWidth / 2) - 4, Console.GetCursorPosition().Top);
                Display.ShortCard(nextCard);
            }
            else
            {
                Console.SetCursorPosition(Console.GetCursorPosition().Left + (CardWidth / 2) - 4, Console.GetCursorPosition().Top);
                Display.ShortEmptyCard();
            }
            Console.SetCursorPosition(Console.GetCursorPosition().Left - (2 * CardWidth) + (CardWidth / 2), Console.GetCursorPosition().Top);
            Display.Card(middleCard);
        }

        public static void DisplaySelectedCards(Deck deck)
        {
            Console.Write("Selected Cards:");
            Console.SetCursorPosition(Console.GetCursorPosition().Left - 15, Console.GetCursorPosition().Top + 1); // "Selected Cards" is 15 chars
            List<Card> selectedCards = new List<Card>();
            foreach (Card card in deck.GetCards())
            {
                if (card.GetSelected())
                {
                    selectedCards.Add(card);
                }
            }
            foreach (Card card in selectedCards)
            {
                Console.Write(card.GetName());
                Console.SetCursorPosition(Console.GetCursorPosition().Left - card.GetName().Length, Console.GetCursorPosition().Top + 1);
            }

        }
    }
}
