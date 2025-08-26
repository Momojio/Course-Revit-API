using Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCache
{
    internal class CaculateArea
    {


        public static double GetArea(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius cannot be negative.", nameof(radius));
            }

            return SysCache.instance.Pi * radius * radius;
        }
    }
}
