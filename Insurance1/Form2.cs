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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            int numDrivers = (int)numericUpDown1.Value;
            
            Class1.numDriver = numDrivers;
            Class1.quoteStart = startDate;

            this.Hide();
            var form3 = new Form3(1);
            form3.Closed += (s, args) => this.Close();
            form3.Show();


        }
    }
}
