using System;

namespace Practice
{
    class Calculator
    {
        // Fields


        // Methods
        public void calculate(int num)
        {
            // print every multiple of 3, between 1 and num
            // find the highest number that is a multiple of 3

            int start = num - (num % 3);

            for (int i = start; i >= 3; i -= 3)
            {
                Console.WriteLine($"{i}");
            }

            // Another way to perform this problem
            // while (start >= 3)
            // {
            //     Console.WriteLine($"{start}");
            //     start -= 3;
            // }
        }
    }
}