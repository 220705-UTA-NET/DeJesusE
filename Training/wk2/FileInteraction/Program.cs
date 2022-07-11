using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace FileInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Running ...");


            Console.Write("Please provide a file-name: ");

            // // @ at the front of the string, overrides the '\' being used
            // // as a escape character
            string path = @$".\{Console.ReadLine()}";
            Console.WriteLine("Input: {0}", path);

            string? input;

            Person person = new Person("Ellery", 150m, 160m);
            string inputText = person.SerializeAsXML();

            bool loop = true;
            do
            {
                Console.WriteLine("\nPlease select the following options: ");
                Console.WriteLine("Option(A): Read from File");
                Console.WriteLine("Option(B): Replace text within File");
                Console.WriteLine("Option(C): Append to File");
                Console.WriteLine("Option(D): Exit");
                if (!File.Exists(path)) Console.WriteLine("Option(E): Create File");

                input = Console.ReadLine();
                Console.WriteLine();
                if (input == null) input = "null";

                switch (input.ToLower())
                {
                    case "a":
                        if (!File.Exists(path))
                        {
                            Console.WriteLine("File does not exist. Try again !!!");
                        }
                        else
                        {
                            Console.WriteLine("File Contents: ");
                            Console.WriteLine("------------------------------------------------------");
                            string[] readText = File.ReadAllLines(path); // Read the file
                            foreach (string s in readText) // Loop through the string array
                            {
                                Console.WriteLine(s); // print each Line
                            }
                            Console.WriteLine("------------------------------------------------------");
                        }
                        break;
                    case "b":
                        File.WriteAllText(path, inputText);
                        break;
                    case "c":
                        File.AppendAllText(path, inputText);
                        break;
                    case "d":
                        loop = false;
                        break;
                    case "e":
                        Person Q = DeserializeXML(path);
                        Console.WriteLine(Q.name);
                        break;
                    case "f":
                        File.Create(path).Close();
                        break;
                    default:
                        Console.WriteLine("Please provide a valid input !!!");
                        break;
                }
            } while (loop);

            if (input == "d")
            {
                Console.WriteLine("Exiting ...");
            }
            else
            {
                Console.WriteLine("Application finished !!!");
            }


        }

        private static Person DeserializeXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using StreamReader reader = new StreamReader(path);
            Person Q = (Person)serializer.Deserialize(reader);

            return Q;
        }
    }
}
