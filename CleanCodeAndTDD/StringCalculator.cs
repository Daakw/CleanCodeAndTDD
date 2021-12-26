﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestProjectCleanCodeAndTDD")]
namespace CleanCodeAndTDD
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }
            else if ((HasDelimiter(numbers)))
            {
                string[] stringArray;

                if (HasDelimiterDeclaration(numbers))
                {
                    char delimiter = numbers.Skip(2).Take(1).First();
                    string? cleanedString = numbers.Substring(3);
                    stringArray = cleanedString.Split(delimiter);

                    return stringArray.Select(s => int.Parse(s)).Sum();
                }

                var separators = new string[] { ",", "\n" };
                stringArray = numbers.Split(separators, StringSplitOptions.None);

                return stringArray.Select(x => int.Parse(x)).Sum();
            }
            else
            {
                return int.Parse(numbers);
            }

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
