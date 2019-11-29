using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4MyString
{
    internal class MyString
    {
        char[] charArray;

        public MyString(string str)
        {
            charArray = convertStringToCharArray(str);
        }
        public MyString(char[] charArray)
        {
            this.charArray = charArray;
        }
        public int Length
        {
            get => charArray.Length;
        }
        public char this[int pos]
        {
            get
            {
                return this.charArray[pos];
            }
        }
        private char[] convertStringToCharArray(string str)
        {
            char[] tempСharArray = new char[str.Length];
            int count = 0;
            foreach (var c in str)
            {
                tempСharArray[count] = c;
                count++;
            }
            return tempСharArray;
        }
        public override string ToString()
        {
            return new String(this.charArray);
        }

        public char[] ToCharArray()
        {
            char[] tempСharArray = new char[this.Length];
            Array.Copy(this.charArray, 0, tempСharArray, 0, this.Length);
            return tempСharArray;
        }
        public static int Compare(MyString first, MyString second)
        {
            if (object.ReferenceEquals(first, second))
            {
                return 0;
            }

            if (first.Length != second.Length)
            {
                return first.Length < second.Length ? -1 : 1;
            }
            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] < second[i])
                    {
                        return -1;
                    }
                    else if (first[i] > second[i])
                    {
                        return 1;
                    }
                }

                return 0;
            }

        }
        public int IndexOf(char с)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == с)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Equals(MyString myStr)
        {
            if (object.ReferenceEquals(null, myStr))
            {
                return false;
            }

            if (object.ReferenceEquals(this, myStr))
            {
                return true;
            }

            if (this.Length != myStr.Length)
            {
                return false;
            }

            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != myStr[i])
                {
                    return false;
                }
            }

            return true;
        }


        public static bool operator ==(MyString first, MyString second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(MyString first, MyString second)
        {
            return !(first == second);
        }
        public static MyString Concat(MyString first, MyString second)
        {
            char[] resultCharArray = new char[first.Length + second.Length];
            Array.Copy(first.ToCharArray(), 0, resultCharArray, 0, first.Length);
            Array.Copy(second.ToCharArray(), 0, resultCharArray, first.Length, second.Length);
            return new MyString(resultCharArray);
        }
        public static MyString operator +(MyString first, MyString second)
        {
            return Concat(first, second);
        }
        public MyString Insert(MyString charArray, int startIndex)
        {
            if (startIndex < 0 || startIndex > this.Length)
            {
                throw new ArgumentOutOfRangeException("Start index should be positive and less than length of MyString");
            }

            char[] result = new char[this.Length + charArray.Length];
            var thisCharArray = this.ToCharArray();
            Array.Copy(thisCharArray, 0, result, 0, startIndex);
            Array.Copy(charArray.ToCharArray(), 0, result, startIndex, charArray.Length);
            Array.Copy(thisCharArray, startIndex, result, startIndex + charArray.Length, this.Length - startIndex);

            return new MyString(result);
        }
        public MyString ToUpper()
        {
            char[] result = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                result[i] = char.ToUpper(this[i]);
            }

            return new MyString(result);
        }

        public MyString ToLower()
        {
            char[] result = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                result[i] = char.ToLower(this[i]);
            }

            return new MyString(result);
        }
        public bool Contains(MyString charArray)
        {
            if (this.Length < charArray.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.Length - charArray.Length; i++)
                {
                    if (this[i] == charArray[0])
                    {
                        bool f = true;
                        for (int j = 1; j < charArray.Length && f; j++)
                        {
                            f = this[i + j] == charArray[j];
                        }
                        if (f) return true;
                    }
                }
                return false;
            }
        }

        public bool StartsWith(MyString str)
        {
            if (this.Length < str.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (this[i] != str[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool EndsWith(MyString str)
        {
            if (this.Length < str.Length)
            {
                return false;
            }
            else
            {
                int indexThis = this.Length - str.Length;
                for (int i = 0; i < str.Length; i++, indexThis++)
                {
                    if (this[indexThis] != str[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }


    }
}
