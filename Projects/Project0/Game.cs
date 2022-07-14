using System.Text;
namespace Battleship
{
    class Game
    {
        private Player playerA;

        private Player playerB;

        private int x;
        private int y;

        public Game()
        {
            Console.Write("Please enter a board width: ");
            int size = int.Parse(Console.ReadLine());

            this.x = this.y = size;

            Console.Write("Please provide name for player 1: ");
            string nameA = Console.ReadLine();

            Console.Write("Please provide name for player 2: ");
            string nameB = Console.ReadLine();

            Console.WriteLine();

            playerA = new Player(nameA, size);
            playerB = new Player(nameB, size);

        }

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
                Console.Write($"{playerA.name}, please give provide coordinates: ");
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

            StringBuilder response = new StringBuilder();
            response.Append(Header());
            response.Append(GenerateDivider());

            for (int i = 0; i < this.x; i++)
            {
                response.Append(playerA.actualBoard.GetRow(i));
                response.Append("    |   ");
                response.Append(playerB.visualBoard.GetRow(i));
                response.Append("\n");
                response.Append(GenerateDivider());
            }

            Console.WriteLine(response.ToString());
        }

        private string GenerateDivider()
        {
            string divider = "   ";
            for (int i = 0; i < this.y; i++)
            {
                divider += "+ - ";
            }

            divider += "+    |   " + divider + "+" + "\n";
            return divider;
        }

        private string Header()
        {
            string header = "   ";
            for (int j = 0; j < this.y; j++)
            {
                header += $"  {j} ";
            }
            return header + "     |   " + header + "\n";
        }
    }
}