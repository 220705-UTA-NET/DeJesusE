namespace Battleship
{
    class Game
    {
        private Board board;
        public Game()
        {
            Console.Write("Please enter a board width: ");
            board = new Board(int.Parse(Console.ReadLine()));
        }

        private void PrintBoard()
        {
            Console.Write(board.ToString());
        }

        public void Run()
        {
            Console.Write(board.ToString());
            string input;
            char[] coordinates;
            int x;
            int y;
            do
            {
                Console.Write("Please enter a coordinate: ");
                input = Console.ReadLine();

                if (input != "exit")
                {
                    try
                    {
                        coordinates = input.ToCharArray();
                        x = (int)char.GetNumericValue(coordinates[0]);
                        y = (int)char.GetNumericValue(coordinates[coordinates.GetLength(0) - 1]);

                        if (board.Hit(x, y))
                        {
                            Console.WriteLine("HIT!!!!");
                        }
                        else
                        {
                            Console.WriteLine("MISS!!!");
                        }

                        Console.Write(board.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("INVALID INPUT: Try again!");
                    }
                }

            } while (input != "exit");

        }
    }
}