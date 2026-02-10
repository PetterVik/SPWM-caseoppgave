using System;

namespace SPWM.Assignment
{
    public class TWRCalculator
    {
        private static readonly decimal[] dailyReturns =
        [
                0,
                0,
                -0.006253657m,
                -0.00361612m,
                -0.004777986m,
                -0.026842209m,
                0.000095331m,
                0,
                0,
                -0.004793408m
            ];

        public static decimal CalculateTWR(decimal[] dailyReturns)
        {
            if (dailyReturns == null || dailyReturns.Length == 0) return 0;

            decimal TWR = 1.0m;

            foreach (decimal dailyReturn in dailyReturns)
            {
                TWR *= 1 + dailyReturn;
            }

            return TWR - 1;
        }

        static void Main(string[] args)
        {
            decimal twr = CalculateTWR(dailyReturns);
            Console.WriteLine($"TWR Result: {twr}");
        }
    }
}

