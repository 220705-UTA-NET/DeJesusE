using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] array = new char[10, 10];
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    Console.Write($"[{array[i, j]}] ");
                }
                Console.Write("\n");
            }

        }


    }
}
