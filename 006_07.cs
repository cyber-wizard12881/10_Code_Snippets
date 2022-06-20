
/*
 * 7. Tower of Hanoi is a mathematical puzzle where we have three rods and N disks.
 * The objective of the puzzle is to move the entire stack to another rod,
 * obeying the following simple rules:
1. Only one disk can be moved at a time.
2. Each move consists of taking the upper disk from one of the stacks and placing it on top of another stack i.e. a disk can only be moved if it is the uppermost disk on a stack.
3. No disk may be placed on top of a smaller disk.
 */

List<string> steps = new List<string>();

//   Disks          A         B          C
//   |-1-|          |         |          |
//  |--2--|         |         |          |
// |---3---|        |         |          |

// The Recursive Solver
void tower_of_hanoi(int N, string A, string B, string C)
{
    if (N == 0)
        return;
    tower_of_hanoi(N-1, A, C, B);
    steps.Add($"Moving Disk-{N} from {A} to {B} with {C} as auxiliary peg.");
    tower_of_hanoi(N-1, C, B, A);
}

tower_of_hanoi(3, "A", "B", "C");

foreach (string step in steps)
{
    Console.WriteLine(step);
}
