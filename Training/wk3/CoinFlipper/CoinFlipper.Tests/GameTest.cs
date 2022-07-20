using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinFlipper.App;
using CoinFlipper.Data;
using Moq;

namespace CoinFlipper.Tests
{
    public class GameTest
    {
        [Fact]
        public void Record_JakeTailsTails_NoReturn()
        {
            Mock<IRepository> mockRepo = new(); // Create the mock repository object

            var game = new Game(mockRepo); // Create the game object
            game.player = "Jake"; // Supply a player name

            mockRepo.Setup(x => x.CreateNewRound(game.player, 0, 0)).Return();
            // Setup the mock repository to accept values and return values as necessary

            // Act

            //Assert
            Assert.Equals(expected: expected, actual: IAsyncResult);

        }

    }
}
