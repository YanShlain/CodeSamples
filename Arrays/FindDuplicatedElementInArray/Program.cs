using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDuplicatedElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] array = new int[] { 110, 110, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                int result = FindDuplicatedELementInNN(array);
                Console.WriteLine(result);

                int result2 = FindDuplicatedELementInLogN(array);
                Console.WriteLine(result2);

                int result3 = FindDuplicatedELementInN(array);
                Console.WriteLine(result3);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Execution failed. " + ex.ToString());
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press ANY Key to continue");
                Console.ReadKey();
            }
        }


        public static int FindDuplicatedELementInNN(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int y = i +1; y < array.Length; y++)
                {
                    if (array[i] == array[y])
                    {
                        return array[i];
                    }
                }
            }

            return int.MinValue;
        }

        public static int FindDuplicatedELementInLogN(int[] array)
        {
            HashSet<int> frequence = new HashSet<int>();
            foreach(int i in array)
            {
                if (frequence.Contains(i))
                    return i;

                frequence.Add(i);
            }

            return int.MinValue;

        }

        public static int FindDuplicatedELementInN(int[] array)
        {

            int?[] frequence = new int?[array.Length];
            foreach (int i in array)
            {
                if (frequence[i].HasValue)
                    return i;

                frequence[i] = 0;
            }

            return int.MinValue;

        }

    }
}
