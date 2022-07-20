using Xunit;
using Xunit.Sdk;
using System;
using CoinFlipper.Logic;


namespace CoinFlipper.Tests
{
    // Common practice to have one test class per logical/prgramatic class
    public class RoundTests
    {
        // Typical naming convention of test methods:
        // UnitOfTest_TestCondition_DesiredOutput/Behavior

        [Fact]
        public void PlayRound_Heads_Win()
        {
            // Unit tests are supposed to be laser focused on one behavior of one 
            // small unit of code. To help us do that, we divide the tests into three
            // logcial steps: Arrange, Act, Assert

            // Arrange: What setup needs to take place in order to model the behavior?

            var round = new Round(0);

            // Act: What is the behavior that we are testing?

            var result = round.PlayRound(0);

            // Assert : Check or verify that the behavior was as expected by checking
            // output.

            var expected = "Player chose: Heads\r\nFlip result: Heads" + 
                           "\r\nRound result: You win!\r\n";
            Assert.Equal(expected: expected, actual: result);
        }

        [Fact]
        public void PlayRound_Heads_Lose()
        {
            var round = new Round(1);
            var result = round.PlayRound(0);
            var expected = "Player chose: Heads\r\nFlip result: Tails" +
                           "\r\nRound result: You lose!\r\n";
            Assert.Equal(expected: expected, actual: result);
        }

        [Fact]
        public void PlayRound_Tails_Win()
        {
            var round = new Round(1);
            var result = round.PlayRound(1);
            var expected = "Player chose: Tails\r\nFlip result: Tails" +
                           "\r\nRound result: You win!\r\n";
            Assert.Equal(expected: expected, actual: result);
        }

        [Fact]
        public void PlayRound_Tails_Lose()
        {
            var round = new Round(0);
            var result = round.PlayRound(1);
            var expected = "Player chose: Tails\r\nFlip result: Heads" +
                           "\r\nRound result: You lose!\r\n";
            Assert.Equal(expected: expected, actual: result);
        }
    }
}