using System.Text;
namespace Battleship
{
    // Represents one of the players of the game
    class Player
    {
        // Board object which represents the board which holds the player's pieces.
        public Board PlayerBoard { get; set; }
        // Board object which represents the board which is used to map out the player's hits/misses
        public Board OpponentBoard { get; set; }
        // The name of the player
        public string Name { get; set; }
        // How many points the player has before losing. Starts off as the sum of all slots that the player's
        // pieces are occupying
        public int HitPoints { get; set; }

        public Player(string name, int size)
        {
            this.Name = name;
            this.PlayerBoard = new Board(size);
            this.OpponentBoard = new Board(size);
            HitPoints = 0;
        }

        // Sets up the player's boards while adding up the sizes of each piece to generate a sum
        // that is then used as the player's hitpoints.
        public void InitializeBoard()
        {
            // Place the player's battleship on the board
            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Battleship);
            // HitPoints += Pieces.Battleship.Size;

            // Place the player's carrier on the board
            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Carrier);
            // HitPoints += Pieces.Carrier.Size;

            // Place the player's cruiser on the board
            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Cruiser);
            // HitPoints += Pieces.Cruiser.Size;

            // Place the player's submarine on the board
            // Console.WriteLine(PrintBoard());
            // SetPiece(Pieces.Submarine);
            // HitPoints += Pieces.Submarine.Size;

            // Place the player's destroyer on the board
            Console.WriteLine(PrintBoard());
            SetPiece(Pieces.Destroyer);
            HitPoints += Pieces.Destroyer.Size;

        }


        // Places a given piece unto the player's board
        private void SetPiece(Pieces piece)
        {
            // The player's input
            string? input;
            // The coordinates that the player provided
            string[] coordinates;

            char direction;
            int x = 0;
            int y = 0;

            // Used in verifying if the player submitted an appropriate input
            bool ValidInput = false;

            // Loop continously until the player provides a set of coordinates that which
            // isn't null, blank, or would result in a piece going overbound or overlapping
            // another piece. 
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

            // Request for a cardinal direction for which to place the piece towards while checking
            // for any possible invalid inputs.
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

        // Checks to see if the player has a piece at the given coordinates. If yes, return true.
        // If no, then return false.
        public bool Hit(int x, int y)
        {
            char TileChar = PlayerBoard.GetCoord(x, y);
            return TileChar != ' ' && TileChar != 'X' ? true : false;
        }

        // Returns a string representation of the player's boards so that it may be printed by
        // Game unto the screen.
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

        // Used in displaying the board that the player is using to contain their pieces. Primarily
        // used to show what spots are empty when placing pieces.
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

        // Helper method used in generating a divider to be used in separating the rows when
        // printing to screen.
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

        // Helper method used in generating a header for the columns when printing to screen.
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