using System;
using System.Text;

namespace Battleship
{
    class Board
    {
        private char[,] visualBoard;
        private char[,] actualBoard;

        public Board(int size)
        {
            actualBoard = new char[size, size];
            visualBoard = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    actualBoard[i, j] = 'X';
                    visualBoard[i, j] = ' ';
                }
            }
        }

        private string GenerateDivider()
        {
            string divider = "   ";
            for (int i = 0; i < actualBoard.GetLength(0); i++)
            {
                divider += "+ - ";
            }

            divider += "+\n";

            return divider;
        }

        private string Header()
        {
            string header = "   ";
            for (int j = 0; j < actualBoard.GetLength(1); j++)
            {
                header += $"  {j} ";
            }
            return header + "\n";
        }

        internal bool Hit(int x, int y)
        {
            if (actualBoard[x, y] == 'X')
            {
                visualBoard[x, y] = 'X';
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();
            response.Append(Header());
            response.Append(GenerateDivider());

            for (int i = 0; i < visualBoard.GetLength(0); i++)
            {
                response.Append($" {i} ");
                for (int j = 0; j < visualBoard.GetLength(1); j++)
                {
                    response.Append($"| {visualBoard[i, j]} ");
                }
                response.Append("|\n");
                response.Append(GenerateDivider());
            }

            return response.ToString();

        }
    }
}