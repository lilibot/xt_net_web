using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost
{
    public static class CollectionsExtension
    {
        public static void RemoveEverySecondElement<T>(ICollection<T> collection)
        {

            for (int i = 1; collection.Count > 1; i ++)
            {
                if (i == collection.Count())
                {
                    i = 0;
                }
                if (i == collection.Count()+1)
                {
                    i = 1;
                }
                Console.WriteLine($"Удален элемент: {collection.ElementAt(i).ToString()}");
                collection.Remove(collection.ElementAt(i));
            }

        }
    }
}
