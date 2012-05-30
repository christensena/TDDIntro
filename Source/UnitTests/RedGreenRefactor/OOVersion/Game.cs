using System.Collections.Generic;
using System.Linq;

namespace UnitTests.RedGreenRefactor.OOVersion
{
    public class Game
    {
        private readonly IList<Frame> frames = new List<Frame>();

        public void Roll(int pinsDown)
        {
            var currentFrame = frames.LastOrDefault();

            if (currentFrame == null || currentFrame.IsComplete)
            {
                var newFrame = new Frame();
                if (currentFrame != null)
                {
                    currentFrame.NextFrame = newFrame;
                }

                frames.Add(newFrame);
            }

            frames.Last().AcceptBowl(pinsDown);
        }

        public int GetScore()
        {
            return frames.Sum(f => f.GetScore());
        }

        private class Bowl
        {
            public int PinsDown { get; private set; }

            public Bowl(int pinsDown)
            {
                PinsDown = pinsDown;
            }

            public bool IsStrike
            {
                get { return PinsDown == 10; }
            }
        }

        private class Frame
        {
            private readonly IList<Bowl> bowls = new List<Bowl>();

            public bool IsComplete
            {
                get 
                {
                    if (!bowls.Any()) return false;

                    return bowls.First().IsStrike || bowls.Count() == 2;
                }
            }

            public bool IsStrike
            {
                get { return IsComplete && bowls.First().IsStrike; }
            }

            public Frame NextFrame { get; set; }

            public Bowl FirstBowl
            {
                get { return bowls.FirstOrDefault(); }
            }

            public int GetScore()
            {
                var score = bowls.Sum(b => b.PinsDown);

                if (IsStrike)
                {
                    if (NextFrame != null)
                    {
                        score += NextFrame.GetScore();
                    }
                }
                else if (bowls.Sum(b => b.PinsDown) == 10)
                {
                    if (NextFrame != null && NextFrame.FirstBowl != null)
                    {
                        score += NextFrame.FirstBowl.PinsDown;
                    }
                }

                return score;
            }

            public void AcceptBowl(int pinsDown)
            {
                bowls.Add(new Bowl(pinsDown));
            }
        }
    }
}