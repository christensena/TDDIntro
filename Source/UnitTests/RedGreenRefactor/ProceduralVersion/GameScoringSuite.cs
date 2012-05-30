using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.RedGreenRefactor.ProceduralVersion
{
    [TestFixture]
    public class GameScoringSuite
    {
        private Game game;

        [SetUp]
        public void SharedArrange()
        {
            game = new Game();
        }

        [Test]
        public void OneBowl_GetScore_ShouldReturnNumberOfPinsDown()
        {
            // Arrange
            RunBowlSequence(4);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(4);
        }

        [Test]
        public void MultipleFramesButNeverAllPinsDown_GetScoreShouldReturnSumOfPinsDown()
        {
            // Arrange
            var bowlSequence = new[] {4, 4, 4, 4};
            RunBowlSequence(bowlSequence);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(bowlSequence.Sum());
        }

        [Test]
        public void MultipleFramesIncludingASpare_GetScore_ShouldReturnSumOfPinsDownPlusBowlAfterSpare()
        {
            // Arrange
            var bowlSequence = new[] { 6, 4, 4, 4 };
            RunBowlSequence(bowlSequence);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(bowlSequence.Sum() + 4);
        }

        [Test]
        public void MultipleFrameFoolsSpareStraddlingFrames_GetScore_ShouldReturnSumOfPinsDown()
        {
            // Arrange
            var bowlSequence = new[] { 4, 4, 6, 4 };
            RunBowlSequence(bowlSequence);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(bowlSequence.Sum());
        }

        private void RunBowlSequence(params int[] bowls)
        {
            foreach (var bowl in bowls)
            {
                game.Bowl(bowl);
            }
        }
    }
}