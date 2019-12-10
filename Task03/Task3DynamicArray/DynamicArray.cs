using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>, IEnumerable, ICloneable
    {
        int capacity;
        protected int position = -1;

        public int Capacity
        {
            get => capacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (value >= Length && value <= Capacity)
                {
                    capacity = value;
                }

                else
                {
                    T[] tempArray = new T[value];

                    for (int i = 0; i < value; i++)
                    {
                        if (i < Length)
                            tempArray[i] = this.Array[i];
                        else
                            tempArray[i] = default(T);
                    }
                    if (value < Length)
                        Length = value;
                    Array = tempArray;
                    capacity = value;
                }
            }
        }
        public int Length { get; private set; } = 0;
        public T[] Array { get; private set; }
        public T this[int index]
        {
            get
            {
                if ((index >= Length) || (index < -Length)) throw new ArgumentOutOfRangeException();
                if (index < 0) index = index + Length;
                return Array[index];
            }
            set
            {
                if ((index >= Length) || (index < -Length)) throw new ArgumentOutOfRangeException();
                if (index < 0) index = index + Length;
                Array[index] = value;
            }
        }
        public DynamicArray()
        {
            Array = new T[8];
            Capacity = 8;
        }
        public DynamicArray(int capacity)
        {
            Array = new T[capacity];
            Capacity = capacity;
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            int collectionCount = collection.Count();
            Array = new T[collectionCount];
            Capacity = collectionCount;
            Length = collectionCount;
            int index = 0;
            foreach (var element in collection)
            {
                Array[index] = element;
                index++;
            }
        }
        public void Add(T element)
        {
            if (Capacity == Length)
            {
                Capacity *= 2;
                T[] tempArray = new T[Capacity];
                for (int i = 0; i < Length; i++)
                {
                    tempArray[i] = Array[i];
                }
                Array = tempArray;
            }
            Array[Length] = element;
            Length++;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            int freeCellsCount = Capacity - Length;
            if (freeCellsCount < collection.Count())
            {
                Capacity += collection.Count() - freeCellsCount;
            }
            foreach (var element in collection)
            {
                Add(element);
            }
        }
        public bool Remove(T element)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Array[i].Equals(element))
                {
                    for (int j = i; j < Length - 1; j++)
                    {
                        Array[j] = Array[j + 1];
                    }
                    Array[Length - 1] = default(T);
                    Length--;
                    return true;
                }
            }
            return false;
        }
        public bool Insert(T element, int index)
        {
            if (index >= Length || index < 0)
            { throw new ArgumentOutOfRangeException("The index is outside the bounds of the array"); }
            Add(element);
            for (int i = Length - 1; i > index; i--)
            {
                Array[i] = Array[i - 1];
            }
            Array[index] = element;
            return true;
        }


        public virtual IEnumerator<T> GetEnumerator()
        {
            return this;
            //for (int i = 0; i < this.Length; i++)
            //{
            //    yield return this[i];
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            var clone = new DynamicArray<T>(this);
            clone.Length = Length;
            return clone;
        }
        public T[] ToArray()
        {
            T[] simpleArray = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                simpleArray[i] = Array[i];
            }
            return simpleArray;
        }
        public virtual bool MoveNext()
        {
            if (position == Length - 1)
            {
                Reset();
                return false;
            }
            position++;
            return true;
        }

        public void Reset()
        {
            position = -1;
        }

        public T Current
        {
            get
            {
                return Array[position];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();
        public void Dispose() { }

    }
}
