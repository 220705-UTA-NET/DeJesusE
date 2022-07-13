namespace Battleship
{
    class Game
    {
        private Player playerA;

        private Player playerB;

        public Game()
        {
            Console.Write("Please enter a board width: ");
            int size = int.Parse(Console.ReadLine());

            Console.Write("Please provide name for player 1: ");
            string nameA = Console.ReadLine();

            Console.Write("Please provide name for player 2: ");
            string nameB = Console.ReadLine();

            playerA = new Player(nameA, size);
            playerB = new Player(nameB, size);

        }

        // private void PrintBoard()
        // {
        //     Console.Write(actualBoard.ToString());
        // }

        // public void setOpponent(Game game){
        //     this.opponent = game;
        // }

        public void Run()
        {
            string input;
            char[] coordinates;
            int x;
            int y;
            Player temp;

            do
            {
                PrintBoards();
                input = Console.ReadLine();
                if (input != "exit")
                {
                    try
                    {
                        coordinates = input.ToCharArray();
                        x = (int)char.GetNumericValue(coordinates[0]);
                        y = (int)char.GetNumericValue(coordinates[coordinates.GetLength(0) - 1]);

                        if (playerB.Hit(x, y))
                        {
                            Console.WriteLine("HIT !!!");
                        }
                        else
                        {
                            Console.WriteLine("MISS !!!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("INVALID INPUT: Try again!");
                    }
                }

                temp = playerA;
                this.playerA = this.playerB;
                this.playerB = temp;

            } while (input != "exit");

        }

        private void PrintBoards()
        {
            Console.WriteLine(playerA.actualBoard.ToString());
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(playerB.visualBoard.ToString());
            Console.Write($"{playerA.name}, please enter a coordinate: ");
        }
    }
}