using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTemplate
{
    internal class Person
    {
        public string name { get; set; }
        string sclass;
        public string Sclass
        {
            get
            {
                return sclass;
            }
            set { sclass = value; }
        }
        //public Person(string name) { 
        //    this.name = name;   
        //}
        
        public int Age() {
            return 3;
        }
        public static string Sex()
        {
            return "Homme";
        }
        private int score;
        //propfull
        public int Score
        {
            get { return score; }
            set { score = value; }
        }



    }
}
