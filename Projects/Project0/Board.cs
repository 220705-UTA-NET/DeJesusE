using System;
using System.Text;

namespace Battleship
{
    /*
    Represents two of the player's boards which can either be used to contain their pieces or to map
    out hits and misses that the player has had on the opponent's board.
    */
    class Board
    {
        // The board itself
        private char[,] board { get; set; }

        // The number of rows on the board
        public int Xsize { get; set; }

        // The number of columns on the board
        public int Ysize { get; set; }

        // Takes a height/width to set Xsize and Ysize before initializing the board 2d-array and setting
        // all its elements to blank (' ') 
        public Board(int size)
        {
            Xsize = size;
            Ysize = size;
            this.board = new char[Xsize, Ysize];
            for (int i = 0; i < Xsize; i++)
            { 
                for (int j = 0; j < Ysize; j++)
                {
                    this.board[i, j] = ' ';
                }
            }

        }

        // Retrieves a character at the given coordinate from within the board array
        public char GetCoord(int x, int y)
        {
            return board[x, y];
        }

        // Sets the element within the coordinates given to the given character
        public void SetCoord(char c, int x, int y)
        {
            this.board[x, y] = c;
        }

        // Used by Player to check if the coordinates given by the player has any possible orientations
        // that a piece can be placed at (Represented by its size). If yes, then return true. If there are
        // no means to place the piece at the given location without it overlapping another piece, then return
        // false.
        public bool CheckPossiblePositions(int x, int y, int size)
        {
            return CheckNorth(x, y, size) || CheckSouth(x, y, size) || CheckWest(x, y, size) || CheckEast(x, y, size);
        }

        // Checks to see if the pathway northwards of the coordinates given has space to place the piece.
        private bool CheckNorth(int x, int y, int size)
        {
            if (x - size < 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (board[x - i, y] != ' ') return false;
                }
                return true;
            }
        }

        // Checks to see if the pathway southwards of the coordinates given has space to place the piece.
        private bool CheckSouth(int x, int y, int size)
        {
            if (x + size > board.GetLength(0) - 1)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (board[x + i, y] != ' ') return false;
                }
                return true;
            }
        }

        // Checks to see if the pathway westwards of the coordinates given has space to place the piece.
        private bool CheckWest(int x, int y, int size)
        {
            if (y - size < 0)
            {
                return false;
            }
            else
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[x, y - j] != ' ') return false;
                }
                return true;
            }
        }

        // Checks to see if the pathway eastwards of the coordinates given has space to place the piece.
        private bool CheckEast(int x, int y, int size)
        {
            if (y + size > board.GetLength(1) - 1)
            {
                return false;
            }
            else
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[x, y + j] != ' ') return false;
                }
                return true;
            }
        }

        // Places the piece at the given coordinate facing towards the direction that the user has given.
        public bool SetPiece(int x, int y, char letter, int size, char direction)
        {
            if ((x >= board.GetLength(0) && x < 0) &&
                       (y >= board.GetLength(1) && y < 0))
            {
                return false;
            }
            switch (char.ToUpper(direction))
            {
                case ('N'):
                    if (x < size)
                    {
                        return false;
                    }
                    else
                    {
                        return NPlacement(x, y, letter, size);
                    }
                case ('S'):
                    if (x > this.board.GetLength(0) - size - 1)
                    {
                        return false;
                    }
                    else
                    {
                        return SPlacement(x, y, letter, size);
                    }
                case ('W'):
                    if (y < size)
                    {
                        return false;
                    }
                    else
                    {
                        return WPlacement(x, y, letter, size);
                    }

                case ('E'):
                    if (y > this.board.GetLength(1) - size - 1)
                    {
                        return false;
                    }
                    else
                    {
                        return EPlacement(x, y, letter, size);
                    }
                default:
                    return false;
            }
        }

        // Places the piece vertically upwards. Returns true if the process was successful and returns
        // false if the pathway is blocked.
        private bool NPlacement(int x, int y, char letter, int size)
        {
            if (!CheckNorth(x, y, size)) return false;

            for (int i = 0; i < size; i++)
            {
                SetCoord(letter, x - i, y);
            }
            return true;
        }

        // Places the piece vertically downwards. Returns true if the process was successful and returns
        // false if the pathway is blocked.
        private bool SPlacement(int x, int y, char letter, int size)
        {
            if (!CheckSouth(x, y, size)) return false;

            for (int i = 0; i < size; i++)
            {
                SetCoord(letter, x + i, y);
            }
            return true;
        }


        // Places the piece horizontally to the left. Returns true if the process was successful and returns
        // false if the pathway is blocked.
        private bool WPlacement(int x, int y, char letter, int size)
        {
            if (!CheckWest(x, y, size)) return false;

            for (int j = 0; j < size; j++)
            {
                SetCoord(letter, x, y - j);
            }
            return true;
        }


        // Places the piece horizontally to the right. Returns true if the process was successful and returns
        // false if the pathway is blocked.
        private bool EPlacement(int x, int y, char letter, int size)
        {
            if (!CheckEast(x, y, size)) return false;

            for (int j = 0; j < size; j++)
            {
                SetCoord(letter, x, y + j);
            }
            return true;
        }

        // Produces a string representation of a singular row of the board. Used by Player when printing
        // boards.
        public string GetRow(int x)
        {
            StringBuilder response = new StringBuilder();
            response.Append($" {x} ");
            for (int j = 0; j < board.GetLength(1); j++)
            {
                response.Append($"| {board[x, j]} ");
            }
            response.Append("|");
            return response.ToString();
        }
    }
}