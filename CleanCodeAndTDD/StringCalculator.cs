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
        internal static int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }
            else if (numbers.Contains(','))
            {
                var stringArray = numbers.Split(",");
                return stringArray.Select(x => int.Parse(x)).Sum();
            }
            else
            {
                return int.Parse(numbers);
            }
            
        }

    }
}
