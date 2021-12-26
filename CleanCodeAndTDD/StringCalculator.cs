﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestProjectCleanCodeAndTDD")]
namespace CleanCodeAndTDD
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }
            else if (HasDelimiter(numbers))
            {
                string[] stringArray;

                if (HasDelimiterDeclaration(numbers))
                {
                    if (IsDelimiterString(numbers))
                    {
                        var delimiterStartIndex = 3;
                        var delimiterEndIndex = numbers.IndexOf("]\n");
                        var delimiterLenght = delimiterEndIndex - delimiterStartIndex;
                        var delimiterString = numbers.Substring(delimiterStartIndex, delimiterLenght);

                        stringArray = FindStringArray(numbers, new string[] { delimiterString });

                        return SumOfNumbers(stringArray);
                    }

                    char delimiter = numbers.Skip(2).Take(1).First();

                    stringArray = FindStringArray(numbers, new string[] { delimiter.ToString() });
                    return SumOfNumbers(stringArray);
                }

                var separators = new string[] { ",", "\n" };
                stringArray = numbers.Split(separators, StringSplitOptions.None);

                return SumOfNumbers(stringArray);
            }
            else
            {
                return int.Parse(numbers);
            }
        }

        private static bool IsDelimiterString(string numbers)
        {
            return numbers.StartsWith("//[") && numbers.Contains("]\n");
        }

        private static int SumOfNumbers(string[] stringArray)
        {
            var numberArray = stringArray.Select(str => int.Parse(str));

            if (HasNegatives(numberArray))
            {
                throw new ArgumentException($"Negative numbers not allowed: {ListNegatives(numberArray)}");
            }
            
            if (HasNumbersGreaterThan1000(numberArray))
            {
                numberArray = numberArray.Where(n => n <= 1000);
            }

            return numberArray.Sum();
        }

        private static bool HasNumbersGreaterThan1000(IEnumerable<int> numberArray)
        {
            return numberArray.Any(num => num > 1000);
        }

        private static string ListNegatives(IEnumerable<int> numberArray)
        {
            return string.Join(", ", numberArray.Where(n => n < 0));
        }

        private static bool HasNegatives(IEnumerable<int> numberArray)
        {
            return numberArray.Any(num => num < 0);
        }

        private static string[] FindStringArray(string numbers, string[] delimiter)
        {
            string[] stringArray;
            var startIndexOfString = numbers.IndexOf("\n");
            string? cleanedString = numbers.Substring(startIndexOfString + 1);
            stringArray = cleanedString.Split(delimiter, StringSplitOptions.None);

            return stringArray;
        }

        private static bool HasDelimiter(string numbers)
        {
            return numbers.Contains(',') || numbers.Contains('\n');
        }

        private static bool HasDelimiterDeclaration(string numbers)
        {
            return numbers.Contains("//") && numbers.Contains("\n");
        }

    }
}
