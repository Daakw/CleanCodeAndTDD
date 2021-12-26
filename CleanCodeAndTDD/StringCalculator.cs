using System;
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
        public static int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers)) {
                return 0;
            }
    
            if (HasMultipleDelimiters(numbers)) {
                return MultipleDelimiters(numbers);
            }
                
            if (HasDelimiter(numbers)) { 
                return SingleDelimiter(numbers);
            }

            return DefaultDelimiters(numbers);
        }

        private static int DefaultDelimiters(string numbers)
        {
            return NumbersFromString(NumberSplit(numbers, new string[] { "\n", "," }));
        }

        private static bool HasDelimiter(string delimiter)
        {
            return delimiter.StartsWith("//");
        }

        private static bool HasMultipleDelimiters(string delimiters)
        {
            return delimiters.Contains(']') && delimiters.Contains('[');
        }

        private static string[] NumberSplit(string numbers, string[] delimiters)
        {
            return numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void ThrowExceptionIfNegativeNumber(IEnumerable<int> numberArray)
        {
            var negativeNumbers = numberArray.Where(number => number < 0);
            if (negativeNumbers.Any())
            {
                string negativeString = String.Join(',', negativeNumbers
                .Select(n => n.ToString()));

                throw new ArgumentException($"Negative numbers not allowed: {negativeString}");
            }
        }

        private static int SingleDelimiter(string numbers)
        {
            var delimiter = numbers.Skip(2).Take(1).Select(c => c.ToString()).ToArray();
            string stringWithoutDelimiter = numbers[(numbers.IndexOf('\n') + 1)..];
           
            return NumbersFromString(NumberSplit(stringWithoutDelimiter, delimiter));
        }

        private static int MultipleDelimiters(string numbers)
        {
            var beginningString = numbers.Substring(2, (numbers.IndexOf("]\n") + 1) - 3);
            string firstNumberInString = numbers.Substring(numbers.IndexOf("]\n") + 1);
            var multipleDelimiters = beginningString.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

            return NumbersFromString(NumberSplit(firstNumberInString, multipleDelimiters));
        }

        private static int NumbersFromString(string[] numbersArray)
        {
            var numbers = numbersArray.Select(theString => int.Parse(theString));
            ThrowExceptionIfNegativeNumber(numbers);

            if (IfNumberIsBiggerThan1000(numbers))
            {
                numbers = numbers.Where(n => n <= 1000);
            }
            return numbers.Sum();
        }

        private static bool IfNumberIsBiggerThan1000(IEnumerable<int> numbers)
        {
            return numbers.Any(num => num > 1000);
        }
    }
}
