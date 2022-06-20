/*
 * 4. There are N persons (1, 2, 3 ... N) who want to cross a bridge in night.

1 takes t1 minute to cross the bridge.
2 takes t2 minutes to cross the bridge.
3 takes t3 minutes to cross the bridge.
      ...................
N takes tN minutes to cross the bridge.

There is only one torch with them and the bridge cannot be crossed without the torch. There cannot be more than two persons on the bridge at any time, and when two people cross the bridge together, they must move at the slower person’s pace. Find the minimum time needed for all the N persons to cross the bridge.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TorchNBridgeProblem
{
    class TorchNBridgeProblem
    {
        public static string InputMessage = "Enter Times for persons to cross the Bridge (t1,t2,...tN):";

        //Driver Method to Call the Problem Solver
        public static void Solve(string inputs, out string output)
        {
            var input = inputs.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(t => Convert.ToInt32(t));
            var personsTimes = new SortedList();
            input.ForEach(i => personsTimes.Add(i, i));
            var totalTime = new List<int>();

            PerformBridgeCross(personsTimes, new SortedList(), totalTime, true);

            output = $"Minimum Total Time for all Persons to Cross the Bridge is: {totalTime.Sum()}";

        }

        //Recursive Method to outline and delineate the Steps
        static void PerformBridgeCross(SortedList bank1, SortedList bank2, List<int> totalTime, bool fromBank1ToBank2)
        {
            if (bank1.Count == 0)
                return;
            else if (fromBank1ToBank2 && bank2.Count == 0)
            {
                var person1 = Convert.ToInt32(bank1.GetByIndex(0));
                var person2 = Convert.ToInt32(bank1.GetByIndex(1));

                totalTime.Add(Math.Max(person1, person2));

                bank2.Add(person1, person1);
                bank2.Add(person2, person2);

                bank1.Remove(person1);
                bank1.Remove(person2);

                PerformBridgeCross(bank1, bank2, totalTime, false);
            }
            else if (fromBank1ToBank2 && bank2.Count > 0)
            {
                var person1 = Convert.ToInt32(bank1.GetByIndex(bank1.Count - 1));
                var person2 = Convert.ToInt32(bank1.GetByIndex(bank1.Count - 2));

                totalTime.Add(Math.Max(person1, person2));

                bank2.Add(person1, person1);
                bank2.Add(person2, person2);

                bank1.Remove(person1);
                bank1.Remove(person2);

                PerformBridgeCross(bank1, bank2, totalTime, false);
            }
            else if (!fromBank1ToBank2)
            {
                var person1 = Convert.ToInt32(bank2.GetByIndex(0));

                totalTime.Add(person1);

                bank1.Add(person1, person1);

                bank2.Remove(person1);

                PerformBridgeCross(bank1, bank2, totalTime, true);
            }
        }
    }
}
