using System;

namespace basketball_teams.domain
{
    public class Id
    {
        public int Value { get; set; }

        public Id(int value)
        {
            Value = value;
        }

        public Id(bool randomise = false)
        {
            if (randomise)
            {
                Random random = new Random();
                Value = random.Next(10, 100);
            }
        }
    }
}