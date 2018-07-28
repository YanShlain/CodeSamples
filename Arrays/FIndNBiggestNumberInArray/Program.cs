using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIndNBiggestNumberInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] biggestNumbers = new int[6];

                int sixBiggestNumber = int.MinValue;
                int sixBiggestNumberPosition = int.MinValue;

                int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                // Fill 6 first numbers
                for (int i = 0; i < 6; i++)
                {
                    biggestNumbers[i] = array[i];
                }

                sixBiggestNumberPosition = GetSmallestNumberPosition(biggestNumbers);
                sixBiggestNumber = array[sixBiggestNumberPosition];

                // Find the number
                for (int i = 6; i < array.Length; i++)
                {
                    if (sixBiggestNumber < i)
                    {
                        biggestNumbers[sixBiggestNumberPosition] = array[i];
                        sixBiggestNumberPosition = GetSmallestNumberPosition(biggestNumbers);
                        sixBiggestNumber = biggestNumbers[sixBiggestNumberPosition];
                    }
                }

                Console.WriteLine("The six biggest number is " + sixBiggestNumber);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Execution failed. " + ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press ANY Key to continue");
                Console.ReadKey();
            }
        }


        internal static int GetSmallestNumberPosition(int[] array)
        {
            if ((array == null) || (array.Length == 0))
                throw new ArgumentOutOfRangeException();

            int smallestNumberPosition = 0;
            int smallestNumber = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (smallestNumber > array[i])
                {
                    smallestNumber = array[i];
                    smallestNumberPosition = i;
                }
            }

            return smallestNumberPosition;
        }
    }

    //try
    //{
    //
    //}
    //catch(Exception ex)
    //{
    //    Console.WriteLine("Execution failed. " + ex.ToString());
    //}
    //finally
    //{
    //    Console.WriteLine();
    //    Console.WriteLine("Press ANY Key to continue");
    //    Console.ReadKey();
    //}

}
