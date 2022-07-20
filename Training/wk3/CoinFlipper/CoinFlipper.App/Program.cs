using CoinFlipper.Data;

namespace CoinFlipper.App
{
    class Program
    {
        static void Main()
        {
            string connectionString = File.ReadAllText("C:/Revature/ConnectionStrings/220705-DB.txt");
            IRepository repo = new SqlRepository(connectionString);

            Game game = new Game(repo);
            Console.WriteLine("Welcome to CoinFlipper.");
            game.StartNewGame();
        }
    }
}