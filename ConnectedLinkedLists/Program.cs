using System;
using System.Collections.Generic;

namespace ConnectedLinkedLists
{
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Excercise: Check if two linked lists are connected and print the first common item.");

                LinkedList<int> leftList = new LinkedList<int>(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 });
                LinkedList<int> rightList = new LinkedList<int>(new int[] { 11, 12, 13, 14, 15, 60, 70, 80, 90 });

                FindFirstCommonItem(leftList, rightList);


                leftList = new LinkedList<int>(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 });
                rightList = new LinkedList<int>(new int[] { 70, 80, 90 });

                FindFirstCommonItem(leftList, rightList);


                leftList = new LinkedList<int>(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 });
                rightList = new LinkedList<int>(new int[] { 190 });

                FindFirstCommonItem(leftList, rightList);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Execution failed." + ex);
            }
            finally
            {
                Console.WriteLine("Press ANY key to exit...");
                Console.ReadKey();
            }

        }

        private static void FindFirstCommonItem(LinkedList<int> leftList, LinkedList<int> rightList)
        {
            Console.WriteLine($"{nameof(leftList)}: " + string.Join(" -> ", leftList));
            Console.WriteLine($"{nameof(rightList)}: " + string.Join(" -> ", rightList));

            if ((leftList == null) || (leftList.Count == 0))
                throw new ArgumentOutOfRangeException(nameof(leftList));

            if ((rightList == null) || (rightList.Count == 0))
                throw new ArgumentOutOfRangeException(nameof(rightList));

            var leftListNode = leftList.First;
            if (leftList.Count > rightList.Count)
            {
                for (int i = 0; i < leftList.Count - rightList.Count; i++)
                    leftListNode = leftListNode.Next;
            }

            var rightListNode = rightList.First;
            if (leftList.Count < rightList.Count)
            {
                for (int i = 0; i < rightList.Count - leftList.Count; i++)
                    rightListNode = rightListNode.Next;
            }

            int minItems = (leftList.Count < rightList.Count) ? leftList.Count : rightList.Count;
            int pos;

            for (pos = 0; (pos < minItems) && (leftListNode.Value != rightListNode.Value); pos++)
            {
                leftListNode = leftListNode.Next;
                rightListNode = rightListNode.Next;
            }

            string result = (pos == minItems) ? "Not found" : leftListNode.Value.ToString();
            Console.WriteLine($"The first common item position is {result}.");
            Console.WriteLine();
        }
    }
}
