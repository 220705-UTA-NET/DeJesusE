/*
The game itself. Initializes the player objects for each of the players and calls on them to initialize their boards. After that, it rotates between the
players, asking for coordinates that which they wish to target. Once a win condition is meet (i.e. one of the players have run out of pieces on their board),
the game will then declare a winner before returning to the Program object and closing the program.

@author Ellery R. De Jesus
@since 7/19/2022
*/
namespace Battleship
{
    class Game
    {
        // The player who's turn is ongoing
        private Player CurrentPlayer;
        // The player who's turn is next
        private Player NextPlayer;

        // The height of the board (# of rows). Currently interchangeable with the variable y.
        private int x;
        // The width of the board (# of columns).
        private int y;

        public Game(int width, string nameA, string nameB)
        {
            //Sets the height/width of the board
            this.x = this.y = width;

            //Creates a player object for each of the players, passing their name and the height/width given to initialize their
            //respective boards.
            CurrentPlayer = new Player(nameA, width);
            NextPlayer = new Player(nameB, width);

            Console.Clear();

            // Initialize the player boards
            InitializeGame();

        }

        private void InitializeGame()
        {
            CurrentPlayer.InitializeBoard();
            NextPlayer.InitializeBoard();
        }

        /*
            Starts the game. For each turn, the "CurrentPlayer" picks out a coordinate to strike. The game then calls out the player's
            opponent (i.e. the "NextPlayer") to call out if the the coordinate contains one of their pieces. If yes, then print out
            "HIT !!!" and deduct a point from the opponent before starting the other player's turn. If no, then declare a miss, before
            starting the other player's turn.
        */
        public void Run()
        {
            // The player's input.
            string? input;
            // Coordinates derived from the player's input.
            string[] coordinates;

            //
            int x = 0;
            int y = 0;
            Player temp;

            bool ValidInput = false;
            bool exit = false;

            do
            {
                Console.WriteLine(CurrentPlayer.PrintBoards());
                do
                {
                    Console.Write($"{CurrentPlayer.Name}, please provide coordinates: ");
                    input = Console.ReadLine();
                    try
                    {
                        if (String.IsNullOrEmpty(input))
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            if (input.ToLower() == "exit")
                            {
                                exit = true;
                            }
                            else
                            {
                                coordinates = input.Split(',');
                                x = int.Parse(coordinates[0]);
                                y = int.Parse(coordinates[1]);
                            }
                            ValidInput = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid Input: Try Again !!!");
                    }
                } while (ValidInput != true);

                if (exit != true)
                {
                    if (NextPlayer.Hit(x, y))
                    {
                        Console.WriteLine("HIT !!!");
                        CurrentPlayer.OpponentBoard.SetCoord('X', x, y);
                        NextPlayer.PlayerBoard.SetCoord('X', x, y);

                        NextPlayer.HitPoints--;
                    }
                    else
                    {
                        Console.WriteLine("MISS !!!");
                        CurrentPlayer.OpponentBoard.SetCoord('O', x, y);
                    }

                    if (NextPlayer.HitPoints == 0)
                    {
                        Console.WriteLine($"{CurrentPlayer.Name} has won !!!");
                        Console.ReadLine();
                        exit = true;
                    }
                    else
                    {
                        temp = CurrentPlayer;
                        this.CurrentPlayer = this.NextPlayer;
                        this.NextPlayer = temp;
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            } while (exit != true);
        }
    }
}