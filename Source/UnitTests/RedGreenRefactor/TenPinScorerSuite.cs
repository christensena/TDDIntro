using FluentAssertions;
using NUnit.Framework;
using RedGreenRefactor;

namespace UnitTests.RedGreenRefactor
{
    [TestFixture]
    public class TenPinScorerSuite
    {
        [Test]
        public void GetScore_NoPinsBowled_ShouldReturnZero()
        {
            // Arrange
            var tenPinScorer = new TenPinScorer();

            // Act
            var score = tenPinScorer.GetScore();

            // Assert
            score.Should().Be(0);
        }

        [Test]
        public void GetScore_SingleBowl_ShouldReturnNumberOfPinsDownFromThatBowl()
        {
            // Arrange
            var tenPinScorer = new TenPinScorer();

            tenPinScorer.Bowl(4);

            // Act
            var score = tenPinScorer.GetScore();

            // Assert
            score.Should().Be(4);
        }

        [Test]
        public void GetScore_TwoBowlsSumLessThan10_ShouldReturnSumOfPinsDown()
        {
            // Arrange
            var tenPinScorer = new TenPinScorer();

            tenPinScorer.Bowl(4);
            tenPinScorer.Bowl(5);

            // Act
            var score = tenPinScorer.GetScore();

            // Assert
            score.Should().Be(4 + 5);
        }

        [Test]
        public void GetScore_TwoFramesFirstIsSpare_ShouldBeSumOfBowlsPlusFirstBowlAfterSpare()
        {
            // Arrange
            var tenPinScorer = new TenPinScorer();

            tenPinScorer.Bowl(7);
            tenPinScorer.Bowl(3);

            tenPinScorer.Bowl(3);
            tenPinScorer.Bowl(3);

            // Act
            var score = tenPinScorer.GetScore();

            // Assert
            score.Should().Be(10 + 3 + 3 + 3);
        }

        [Test]
        public void GetScore_TwoFramesFirstWasStrike_ShouldBeSumOfBowlsPlusFirstTwoBowlsAfterStrike()
        {
            // Arrange
            var tenPinScorer = new TenPinScorer();

            tenPinScorer.Bowl(10);

            tenPinScorer.Bowl(5);
            tenPinScorer.Bowl(3);

            // Act
            var score = tenPinScorer.GetScore();

            // Assert
            score.Should().Be(10 + 8 + 5 + 3);
        }
    }
}