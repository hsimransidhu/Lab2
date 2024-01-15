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

            // Create a list  with user inputs
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
                List<int> numberList = new List<int>();
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
                bool isInputValid = false;
                List<string> inputListStr;
                List<string> inputListStrDone = null;
                List<int> inputListNum = new List<int>();

                while (!isInputValid)
                {
                    // Obtain inputs from the user
                    Console.Write("Enter a sequence of numbers (enter 'done' at the end): ");
                    string inputStr = Console.ReadLine();
                    inputListStr = new List<string>();
                    inputListStrDone = new List<string>();

                    // Create and update the list to remove 'done'
                    inputListStr = inputStr.Split(' ').ToList();
                    inputListStrDone = inputListStr.GetRange(0, inputListStr.Count - 1);

                    int num;

                    // Validate input to be integers
                    if (inputListStrDone.TrueForAll(s => int.TryParse(s, out num))
                        && inputListStr[inputListStr.Count - 1] == "done")
                    {
                        isInputValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter only numbers separated by space (end with 'done')");
                    }
                }

                for (int i = 0; i < inputListStrDone.Count; i++)
                {
                    inputListNum.Add(Convert.ToInt32(inputListStrDone[i]));
                }

                // Obtain and print list information
                GetPositiveEven(inputListNum);
                GetNegativeEven(inputListNum);
                GetPositiveOdd(inputListNum);
                GetNegativeOdd(inputListNum);
                GetNumberOfZeros(inputListNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Gets the number of positive even numbers in a list.
        /// </summary>
       
        public void GetPositiveEven(List<int> list)
        {
            int positiveEvenCount = 0;

            foreach (int item in list)
            {
                if (item % 2 == 0 && item / 2 > 0)
                {
                    positiveEvenCount++;
                }
            }

            Console.WriteLine($"Number of positive even numbers => {positiveEvenCount}");
        }

        /// <summary>
        /// Gets the number of negative even numbers in a list.
        /// </summary>
      
        public void GetNegativeEven(List<int> list)
        {
            int negativeEvenCount = 0;

            foreach (int item in list)
            {
                if (item % 2 == 0 && item / 2 < 0)
                {
                    negativeEvenCount++;
                }
            }

            Console.WriteLine($"Number of negative even numbers => {negativeEvenCount}");
        }

        /// <summary>
        /// Gets the number of positive odd numbers in a list.
        /// </summary> 
        public void GetPositiveOdd(List<int> list)
        {
            int positiveOddCount = 0;

            foreach (int item in list)
            {
                if (item % 2 != 0 && item / 2 > 0)
                {
                    positiveOddCount++;
                }
            }

            Console.WriteLine($"Number of positive odd numbers => {positiveOddCount}");
        }

        /// <summary>
        /// Gets the number of negative odd numbers in a list.
        /// </summary> 
        public void GetNegativeOdd(List<int> list)
        {
            int negativeOddCount = 0;

            foreach (int item in list)
            {
                if (item % 2 != 0 && item / 2 < 0)
                {
                    negativeOddCount++;
                }
            }

            Console.WriteLine($"Number of negative odd numbers => {negativeOddCount}");
        }

        /// <summary>
        /// Gets the number of zeros in a list.
        /// </summary>
  
        public void GetNumberOfZeros(List<int> list)
        {
            int numberOfZeros = 0;

            foreach (int item in list)
            {
                if (item == 0)
                {
                    numberOfZeros++;
                }
            }

            Console.WriteLine($"Number of zeros: {numberOfZeros}");
        }
    }
}
