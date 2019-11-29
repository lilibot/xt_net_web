using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString str1 = new MyString("Привет");
            MyString str2 = new MyString(new char[] {'П','р','и','в','е','т' });
            MyString str3 = new MyString("aaaaaa");
            Console.WriteLine($"{str1} == {str2} {str1 == str2}");
            Console.WriteLine($"{str1} == {str3} {str1 == str3}");
            Console.WriteLine($"{str1} != {str2} {str1 != str2}");
            Console.WriteLine($"{str1} + {str2} = {(str1 + str2).ToString()}");
            Console.WriteLine($"{str1} IndexOF 'в' {str1.IndexOf('в')} ");
            Console.WriteLine($"{str1} Insert 'aaa' 3 = {str1.Insert(new MyString("aaa"),3)} ");
            Console.WriteLine($"{str1} ToUpper  = {str1.ToUpper()} ");
            Console.WriteLine($"{str1} ToLower = {str1.ToLower()} ");
            Console.WriteLine($"{str1} Contains \"иве\"= {str1.Contains(new MyString("иве"))} ");
            Console.WriteLine($"{str1} Contains \"l\"= {str1.Contains(new MyString("l"))} ");
            Console.WriteLine($"{str1} StartsWith \"Пр\"= {str1.StartsWith(new MyString("Пр"))} ");
            Console.WriteLine($"{str1} StartsWith \"l\"= {str1.StartsWith(new MyString("l"))} ");
            Console.WriteLine($"{str1} EndsWith \"вет\"= {str1.EndsWith(new MyString("вет"))} ");
            Console.WriteLine($"{str1} EndsWith \"l\"= {str1.EndsWith(new MyString("l"))} ");
            Console.ReadKey();


        }
    }
}
