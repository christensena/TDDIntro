using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.RedGreenRefactor.OOVersion
{
    [TestFixture]
    public class GameScoringSuite
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void GetScore_NoBowls_ShouldReturnZero()
        {
            var score = game.GetScore();

            score.Should().Be(0);
        }

        [Test]
        public void GetScore_MultipleFramesPinsDownLessThanTenEachFrame_ShouldReturnSumOfPinsDown()
        {
            // Arrange
            var bowlSequence = new[] {4, 5, 4, 3};
            GivenBowlSequence(bowlSequence);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(bowlSequence.Sum());
        }

        [Test]
        public void GetScore_MultipleFrames_SpareFirstFrame_ShouldReturnSumPlusFirstBallAfterSpare()
        {
            // Arrange
            var bowlSequence = new[] { 4, 6, 4, 3 };
            GivenBowlSequence(bowlSequence);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(bowlSequence.Sum() + 4);
        }

        [Test]
        public void GetScore_MultipleFrames_FourthAndFifthBallAddUpToTenButNoSparesOrStrikes_ShouldReturnSum()
        {
            // Arrange
            var bowlSequence = new[] { 3, 6, 4, 3, 7, 2 };
            GivenBowlSequence(bowlSequence);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(bowlSequence.Sum());
        }

        [Test]
        public void GetScore_MultipleFrames_Strike_ShouldReturnSumPlusSumOfTwoBallsAfterStrike()
        {
            // Arrange
            var bowlSequence = new[] { 10, 4, 3 };
            GivenBowlSequence(bowlSequence);

            // Act
            var score = game.GetScore();

            // Assert
            score.Should().Be(bowlSequence.Sum() + 4 + 3);
        }

        private void GivenBowlSequence(params int[] rolls)
        {
            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }
        }
    }
}