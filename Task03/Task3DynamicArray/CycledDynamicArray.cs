using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3DynamicArray
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public override bool MoveNext()
        {
            if (position == Length - 1)
            {
                position = 0;
                return true;
            }
            position++;
            return true;
        }
    }
}
