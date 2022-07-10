using System;
using System.Text;

namespace Battleship
{
    class Board
    {
        private char[,] board;

        public Board(int size)
        {
            board = new char[size, size];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 'X';
                }
            }
        }

        private string GenerateDivider()
        {
            string divider = "   ";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                divider += "+ - ";
            }

            divider += "+\n";

            return divider;
        }

        private string Header()
        {
            string header = "   ";
            for (int j = 0; j < board.GetLength(1); j++)
            {
                header += $"  {j} ";
            }
            return header + "\n";
        }

        internal bool Hit(int x, int y)
        {
            if (board[x, y] == 'X')
            {
                board[x, y] = 'O';
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();
            response.Append(Header());
            response.Append(GenerateDivider());

            for (int i = 0; i < board.GetLength(0); i++)
            {
                response.Append($" {i} ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    response.Append($"| {board[i, j]} ");
                }
                response.Append("|\n");
                response.Append(GenerateDivider());
            }

            return response.ToString();

        }
    }
}