using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public class SysCache
    {
        private SysCache() // Constructeur privé
        {
            // Pas d'InitializeComponent nécessaire
        }
        private static SysCache _instance;

        public static SysCache instance
        {
            get
            {
                // Check if the instance is null, if so, create a new instance
                if (ReferenceEquals(_instance, null))
                {
                    _instance = new SysCache();
                }

                return _instance;
            }
        }

        public string TextValue { get; set; }

        //public double Pi { get; set; } // As a global variable, not a constant
        public double Pi { get; } = 3.14159265358979323846; // Using a read-only property to represent Pi


    }
}
