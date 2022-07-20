using CoinFlipper.Logic;
using System.Data.SqlClient;

namespace CoinFlipper.Data
{
    public class SqlRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;

        // Constructor
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString)); ;
        }


        // Methods
        public int EnsurePlayerExistsAndGetId(SqlConnection connection, string player)
        {
            string cmdText = @"SELECT Id
                               FROM CF.Player
                               WHERE Name = @playerName;";
            using (SqlCommand cmd = new SqlCommand(cmdText, connection))
            {
                cmd.Parameters.AddWithValue("@playerName", player);

                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }

            string cmd2Text = @"INSERT INTO CF.Player (Name)
                                VALUES
                                (@playerName);

                                SELECT Id 
                                FROM CF.Player
                                WHERE Name = @playerName;";
            using SqlCommand cmd2 = new SqlCommand(@cmd2Text, connection);
            cmd2.Parameters.AddWithValue("@playerName", player);

            using SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            return reader2.GetInt32(0);
        }

        public void CreateNewRound(string player, int playerChoice, Round round)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            int playerId = EnsurePlayerExistsAndGetId(connection, player);
            string cmdText = @"INSERT INTO CF.Round (PlayerId, PlayerChoice, FlipResult)
                               VALUES
                               (@p, 
                               (SELECT Id FROM CF.Flips WHERE Name = @pc),
                               (SELECT Id FROM CF.Flips WHERE Name = @f));";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@p", playerId);
            cmd.Parameters.AddWithValue("@pc", ((playerChoice == 0) ? "Heads" : "Tails"));
            cmd.Parameters.AddWithValue("@f", ((round.flip == 0) ? "Heads" : "Tails"));

            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}