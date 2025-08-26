using Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CaculateArea.GetArea(5)); // Affiche l'aire du cercle avec un rayon de 5
            Console.ReadKey();   
        }
    }
}
