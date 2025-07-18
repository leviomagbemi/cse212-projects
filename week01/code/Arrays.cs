public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create an Array with equal length of the length param number
        double[] multiples = new double[length];

        // Loop until as long "i" is not greater than length
        for (int i = 1; i <= length; i++)
        {
            // Create multiples of "number"
            // Minus 1 from i to start from index 0
            multiples[i - 1] = number * i;
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        int count = data.Count;

        // Prevent amount from exceeding the length of data
        int newAmount = amount % count;

        // Get first part
        List<int> rotatedList = data.GetRange(count - newAmount, newAmount);

        //Get and add second part
        rotatedList.AddRange(data.GetRange(0, count - newAmount));

        // Insert rotated List to main list
        data.InsertRange(0, rotatedList);

        // Remove actual numbers from list
        data.RemoveRange(count, count);
    }
}
