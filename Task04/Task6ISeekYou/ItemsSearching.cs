using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task6ISeekYou
{

    class ItemsSearchingTests
    {
        private readonly Random r = new Random();
        private Stopwatch sw = new Stopwatch();
        private List<int> listForTests = new List<int>();
        private List<long> listOfResultsTicks = null;
        public List<int> ListForTests { get => listForTests; }
        public List<long> ListOfResultsTicks { get => listOfResultsTicks; }
        private int RandomMaxValue { get; } = 100000;
        private int RandomMinValue { get; } = -100000;
        private int CountOfElement { get; } = 10000;
        private int TestsCount { get; } = 10000;
        public long TestsMedian
        {
            get
            {
                if (ListOfResultsTicks == null) throw new ArgumentNullException("ListOfResultsTicks");
                ListOfResultsTicks.Sort();
                int positionMedium;
                long median = 0;
                if (ListOfResultsTicks.Count % 2 == 1)
                {
                    positionMedium = ListOfResultsTicks.Count / 2;
                    median = ListOfResultsTicks[positionMedium];
                }
                else
                {
                    positionMedium = ListOfResultsTicks.Count / 2 - 1;
                    median = (ListOfResultsTicks[positionMedium] + ListOfResultsTicks[positionMedium + 1]) / 2;
                }
                return median;
            }
        }
        public void FillRandomValues(List<int> collection)
        {
            collection.Clear();
            for (int i = 0; i < CountOfElement; i++)
            {
                collection.Add(this.r.Next(this.RandomMinValue, this.RandomMaxValue));
            }
        }
        public List<int> GetNegativeElements(IEnumerable<int> collection)
        {
            var resultCollection = new List<int>();
            foreach (var elem in collection)
            {
                if (elem < 0)
                {
                    resultCollection.Add(elem);
                }
            }

            return resultCollection;
        }
        public List<int> GetNegativeElementsByPredicate(IEnumerable<int> collection, Predicate<int> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            var resultCollection = new List<int>();
            foreach (var elem in collection)
            {
                if (predicate.Invoke(elem))
                {
                    resultCollection.Add(elem);
                }
            }

            return resultCollection;
        }

        public void TestWithSimpleMethod()
        {
            listOfResultsTicks = new List<long>();
            for (int i = 0; i < TestsCount; i++)
            {
                sw.Restart();
                GetNegativeElements(listForTests);
                sw.Stop();
                ListOfResultsTicks.Add(sw.ElapsedTicks);
            }
        }
        public void TestLINQ()
        {
            listOfResultsTicks = new List<long>();
            for (int i = 0; i < TestsCount; i++)
            {
                sw.Restart();
                var resultList = listForTests.Where(x => x < 0).ToList();
                sw.Stop();
                ListOfResultsTicks.Add(sw.ElapsedTicks);
            }
        }
        public void TestMethodWithPredicate(Predicate<int> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            listOfResultsTicks = new List<long>();
            for (int i = 0; i < TestsCount; i++)
            {
                sw.Restart();
                GetNegativeElementsByPredicate(listForTests, predicate);
                sw.Stop();
                ListOfResultsTicks.Add(sw.ElapsedTicks);
            }
        }

    }
}
