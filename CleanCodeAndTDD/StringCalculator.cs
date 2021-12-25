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
            if(numbers == "")
            {
                return 0;
            }

            return int.Parse(numbers);
        }

    }
}
