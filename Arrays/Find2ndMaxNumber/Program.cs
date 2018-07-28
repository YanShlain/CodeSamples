using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find2ndMaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            int? largestNumber = null;
            int? secondLargestNumber = null;
            int[] array = new int[] { 110, 110, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach(int i in array)
            {
                if  ((largestNumber == null) || (largestNumber.Value < i))
                {
                    secondLargestNumber = largestNumber;
                    largestNumber = i;
                }
                else if (((secondLargestNumber == null) || (secondLargestNumber.Value < i)) && (largestNumber != i))
                {
                    secondLargestNumber = i;
                }
            }

            Console.WriteLine(secondLargestNumber.HasValue ? secondLargestNumber.ToString() : "NULL");

            Console.WriteLine();
            Console.WriteLine("Press ANY Key to continue");
            Console.ReadKey();
        }
    }
}
