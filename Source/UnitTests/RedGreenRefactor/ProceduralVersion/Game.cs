using System.Collections.Generic;
using System.Linq;

namespace UnitTests.RedGreenRefactor.ProceduralVersion
{
    public class Game
    {
        private IList<int> bowls = new List<int>();

        public void Bowl(int pinsDown)
        {
            bowls.Add(pinsDown);
        }

        public int GetScore()
        {
            var score = bowls.Sum();

            for (var i = 2; i < bowls.Count; i+=2)
            {
                var current = bowls[i];
                var prev = bowls[i - 1];
                var prevPrev = bowls[i - 2];
                if (prevPrev + prev == 10)
                {
                    score += current;
                }
            }

            return score;
        }
    }
}