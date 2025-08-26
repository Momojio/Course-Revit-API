using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProjet.Model
{
    internal class WallCreate//can be created by SQL Server
    {

        public int WallId { get; set; }

        public double WallHeight { get; set; }

        //StartPoint
        public double StartPointX { get; set; }
        public double StartPointY { get; set; }
        public double StartPointZ { get; set; }


        //End of the wall   
        public double EndPointX { get; set; }
        public double EndPointY { get; set; }
        public double EndPointZ { get; set; }

    }
}
