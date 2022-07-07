// We can include libraries with USING statements
using System;

// A namespace is a collection of classes performing a particular task
namespace CSharpConcepts
{ // curly-braces/brackets signifies a block of code

    // Where our code will start when it is looking to run
    // A class is made of members, fields and methods.
    // - fields are variables
    // - methods are behaviors

    class Program
    {
        // As a language, c# doesn't care about indentations, or whitespace in general

        // modifiers - 
        //  private - limits access to the class to the class itself
        //  static - limits access to the class to the class itself and the class's static methods
        //  public - access is limited ot the class and all its members
        //  internal - access is limited to the class and all of its members, but not to the class's static members
        //  protected - access is limited to the class and all of its members, but not to the class's static members

        // modifiers are used to control access to members of a class


        // [modifier] [return type] [method name]([parameters]);
        static void Main(string[] args)
        {
            // Collections
            // - arrays -  a collection of items of the same type
            // - lists - a collection of items of different types
            // - dictionaries - a collection of key/value pairs
            // - queues - a first-in, first-out collection of items
            // - stacks - a last-in, first-out collectoin of items

            Console.WriteLine("Hello World!");

            // Declaring a variable
            // [type] [variable-name] = [value]
            string s = "Hello World!";
            s = "hello CSharp";

            Console.WriteLine(s);

            // Initialize the value
            string s2;
            s2 = "Hello C#!";

            Console.WriteLine(s2);

            // Numeric data types
            // byte (1 byte), short (2 bytes), int (4 bytes), long (8 bytes)

            // Assignment operator (=)
            int i = 10;

            // logical operators
            true || true; // OR - if ONE condition is true, then return true
            true && false; // AND - if BOTH conditions are true, then return true
            !true; // NOT - returns the opposite value (true if false; false if true)

            // comparison operators
            true == true; // Equal to - returns true if left is equal to right
            true != false; // not equal to - returns true if left is not equal to right
            3 > 3; // greater than - returns true if left is greater than right
            3 < 3; // less than - returns true if left is less than right
            3 >= 3; // greater than or equal to, returns true if left is greater than or equal to right
            3 <= 3; /// less than or equal to

            // control flow

            // conditonal if-statement
            // if ([condition]){[code]}
            if (true == true)
            {
                // code block - perform code within this block is condition equals to true
            }

            // conditional if/else-statement
            // if([condition]){[code]}
            // else{[code]}
            if (true == true)
            {
                // take some action if condition is true
            }
            else
            {
                // take some action if condition is false
            }

            // conditional if/else if/else statement
            // if([condition]){[code]}
            // else if([condition]){[code]}
            // else{[code]}

            if (true == true)
            {
                // take some action if condition is true
            }
            else if (true != true)
            {
                // take some action if condition is true and all preceding conditions were false
            }
            else
            {
                // take some action if condition is false
            }

            // switch statement
            // switch ([expression])
            //      case [case value]:
            //          [code block]
            //          [break/no break];
            //      ...
            //      default:
            //          [code block]
            //          break;

            int i = 2;
            switch (i)
            {
                case 1:
                    Console.WriteLine(1);
                    break;
                case 2:
                    Console.WriteLine(2);
                case 3:
                    Console.WriteLine(3);
                default:
                    Console.WriteLine("Default");
            }






        }

    }

}