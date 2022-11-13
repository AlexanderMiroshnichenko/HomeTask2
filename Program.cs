using System;
using System.Collections.Generic;
namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -3, 0, 2, 4, 5 };
            int k = 6;
            int[] result = Calc4(array, k);

            Console.WriteLine($"[{result[0]},{result[1]}]");

        }



        static int[] Calc1(int[] array, int k) //Перебор всех пар: время работы O(n^2), Память O(1)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == k)
                    {
                        return new int[] { array[i], array[j] };
                    }
                   
                }
            }
          return null;
        }

        static int[] Calc2(int[] array, int k) //Хэш сет: время работы O(n), Память O(n)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < array.Length; i++)
            {
                int numberToFind = k - array[i];
                if (set.Contains(numberToFind))
                {
                    return new int[] { numberToFind, array[i] };
                }
                set.Add(array[i]);
            }
                return null;
        }
        static int[] Calc3(int[] array, int k) //Бинарный поиск: время работы O(nlogn), память O(1), если массив отсортирован
        {
            for (int i = 0; i < array.Length; i++)
            {
                int numberToFind = k - array[i];
                int l = i + 1;
                int r = array.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (array[mid] == numberToFind)
                    {
                       return new int[] { numberToFind, array[i] };
                    }
                    if (numberToFind < array[mid])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

            }
                return null;
        }

        static int[] Calc4(int[] array, int k) //Два указателя: время работы O(n), Память O(1), самый оптимальный
        {
            int l = 0;
            int r = array.Length - 1;
            while (l < r)
            {
                int sum = array[l] + array[r];
                if (sum == k)
                {
                    return new int[] { array[l], array[r] };
                }
                if (sum < k)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return null;
        }





    }

}
