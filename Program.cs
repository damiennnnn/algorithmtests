using System;
using System.Collections.Generic;
namespace sort
{
    class Program
    {


        static void topDownMergeSort(ref int[] a)
        {
            int n = a.Length;
            var b = (int[])a.Clone();
            topDownSplitMerge(ref b, 0, n, ref a);
        }

        static void topDownSplitMerge(ref int[] b, int begin, int end, ref int[] a)
        {
            if (end - begin <= 1)
                return;

            int middle = (begin + end) / 2;
            topDownSplitMerge(ref a, begin, middle, ref b);
            topDownSplitMerge(ref a, middle, end, ref b);
            topDownMerge(ref b, begin, middle, end, ref a);
        }
        static void topDownMerge(ref int[] a, int begin, int mid, int end, ref int[] b)
        {
            int i = begin; int j = mid;
            for (int z = begin; z < end; z++)
            {
                if (i < mid && (j >= end || a[i] <= a[j]))
                {
                    b[z] = a[i];
                    i++;
                }
                else
                {
                    b[z] = a[j];
                    j++;
                }
            }
        }


        static void WriteArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]); Console.Write(" ");
            }
            Console.WriteLine();
        }

        public class BinaryNode
        {
            int val;
            BinaryNode Left;
            BinaryNode Right;

            public BinaryNode(int val = 0, BinaryNode left = null, BinaryNode right = null)
            {
                this.val = val;
                this.Left = left;
                this.Right = right;
            }
        }
        static void fizzBuzz()
        {
            for (int i = 0; i < 100; i++)
            {
                string output = "";
                if (i % 3 == 0) output += "Fizz ";
                if (i % 5 == 0) output += "Buzz ";

                Console.WriteLine(
                    output == "" ? i : output
                );
            }
        }
        static void Main(string[] args)
        {
            //rotateImage();
            fizzBuzz();

        }

        static void binarySearch(int[] nums, int target, int startIndex, int endIndex, ref int index, ref int val)
        {
            int half = (startIndex + endIndex) / 2;

            if (nums[half] > target)
            {
                binarySearch(nums, target, startIndex, half, ref index, ref val);
            }
            else if (nums[half] < target)
            {
                binarySearch(nums, target, half, endIndex, ref index, ref val);
            }
            else if (nums[half] == target)
            {
                index = half;
                val = nums[half];
                return;
            }
        }

        static int[] twoSum(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };
            for (int i = 0; i < nums.Length; i++)
            {
                int second = target - nums[i];
                int index = -1; int val = -1;
                binarySearch(nums, second, 0, nums.Length, ref index, ref val);

                if (index > -1)
                {
                    result[0] = i;
                    result[1] = index;
                    return result;
                }

            }
            return result;
        }

        static void Rotate(int[][] matrix) // int[y][x] work in progress
        {
            for (int y = 0; y < matrix.Length; y++)
            {
                int pos = (matrix.Length - 1) - y;

                for (int x = 0; x < matrix[y].Length; x++)
                {
                    int cur = matrix[y][x];
                    int swap = matrix[x][pos];

                    matrix[x][pos] = cur;
                    matrix[y][x] = swap;
                }
            }
        }

        static void rotateImage()
        {
            int[][] matrix = new int[][]{
                new int[] {1,2,3},
                new int[] {4,5,6},
                new int[] {7,8,9}
            };
            Rotate(matrix);

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    Console.Write(matrix[x][y] + " ");
                }
            }

        }
        public static void listMerge()
        {
            ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            ListNode l3 = MergeTwoLists(l1, l2);

            while (l3 != null)
            {
                Console.Write(l3.val + " ");
                l3 = l3.next;

            }
        }
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode sorted = new ListNode(-1);
            ListNode root = sorted;

            while ((l1 != null) && (l2 != null))
            {
                if (l1.val < l2.val)
                {
                    sorted.next = l1;
                    sorted = sorted.next;
                    l1 = l1.next;
                }
                else
                {
                    sorted.next = l2;
                    sorted = sorted.next;
                    l2 = l2.next;
                }
            }

            while (l1 != null)
            {
                sorted.next = l1;
                sorted = sorted.next;
                l1 = l1.next;
            }
            while (l2 != null)
            {
                sorted.next = l2;
                sorted = sorted.next;
                l2 = l2.next;
            }

            return root.next;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

    }
}
