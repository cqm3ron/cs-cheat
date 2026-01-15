using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheat
{
    class Game
    {
        public static void HandleTurn(Deck[] playerDecks, Deck discardDeck)
        {
            int currentPlayer = 0;


            while (true) // add end condition sometime idk
            {
                Display.ScrollMenu(playerDecks[currentPlayer]);
                playerDecks[0].ResetSelectedCards();

            }
        }

    }
}