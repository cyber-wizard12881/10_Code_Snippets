/*
 * 2. Find the 2 closest numbers from a list of random numbers?
 */

void closest_2(int[] numbers)
{
    //sort the random list of numbers!
    List<int> sorted = numbers.OrderBy(n => n).ToList();

    int number1 = 0, number2 = 0;

    //set the closeness to worst case value
    int closeness = int.MaxValue;

    //iterate thru' each of the sorted numbers from smallest to largest
    for (int i=0; i < sorted.Count - 1; i++)
    {
        //if the pair of numbers is closer
        if(sorted[i+1] - sorted[i] < closeness)
        {
            number1 = sorted[i]; //collect the 1st number in the pair being considered
            number2 = sorted[i + 1]; //collect the 2nd number in the pair being considered
            closeness = number2 - number1; //update the closeness
        }
    }

    if(sorted.Count > 0) //if there were an array past to the function
        //print the result!
        Console.WriteLine($"{number1} & {number2} are the closest in the list of integers [{string.Join(',', numbers)}]");
}

int[] numbers = { 2, 5, 8, 12, 1, 20, 24, 29, 33 };
closest_2(numbers);
