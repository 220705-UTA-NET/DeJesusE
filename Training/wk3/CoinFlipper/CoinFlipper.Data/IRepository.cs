using CoinFlipper.Logic;
using System.Data.SqlClient;

namespace CoinFlipper.Data
{
    public interface IRepository
    {
        void CreateNewRound(string player, int playerChoice, Round round);
        int EnsurePlayerExistsAndGetId(SqlConnection connection, string player);
    }
}
