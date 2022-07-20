using CoinFlipper.Data;
using CoinFlipper.Logic;

namespace CoinFlipper.App
{
    internal class Game
    {
        // Fields
        string? player;
        bool gameLoop = true;
        string? choice;
        private readonly IRepository repo;


        // Constructor

        public Game(IRepository repo)
        {
            this.repo = repo;
        }

        // Methods

        public void StartNewGame()
        {

            while (gameLoop)
            {
                choice = MainMenu();
                switch (choice)
                {
                    case "0":
                    {
                        gameLoop = false;
                        Console.WriteLine("Exiting");
                        break;
                    }
                    case "1":
                    {
                        do
                        {
                            SetPlayer();
                        } while (player == null);
                        break;
                    }
                    case "2":
                    {
                        ReadyRound();
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid input, please try again.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
            }
        }

        private string? MainMenu()
        {
            if (player != null)
            {
                Console.WriteLine("Hello " + player);
            }
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Enter Player Name");
            Console.WriteLine("[2] Play Round");
            Console.WriteLine("[3] View Player Records");
            Console.Write("Your Selection: ");
            return Console.ReadLine();
        }

        private void SetPlayer()
        {
            if (player == null)
            {
                Console.Write("Please enter your name: ");
                string? tmp = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("You entered: " + tmp);
                Console.Write("Is this correct? [y/n] : ");
                string? yn = Console.ReadLine();
                player = (yn.ToLower() == ("y") ? tmp : null);
            }
            else
            {
                Console.WriteLine("Player is currently " + player);
                Console.Write("Do you want to change players? [y/n] : ");
                string? yn = Console.ReadLine();
                if (yn.ToLower() == "y")
                {
                    player = null;
                }
            }
            Console.Clear();
        }

        private void ReadyRound()
        {
            Console.Clear();

            Random random = new Random();

            bool roundLoop = true;
            Round round = new Round(random.Next(2));

            while (roundLoop)
            {
                Console.WriteLine("Heads or Tails? [h/t]");
                Console.WriteLine("Or enter 0 to abandon the round.");
                Console.Write("Your selection: ");
                string? pick = Console.ReadLine();
                if (pick != null)
                {
                    pick = pick.ToLower();
                }

                switch (pick)
                {
                case "0":
                    {
                        roundLoop = false;
                        Console.WriteLine("Exiting round.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                case "h":
                    {
                        Console.WriteLine(round.PlayRound(0));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        this.RecordRound(0, round);
                        roundLoop = false;
                        break;
                    }
                case "t":
                    {
                        Console.WriteLine(round.PlayRound(1));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        this.RecordRound(1, round);
                        roundLoop = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid input, please try again");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
            }
        }

        private void RecordRound(int playerChoice, Round round)
        {
            if (player == null)
            {
                return;
            }
            repo.CreateNewRound(player, playerChoice, round);
        }
    }
}
