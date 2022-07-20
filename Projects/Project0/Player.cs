using System.Text;
namespace Battleship
{
    class Player
    {
        public Board PlayerBoard { get; set; }

        public Board OpponentBoard { get; set; }

        public string Name { get; set; }

        public int HitPoints { get; set; }

        public Player(string name, int size)
        {
            this.Name = name;
            this.PlayerBoard = new Board(size);
            this.OpponentBoard = new Board(size);
            HitPoints = 0;
        }

        public void InitializeBoard()
        {
            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Battleship);
            // HitPoints += Pieces.Battleship.Size;

            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Carrier);
            // HitPoints += Pieces.Carrier.Size;

            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Cruiser);
            // HitPoints += Pieces.Cruiser.Size;

            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Submarine);
            // HitPoints += Pieces.Submarine.Size;

            Console.WriteLine(PrintBoard());
            SetPiece(Pieces.Destroyer);
            HitPoints += Pieces.Destroyer.Size;

        }



        private void SetPiece(Pieces piece)
        {

            string? input;
            string[] coordinates;

            char direction;
            int x = 0;
            int y = 0;

            bool ValidInput = false;

            while (!ValidInput)
            {

                try
                {
                    Console.Write($"{this.Name}, provide a coordinate for {piece.Name}: ");
                    input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        coordinates = input.Split(',');
                        x = int.Parse(coordinates[0]);
                        y = int.Parse(coordinates[1]);
                        if (PlayerBoard.GetCoord(x, y) != ' ')
                        {
                            Console.WriteLine("Space already occupied, try a different coordinate.");
                        }
                        else
                        {
                            if (!PlayerBoard.CheckPossiblePositions(x, y, piece.Size))
                            {
                                Console.WriteLine("There are no valid positions at this coordinate. Choose a new set of coordinates");
                            }
                            else
                            {
                                ValidInput = true;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("INVALID INPUT. Try Again !!!");
                }
            }

            ValidInput = false;
            while (!ValidInput)
            {
                Console.Write($"{this.Name}, provide facing direction for {piece.Name} (N, S, W, E): ");
                input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    direction = input[0];
                    ValidInput = PlayerBoard.SetPiece(x, y, piece.Symbol, piece.Size, direction);
                }
                if (!ValidInput) Console.WriteLine("INVALID INPUT. Try Again !!!");
            }

            Console.Clear();

        }


        public bool Hit(int x, int y)
        {
            char TileChar = PlayerBoard.GetCoord(x, y);
            return TileChar != ' ' && TileChar != 'X' ? true : false;
        }

        public string PrintBoards()
        {
            StringBuilder response = new StringBuilder();
            response.Append(GenerateHeader() + "     |   " + GenerateHeader() + "\n");
            response.Append(GenerateDivider() + "    |   " + GenerateDivider() + "\n");


            for (int i = 0; i < PlayerBoard.Xsize; i++)
            {
                response.Append(PlayerBoard.GetRow(i));
                response.Append("    |   ");
                response.Append(OpponentBoard.GetRow(i));
                response.Append("\n");
                response.Append(GenerateDivider());
                response.Append("    |   ");
                response.Append(GenerateDivider());
                response.Append("\n");
            }

            return response.ToString();
        }



        private string PrintBoard()
        {
            StringBuilder response = new StringBuilder();
            response.Append(GenerateHeader() + "\n");
            response.Append(GenerateDivider() + "\n");

            for (int i = 0; i < PlayerBoard.Xsize; i++)
            {
                response.Append(PlayerBoard.GetRow(i) + "\n");
                response.Append(GenerateDivider() + "\n");
            }
            return response.ToString();
        }

        private string GenerateDivider()
        {
            string divider = "   ";
            for (int i = 0; i < PlayerBoard.Ysize; i++)
            {
                divider += "+ - ";
            }

            divider += "+";
            return divider;
        }

        private string GenerateHeader()
        {
            string header = "   ";
            for (int j = 0; j < PlayerBoard.Ysize; j++)
            {
                header += $"  {j} ";
            }
            return header;
        }
    }
}