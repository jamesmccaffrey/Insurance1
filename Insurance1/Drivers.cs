using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance1
{
    public static class Drivers
    {
        public static List<String> driverName = new List<string>(); 
        public static List<String> driverOccupation = new List<string>();
        public static List<DateTime> driverDOB = new List<DateTime>();
        public static List<int> numClaims = new List<int>();
        public static List<Claim> claim = new List<Claim>();
        public static double claimStartPolicy { get; set; }
    }
}
