using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance1
{
    public class PolicyCalculator
    {
        double Value;
        public double getPriceNoClaims(double value)
        {
            Value = value;
            //Find out age if any driver is chauffer or accountant 
            foreach(var driver in Drivers.driverOccupation)
            {
                if (driver == "Chauffeur")
                {
                    value = value * 1.10;
                }
                if (driver == "Accountant")
                {
                    value = value * 0.9;
                }
            }

            List<int> ages = new List<int>();
            foreach (DateTime driverDob in Drivers.driverDOB)
            {
                var start = Class1.quoteStart;
                var age = start.Year - driverDob.Year;
                if (driverDob > start.AddYears(-age)) age--;
                ages.Add(age);  
            }

            int lowest_age = ages.Min();

            if (lowest_age >= 21 && lowest_age < 26) {
                value = value * 1.2;
            }
            else if (lowest_age >= 26 && lowest_age < 76) {
                value = value * 0.9;
            }
            else {
                value = -1;
            }
            return value;
        }
        

    }
}
