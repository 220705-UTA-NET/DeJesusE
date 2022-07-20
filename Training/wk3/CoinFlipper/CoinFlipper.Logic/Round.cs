using System.Text;

namespace CoinFlipper.Logic
{
    public class Round
    {
        // Fields
        public int flip;
        
        // Constructors
        public Round(int flip)
        {
            this.flip = flip;
        }

        // Methods
        public string PlayRound(int playerChoice)
        {
            StringBuilder result = new StringBuilder();

            result.Append("Player chose: ");

            if (playerChoice == 0)
                result.AppendLine("Heads");
            else
                result.AppendLine("Tails");

            result.Append("Flip result: ");
            if (flip == 0)
                result.AppendLine("Heads");
            else
                result.AppendLine("Tails");

            result.Append("Round result: You ");
            if (flip == playerChoice)
                result.AppendLine("win!");
            else
                result.AppendLine("lose!");

            return result.ToString();
        }

    }
}