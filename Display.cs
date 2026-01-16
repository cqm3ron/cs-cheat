namespace Cheat
{
    internal class Display
    {
        public const int CardWidth = 11;
        public const int CardHeight = 7;


        /// <summary>
        /// Displays a large card
        /// </summary>
        /// <param name="card">The card to display</param>

        private static void Card(Card card)
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
            NextLineCard();
            Console.Write($"│{leftRank}       │");
            NextLineCard();
            Console.Write("│         │");
            NextLineCard();
            Console.Write($"│    {suit}    │");
            NextLineCard();
            Console.Write("│         │");
            NextLineCard();
            Console.Write($"│       {rightRank}│");
            NextLineCard();
            Console.Write("└─────────┘");
            NextLineCard();
            Console.SetCursorPosition(Console.GetCursorPosition().Left + CardWidth, Console.GetCursorPosition().Top - CardHeight);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a small card
        /// </summary>
        /// <param name="side">Specifies the side to align the card. Use "left" to align the card to the left; any other value aligns it to
        /// the right.</param>
        /// <param name="card">The card to display</param>

        private static void ShortCard(string side, Card card)
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

            if (side == "left")
            {
                Console.WriteLine();
                Console.Write("┌─────");
                NextLineSmallCard();
                Console.Write($"│{leftRank}   ");
                NextLineSmallCard();
                Console.Write($"│    {suit}");
                NextLineSmallCard();
                Console.Write("│     ");
                NextLineSmallCard();
                Console.Write("└─────");
                Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 5);

            }
            else
            {
                Console.Write("─────┐");
                NextLineSmallCard();
                Console.Write("     │");
                NextLineSmallCard();
                Console.Write($"{suit}    │");
                NextLineSmallCard();
                Console.Write($"   {rightRank}│");
                NextLineSmallCard();
                Console.Write("─────┘");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a short, empty card layout on the console, aligned to the specified side.
        /// </summary>
        /// <param name="side">Specifies the side to align the card. Use "left" to align the card to the left; any other value aligns it to
        /// the right.</param>

        private static void ShortEmptyCard(string side)
        {
            if (side == "left")
            {
                Console.WriteLine();
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
                Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 5);
            }
            else
            {
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
                NextLineSmallCard();
                Console.Write("      ");
            }
        }

        /// <summary>
        /// Moves the console cursor to the start of the next line, offset by six columns to the left.
        /// </summary>

        private static void NextLineSmallCard()
        {
            Console.SetCursorPosition(Console.GetCursorPosition().Left - 6, Console.GetCursorPosition().Top + 1);
        }


        /// <summary>
        /// Moves the console cursor to the start of the next line, offset horizontally by the width of a card.
        /// </summary>

        private static void NextLineCard()
        {
            Console.SetCursorPosition(Console.GetCursorPosition().Left - CardWidth, Console.GetCursorPosition().Top + 1);
        }

        /// <summary>
        /// Displays detailed information about the current menu selection in the specified deck, including the
        /// highlighted card and related card lists.
        /// </summary>
        /// <param name="deck">The deck containing the cards to display in the menu.</param>
        /// <param name="current">The zero-based index of the currently selected card in the deck. Must be within the bounds of the deck.</param>

        private static void ScrollMenuInfo(Deck deck, int current)
        {
            Console.Clear();
            BigCard(deck, current);
            Console.SetCursorPosition(Console.GetCursorPosition().Left + 2, Console.GetCursorPosition().Top - 5);
            SelectedCards(deck);
            Console.SetCursorPosition(0, CardHeight + 2);
            OwnedCards(deck);
        }

        /// <summary>
        /// Displays an interactive menu in the console that allows the user to navigate through the specified deck and
        /// select up to four cards using the keyboard.
        /// </summary>
        /// <remarks>Use the left and right arrow keys to navigate between cards. Press the spacebar to
        /// select or deselect a card; a maximum of four cards can be selected at a time. Press Enter to confirm the
        /// selection and exit the menu. The method does not return a value; selected cards are updated within the
        /// provided deck instance.</remarks>
        /// <param name="deck">The deck of cards to display and interact with in the menu. Must not be null.</param>

        public static void ScrollMenu(Deck deck)
        {
            Console.CursorVisible = false;
            int current = 0;
            ConsoleKeyInfo inputKey;
            Card selectedCard;
            bool changesMade = true;

            while (true)
            {
                if (changesMade) // only redraw display if something has changed to avoid unnecessary flickering
                {
                    ScrollMenuInfo(deck, current);
                    changesMade = false;
                }

                inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.RightArrow)
                {
                    if (current < deck.Length - 1)
                    {
                        current++;
                        changesMade = true;
                    }
                }
                else if (inputKey.Key == ConsoleKey.LeftArrow)
                {
                    if (current > 0)
                    {
                        current--;
                        changesMade = true;
                    }
                }
                else if (inputKey.Key == ConsoleKey.Spacebar)
                {
                    selectedCard = deck.GetCard(current);
                    if (selectedCard.GetSelected())
                    {
                        selectedCard.DeSelect();
                        changesMade = true;
                    }
                    else
                    {
                        if (deck.GetSelectedCardCount() < 4)
                        {
                            selectedCard.Select();
                            changesMade = true;
                        }
                    }
                }
                else if (inputKey.Key == ConsoleKey.Enter && deck.GetSelectedCardCount() > 0)
                {
                    break;
                }
                else
                {
                    changesMade = false;
                }

            }
        }

        /// <summary>
        /// Displays the specified card from the deck in a prominent format, along with its immediate neighboring cards
        /// if available.
        /// </summary>
        /// <param name="deck">The deck containing the cards to display. Cannot be null.</param>
        /// <param name="card">The zero-based index of the card to display. Must be within the valid range of the deck.</param>

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

            if (previousCard != null) // attempt to display the previous card
            {
                Display.ShortCard("left", previousCard);
            }
            else
            {
                Display.ShortEmptyCard("left");
            }

            Display.Card(middleCard); // display the current card

            if (nextCard != null) // attempt to display the next card
            {
                Console.SetCursorPosition(Console.GetCursorPosition().Left + (CardWidth / 2) - 5, Console.GetCursorPosition().Top + 1);
                Display.ShortCard("right", nextCard);
            }
            else
            {
                Console.SetCursorPosition(Console.GetCursorPosition().Left + (CardWidth / 2) - 5, Console.GetCursorPosition().Top + 1);
                Display.ShortEmptyCard("right");
            }
        }

        /// <summary>
        /// Displays the names of all selected cards in the specified deck and updates the deck's selected card count.
        /// </summary>
        /// <remarks>This method writes the names of selected cards to the console and updates the deck to
        /// reflect the current number of selected cards. The output is formatted with each card name on a new line
        /// below the "Selected Cards:" label.</remarks>
        /// <param name="deck">The deck containing the cards to be checked for selection. Cannot be null.</param>

        private static void SelectedCards(Deck deck)
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

            deck.SetSelectedCardCount(selectedCards.Count);

        }

        /// <summary>
        /// Displays a summary of the number of cards owned for each rank in the specified deck to the console.
        /// </summary>
        /// <remarks>Ranks with four cards are highlighted in cyan, and ranks with no cards are shown in
        /// dark gray. The output is written directly to the console.</remarks>
        /// <param name="deck">The deck whose cards are to be analyzed and displayed. Cannot be null.</param>

        private static void OwnedCards(Deck deck)
        {
            Console.WriteLine("Your Cards:");
            int[] cardCounter = new int[13];
            foreach (Card card in deck.GetCards())
            {
                cardCounter[(int)card.GetRankEnum() - 1]++;
            }

            string[] cardTypes = new string[] { "Aces", "Twos", "Threes", "Fours", "Fives", "Sixes", "Sevens", "Eights", "Nines", "Tens", "Jacks", "Queens", "Kings" };

            for (int i = 0; i < 13; i++)
            {
                if (cardCounter[i] == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (cardCounter[i] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine($"{cardTypes[i]}: {cardCounter[i]}");
                Console.ResetColor();
            }
        }

    }
}
