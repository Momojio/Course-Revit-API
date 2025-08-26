using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RevitTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //属性与
            Person person = new Person();
            person.name = "Test";
            Console.WriteLine(Person.Sex());
            //Console.WriteLine(Person.Age());
            Console.WriteLine(person.Sclass = "02");
            Console.WriteLine(person.Age());
            Console.WriteLine(person.name);
            Console.ReadKey();
            //列表
            List<int> a = new List<int>();
            a.Add(1);
            a.Add(2);


            int[] b = new int[2];
            b[0] = 1;

            NewMethod(2,4);

        }

        //refactoring, resharper
        private static void NewMethod(int a, int b)
        {
            int c = a + b;
            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}
