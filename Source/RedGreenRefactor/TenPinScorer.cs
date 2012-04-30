using System.Collections.Generic;
using System.Linq;

namespace RedGreenRefactor
{
    public class TenPinScorer
    {
        private int score;
        private readonly Queue<int> lastTwo = new Queue<int>(2);

        public int GetScore()
        {
            return score;
        }

        public void Bowl(int pinsDown)
        {
            score += pinsDown;

            var prev = 0;
            var prevPrev = 0;

            if (lastTwo.Any())
            {
                if (lastTwo.Count > 1)
                {
                    prevPrev = lastTwo.Dequeue();
                    prev = lastTwo.Peek();
                }
                else
                {
                    prev = lastTwo.Peek();
                }
            }

            lastTwo.Enqueue(pinsDown);

            if (prevPrev == 10)
            {
                score += prev + pinsDown;
            }
            else if (prev != 10 && prevPrev != 10 && (prev + prevPrev == 10))
            {
                score += prev;
            }
        }
    }
}