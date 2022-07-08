using System;

namespace Practice
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Please enter an integer: ");
            string response = Console.ReadLine(); // Console.ReadLine() returns a string

            Calculator calc = new Calculator();

            // try-catch is a graceful way to handle exceptions. Don't let your application crash, handle your exceptions!
            try
            {
                // Don't force the parse and throw exceptions, try it first and if it works, then return true and set the variable n
                // to the output. Otherwise return false.
                // int n;
                // if (int.TryParse(response, out n))
                // {
                //     calc.calculate(n);
                // }
                // else
                // {
                //     Console.WriteLine($"\"{response}\" is not an integer! =(");
                // }

                int num = int.Parse(response); // int.Parse(string) returns an int
                // int number = int.Parse(Console.ReadLine());
                calc.calculate(num);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\"{response}\" is not an integer! =(");
            }


        }

    }
}
