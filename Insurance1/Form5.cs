using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insurance1
{
    public partial class Form5 : Form
    {
        string driverName;
        int count;
        int driverscount;
        public Form5(string name, int numClaims, int driverCount)
        {
            InitializeComponent();
            driverName = name;
            count = numClaims;
            driverscount = driverCount;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        bool IsInLastYear(DateTime dt)
        {
            return dt.Year == Class1.quoteStart.Year - 1;
        }

        bool IsOther(DateTime dt)
        {
            return (dt.Year == Class1.quoteStart.Year - 2 ||
                dt.Year == Class1.quoteStart.Year - 3 ||
                dt.Year == Class1.quoteStart.Year - 4 ||
                dt.Year == Class1.quoteStart.Year - 5);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            Claim newClaim = new Claim(driverName, date);
            Drivers.claim.Add(newClaim);
            count--;

            if (count == 0) {
                if (Class1.numDriver == driverscount)
                {
                    //Progress to quote calculation
                    if (Drivers.claim.Count >= 3)
                    {
                        //Deny Quote
                        //"Policy has more than 3 claims" 
                    }
                    else if (Drivers.numClaims.Contains(2))
                    {
                        //Deny Quote and find out position of driver 
                        //Find out which drivers denied quote
                    }
                    else if (Drivers.numClaims.Contains(3))
                    {
                        //Deny Quote and find out position of driver 
                        //Find out which drivers denied quote
                    }
                   else if (Drivers.numClaims.Contains(4))
                    {
                        //Deny Quote and find out position of driver 
                        //Find out which drivers denied quote
                    }
                    else if (Drivers.numClaims.Contains(5))
                    {
                        //Deny Quote and find out position of driver 
                        //Find out which drivers denied quote
                    }
                    else
                    {
                        double policy = 500;
                        foreach(Claim claimm in Drivers.claim)
                        {
                            if (IsInLastYear(claimm.claimDate))
                            {
                                policy = policy * 1.2;
                            }
                            if (IsOther(claimm.claimDate)) {
                                policy = policy * 1.1;
                            }
                        }
                        PolicyCalculator calc = new PolicyCalculator();
                        double val=calc.getPriceNoClaims(policy);
                        this.Hide();
                        var form4 = new Form4(val);
                        form4.Closed += (s, args) => this.Close();
                        form4.Show();

                    }
                }
                else
                {
                    //Increase drivercount by 1 and call form3
                    this.Hide();
                    var form3 = new Form3(driverscount+1);
                    form3.Closed += (s, args) => this.Close();
                    form3.Show();
                }
            }

            else
            {
                //call this form again
                this.Hide();
                var form5 = new Form5(driverName, count, driverscount);
                form5.Closed += (s, args) => this.Close();
                form5.Show();
            }
            

            

        }
    }
}
