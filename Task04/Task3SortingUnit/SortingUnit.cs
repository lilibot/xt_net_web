using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task3SortingUnit
{
    delegate void SortingHandler(string message);
    class SortingUnit
    {
        //static private event SortingHandler OnSortIsFinished;
        static public event SortingHandler OnSortIsFinished;
        public static void ArraySort<T>(T[] array, Func<T, T, bool> comparePredicate)
        {
            if (comparePredicate == null) throw new ArgumentNullException("Func compare = null");
            T temp = default(T);
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparePredicate(array[i], array[j]))
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public static void SortArrayInNewThread<T>(T[] array, Func<T, T, bool> comparePredicate)
        {

            new Thread(() =>
            {
                ArraySort(array, comparePredicate);
                OnSortIsFinished?.Invoke($"Sorting is finished. Thread hashcode: {Thread.CurrentThread.GetHashCode()} ");
            }).Start();
            Thread.Sleep(300);
        }

    }
}
