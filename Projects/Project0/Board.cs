using System;
using System.Text;

namespace Battleship
{
    class Board
    {
        private char[,] board { get; set; }

        public int Xsize { get; set; }

        public int Ysize { get; set; }

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

        public char GetCoord(int x, int y)
        {
            return board[x, y];
        }

        public void SetCoord(char c, int x, int y)
        {
            this.board[x, y] = c;
        }

        public bool CheckPossiblePositions(int x, int y, int size)
        {
            return CheckNorth(x, y, size) || CheckSouth(x, y, size) || CheckWest(x, y, size) || CheckEast(x, y, size);
        }

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

        private bool NPlacement(int x, int y, char letter, int size)
        {
            if (!CheckNorth(x, y, size)) return false;

            for (int i = 0; i < size; i++)
            {
                SetCoord(letter, x - i, y);
            }
            return true;
        }

        private bool SPlacement(int x, int y, char letter, int size)
        {
            if (!CheckSouth(x, y, size)) return false;

            for (int i = 0; i < size; i++)
            {
                SetCoord(letter, x + i, y);
            }
            return true;
        }

        private bool WPlacement(int x, int y, char letter, int size)
        {
            if (!CheckWest(x, y, size)) return false;

            for (int j = 0; j < size; j++)
            {
                SetCoord(letter, x, y - j);
            }
            return true;
        }

        private bool EPlacement(int x, int y, char letter, int size)
        {
            if (!CheckEast(x, y, size)) return false;

            for (int j = 0; j < size; j++)
            {
                SetCoord(letter, x, y + j);
            }
            return true;
        }
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