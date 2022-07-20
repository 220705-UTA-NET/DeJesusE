
/*

Sole purpose is to obtain the height/width of the board (For generating board objects which will be used in representing a game board) and the name
of two players (For generating player objects representing those players)

@author Ellery R. De Jesus
@since 7/19/2022
*/
using System;
namespace Battleship
{

    // Starting point of the program
    class Program
    {

        static void Main(string[] args)
        {
            bool ValidInput = false;
            string? input;
            int size = 0;
            string nameA = "";
            string nameB = "";

            // Get the height/width of the board
            while (!ValidInput)
            {
                Console.Write("Please enter a board height/width: ");
                input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    if (int.TryParse(input, out size))
                    {
                        if (size >= 0) ValidInput = true;
                    }
                }

                if (!ValidInput) Console.WriteLine("Please enter a valid number for height/width.");
            }

            ValidInput = false;

            // Request names for both players
            while (!ValidInput)
            {
                Console.Write("Please provide name for player 1: ");
                input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    nameA = input;
                    ValidInput = true;
                }
                else
                {
                    Console.WriteLine("Please enter a non-blank name");
                }
            }

            ValidInput = false;
            while (!ValidInput)
            {
                Console.Write("Please provide name for player 2: ");
                input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    nameB = input;
                    ValidInput = true;
                }
                else
                {
                    Console.WriteLine("Please enter a non-blank name");
                }
            }
            // Initialize the game with the names of the players and the height/width of the board
            Game game = new Game(size, nameA, nameB);

            Console.Clear();
            // Start the game
            game.Run();

        }
    }
}
