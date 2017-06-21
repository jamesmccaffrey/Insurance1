using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance1
{
    public class Claim
    {
        public string claimName;
        public DateTime claimDate;
        public Claim(string name, DateTime date) {
            claimName = name;
            claimDate = date;
        }
        

    }
}
