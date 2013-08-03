using System.Linq;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.RedGreenRefactor.ChchAPNLiveCodedVersion
{
    [TestFixture]
    public class TenPinBowlingScorerSuite
    {
        private TenPinBowlingScorer scorer;

        [SetUp]
        public void SharedArrange()
        {
            scorer = new TenPinBowlingScorer();
        }

        [Test]
        public void BowlSingleBall_GetScore_ShouldBeNumberOfPinsDown()
        {
            // Given
            ExecuteBowlSequence(4);

            // When
            var score = scorer.GetScore();

            // Then
            score.Should().Be(4);
        }

        [Test]
        public void MultipleFramesNeverAllPinsDown_GetScore_ShouldReturnSumOfAllPinsDown()
        {
            // Given
            var bowlSequence = new[] {4, 4, 4, 4, 4, 4};
            ExecuteBowlSequence(bowlSequence);

            // When
            var score = scorer.GetScore();

            // Then
            score.Should().Be(bowlSequence.Sum());
        }

        [Test]
        public void MultipleFramesOneFrameIsSpare_GetScore_ShouldReturnSumOfAllPinsDownPlusFirstBowlAfterSpare()
        {
            // Given
            var bowlSequence = new[] {4, 6, 2, 4};
            ExecuteBowlSequence(bowlSequence);

            // When
            var score = scorer.GetScore();

            // Then
            score.Should().Be(bowlSequence.Sum() + 2);
        }

        [Test]
        public void MultipleFramesOneFrameIsSpareStraddlingFrames_GetScore_ShouldReturnSumOfAllPinsDown()
        {
            // Given
            var bowlSequence = new[] { 3, 6, 4, 4 };
            ExecuteBowlSequence(bowlSequence);

            // When
            var score = scorer.GetScore();

            // Then
            score.Should().Be(bowlSequence.Sum());
        }

        private void ExecuteBowlSequence(params int[] bowls)
        {
            foreach (var bowl in bowls)
            {
                scorer.Bowl(bowl);
            }
        }
    }

    public class TenPinBowlingScorer
    {
        private IList<int> bowls = new List<int>();

        public void Bowl(int pinsDown)
        {
            this.bowls.Add(pinsDown);
        }

        public int GetScore()
        {
            var score = bowls.Sum();

            for (var i = 2; i < bowls.Count; i+=2)
            {
                var current = bowls[i];
                var prev = bowls[i - 1];
                var prevPrev = bowls[i - 2];

                if (prev + prevPrev == 10)
                {
                    score += current;
                }
            }
            
            return score;
        }
    }
}