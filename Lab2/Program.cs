 using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsLab2
{
    internal class ProgramMethods
    {
        /// <summary>
        /// Runs Program 1: Count occurrences of a number in a list.
        /// </summary>
        public void RunProgramOne()
        {
            // Obtain an integer from the user
            Console.WriteLine("Enter a number to check: ");
            string userInput = Console.ReadLine();
            int userNumber;

            // Ensure the input is a valid integer
            while (!int.TryParse(userInput, out userNumber))
            {
                Console.Write("Only integers are allowed. Please enter again: ");
                userInput = Console.ReadLine();
            }
            userNumber = Convert.ToInt32(userInput);

            // Create a list with user inputs
            List<int> numberList = new List<int>();
            string listInput;

            do
            {
                Console.Write("Enter a number for the list (enter 'done' to finish): ");
                listInput = Console.ReadLine();

                if (listInput == "done")
                {
                    break;
                }

                int number;

                while (!int.TryParse(listInput, out int parsedNumber))
                {
                    Console.Write("Only integers are allowed. Please enter again: ");
                    listInput = Console.ReadLine();
                }

                number = Convert.ToInt32(listInput);
                numberList.Add(number);
            } while (listInput != "done");

            // Count the occurrences of the user's number in the list
            CountOccurrences(userNumber, numberList);
            Console.ReadKey();
        }

        /// <summary>
        /// Counts the occurrences of a number in a list.
        /// </summary>
        /// <param name="userNumber">The number to count occurrences of.</param>
        /// <param name="anyList">The list to search for occurrences.</param>
        public static void CountOccurrences(int userNumber, List<int> anyList)
        {
            int count = 0;

            foreach (int item in anyList)
            {
                if (userNumber == item)
                {
                    count++;
                }
            }

            Console.WriteLine($"{userNumber} appears {count} times in the list");
        }

        /// <summary>
        /// Runs Program 2: Find unique elements in two lists.
        /// </summary>
        public void RunProgramTwo()
        {
            Console.WriteLine("Enter the first list:");
            List<string> firstList = Console.ReadLine().Split().ToList();

            Console.WriteLine("Enter the second list:");
            List<string> secondList = Console.ReadLine().Split().ToList();

            List<string> uniqueNumbers = firstList.Except(secondList).ToList();

            Console.WriteLine("Unique numbers: [" + string.Join(", ", uniqueNumbers) + "]");
        }

        /// <summary>
        /// Runs Program 3: Analyze a subset of a list based on user-specified indexes.
        /// </summary>
        public void RunProgramThree()
        {
            List<int> numberList = new List<int>();

            try
            {
                // Obtain input for minimum index
                Console.Write("Enter the minimum index: ");
                string minIndexStr = Console.ReadLine();
                int minIndex;

                // Validate the input to be an integer
                while (!int.TryParse(minIndexStr, out minIndex))
                {
                    Console.Write("Please enter a whole number for the minimum index: ");
                    minIndexStr = Console.ReadLine();
                }
                minIndex = Math.Max(minIndex, 0);
            
                minIndex = Convert.ToInt32(minIndexStr);

                // Obtain input for maximum index
                Console.Write("Enter the maximum index: ");
                string maxIndexStr = Console.ReadLine();
                int maxIndex;

                while (!int.TryParse(maxIndexStr, out maxIndex))
                {
                    Console.Write("Please enter a whole number for the maximum index: ");
                    maxIndexStr = Console.ReadLine();
                }

                maxIndex = Convert.ToInt32(maxIndexStr);

                // Create a list and add user inputs to the list
                string numberStr;
                int number;
                bool isUserDone = false;

                while (!isUserDone)
                {
                    Console.Write("Enter a number for the list: ");
                    numberStr = Console.ReadLine();

                    if (numberStr == "done" && numberList.Count > maxIndex)
                    {
                        break;
                    }
                    else if (numberStr == "done" && (numberList.Count < minIndex + 1 || numberList.Count < maxIndex + 1))
                    {
                        Console.WriteLine("Values in the list are not enough for the specified indexes");
                    }

                    if (int.TryParse(numberStr, out number))
                    {
                        number = Convert.ToInt32(numberStr);
                        numberList.Add(number);
                    }
                    else
                    {
                        if (numberStr != "done")
                        {
                            Console.WriteLine("Only integers are allowed");
                        }
                    }
                }

                // Obtain a subset list and display its information
                List<int> subsetList = GetSubsetList(numberList, minIndex, maxIndex);

                Console.WriteLine($"The minimum value of the list is => {subsetList.Min()}");
                Console.WriteLine($"The maximum value of the list is => {subsetList.Max()}");
                Console.WriteLine($"The length of the list is => {subsetList.Count}");
                Console.WriteLine($"The sum of values in the list is => {GetSum(subsetList)}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Gets a subset of a list based on user-specified indexes.
        /// </summary>
        public List<int> GetSubsetList(List<int> list, int index1, int index2)
        {
            List<int> tempList = new List<int>();

            for (int i = index1; i <= index2; i++)
            {
                tempList.Add(list[i]);
            }

            return tempList;
        }

        /// <summary>
        /// Gets the sum of values in a list.
        /// </summary>
        public int GetSum(List<int> list)
        {
            int sum = 0;

            foreach (int item in list)
            {
                sum += item;
            }

            return sum;
        }

        /// <summary>
        /// Runs Program 4: Analyze a list and count various types of numbers.
        /// </summary>
        public void RunProgramFour()
        {
            try
            {
                // Get the sequence of numbers from the user.
                Console.WriteLine("Enter sequence of numbers (separated by space): ");
                string userSequence = Console.ReadLine();

                // Check if the user provided any input.
                if (string.IsNullOrWhiteSpace(userSequence))
                {
                    Console.WriteLine("No input provided. Exiting...");
                    return;
                }

                // Initialize counters for different types of numbers.
                int positiveOddNumbers = 0;
                int positiveEvenNumbers = 0;
                int negativeOddNumbers = 0;
                int negativeEvenNumbers = 0;
                int zeroCount = 0;

                // Split the user input into an array of strings representing numbers.
                string[] numbers = userSequence.Split(' ');

                // Iterate through each number in the array and categorize it.
                foreach (string number in numbers)
                {
                    try
                    {
                        // Convert the string to an integer.
                        int num = Convert.ToInt32(number);

                        // Categorize the number  
                        if (num % 2 == 0)
                        {
                            if (num > 0)
                                positiveEvenNumbers++;
                            else if (num < 0)
                                negativeEvenNumbers++;
                        }
                        else
                        {
                            if (num > 0)
                                positiveOddNumbers++;
                            else if (num < 0)
                                negativeOddNumbers++;
                        }

                        // Check if the number is zero.
                        if (num == 0)
                            zeroCount++;
                    }
                    catch (FormatException)
                    {
                        // Handle the case where the input is not a valid number.
                        Console.WriteLine($"Invalid Input '{number}'. Please enter a valid number.");
                    }
                }

                // Display the count of each type of number.
                Console.WriteLine($"The number of positive odd numbers: {positiveOddNumbers}");
                Console.WriteLine($"The number of positive even numbers: {positiveEvenNumbers}");
                Console.WriteLine($"The number of negative odd numbers: {negativeOddNumbers}");
                Console.WriteLine($"The number of negative even numbers: {negativeEvenNumbers}");
                Console.WriteLine($"The number of zeros: {zeroCount}");
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

    
