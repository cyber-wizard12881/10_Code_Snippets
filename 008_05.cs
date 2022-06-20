/*
 * 5. There are P pirates, they must decide how to distribute G gold coins among them. The pirates have seniority levels, the senior-most is 1, then 2, then 3, then 4, and finally the junior-most is P.

Rules of distribution are:

The most senior pirate proposes a distribution of coins.
All pirates vote on whether to accept the distribution.
If the distribution is accepted, the coins are disbursed and the game ends.
If not, the proposer is thrown and dies, and the next most senior pirate makes a new proposal to begin the system again.
In case of a tie vote the proposer can has the casting vote
Rules every pirates follows.

Every pirate wants to survive
Given survival, each pirate wants to maximize the number of gold coins he receives.

Find the maximum number of gold coins that pirate 1 might get?
 */
using System;
using System.Collections.Generic;

namespace PiratesNGoldCoins
{
    class PiratesNGoldCoins
    {
        public static string InputMessage = "Enter No. of Pirates and Gold Coins (P,G):";

        //The Driver Method that calls the Allocator
        public static void Solve(string inputs, out string output)
        {
            var input = inputs.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var Pirates = Convert.ToInt32(input[0]);
            var GoldCoins = Convert.ToInt32(input[1]);

            var allocation = AllocateGoldCoinsToPirates(Pirates, GoldCoins);
            output = $"Allocation of Coins to Pirates are as follows: {allocation}";
        }

        //The Allocator Method that does the Actual Logic of Allotment
        private static string AllocateGoldCoinsToPirates(int pirates, int goldCoins)
        {
            int countOfPiratesSoFar = 0;
            var allocationQueue = new List<int>();

            allocationQueue.Add(goldCoins);

            for (countOfPiratesSoFar = 0; countOfPiratesSoFar <= pirates - 2; countOfPiratesSoFar++)
            {
                if (countOfPiratesSoFar % 2 == 0)
                    allocationQueue.Add(0);
                else
                {
                    allocationQueue.Add(1);
                    allocationQueue[0]--;
                }
            }
            var allocation = allocationQueue.ConvertAll(q => Convert.ToString(q));
            return string.Join(",", allocation);
        }
    }
}
