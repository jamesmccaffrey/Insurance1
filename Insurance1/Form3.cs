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
    
    public partial class Form3 : Form
    {
        int count;
        public Form3(int counter)
        {
            InitializeComponent();
            count = counter;
            label1.Text = "Driver Details ";
            comboBox1.Items.Add("Chauffeur");
            comboBox1.Items.Add("Accountant");
            comboBox1.Items.Add("Other");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
            String name = textBox1.Text;
            String occupation = comboBox1.Text;
            DateTime dob = dateTimePicker1.Value;
            int previousClaim = (int)numericUpDown1.Value;
            Drivers.driverName.Add(name);
            Drivers.driverOccupation.Add(occupation);
            Drivers.driverDOB.Add(dob);
            Drivers.numClaims.Add(previousClaim);

            if (previousClaim > 0)
            {
                int current = Class1.numClaim;
                current = current + previousClaim;
                Class1.numClaim = current;

                this.Hide();
                var form5 = new Form5(name, previousClaim, count);
                form5.Closed += (s, args) => this.Close();
                form5.ShowDialog();
                return;
                //System.Threading.Thread.Sleep(2000000);


            }


            if (Class1.numDriver == count)
            {
                if (Class1.numClaim == 0)
                {
                    PolicyCalculator calc = new PolicyCalculator();
                    double val = calc.getPriceNoClaims(500);
                    if (val == -1)
                    {
                        //Unsuccessful Too Young
                        this.Hide();
                        var form6 = new Form6("Too Young");
                        form6.Closed += (s, args) => this.Close();
                        form6.Show();
                    }
                    if (val == -2)
                    {
                        //Unsuccessful Too Old 
                        this.Hide();
                        var form6 = new Form6("Too Old");
                        form6.Closed += (s, args) => this.Close();
                        form6.Show();
                    }
                    if (val == -3)
                    {
                        //Unsuccessful Policy Start Date
                        this.Hide();
                        var form6 = new Form6("Start Date");
                        form6.Closed += (s, args) => this.Close();
                        form6.Show();
                    }

                    this.Hide();
                    var form4 = new Form4(val);
                    form4.Closed += (s, args) => this.Close();
                    form4.Show();
                    return; //Added to try fix error
                }
                else
                {
                    if (Drivers.claim.Count >= 3)
                    {
                        //Deny Quote
                        //"Policy has more than 3 claims"
                        this.Hide();
                        var form6 = new Form6("Policy has more than 3 claims");
                        form6.Closed += (s, args) => this.Close();
                        form6.Show();
                    }
                    else if (Drivers.numClaims.Contains(2))
                    {
                        //Deny Quote and find out position of driver 
                        //Find out which drivers denied quote
                        this.Hide();
                        var form6 = new Form6(name+" has more than 2 claims");
                        form6.Closed += (s, args) => this.Close();
                        form6.Show();


                    }
                    else if (Drivers.numClaims.Contains(3))
                    {
                        //Deny Quote and find out position of driver 
                        //Find out which drivers denied quote
                        this.Hide();
                        var form6 = new Form6(name + " has more than 3 claims");
                        form6.Closed += (s, args) => this.Close();
                        form6.Show();
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
                        foreach (Claim claimm in Drivers.claim)
                        {
                            if (IsInLastYear(claimm.claimDate))
                            {
                                policy = policy * 1.2;
                            }
                            if (IsOther(claimm.claimDate))
                            {
                                policy = policy * 1.1;
                            }
                        }
                        PolicyCalculator calc = new PolicyCalculator();
                        double val = calc.getPriceNoClaims(policy);
                        this.Hide();
                        var form4 = new Form4(val);
                        form4.Closed += (s, args) => this.Close();
                        form4.Show();
                    }
                }
            }
            else
            {
                count++;
                this.Hide();
                var form3 = new Form3(count);
                form3.Closed += (s, args) => this.Close();
                form3.Show();
                label1.Text = "Driver Details";

            }
        }
    }
}
