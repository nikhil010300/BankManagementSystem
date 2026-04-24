using BankManagementSystem.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagementSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cr = new Customer();
            cr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accounts ac = new Accounts();
            ac.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transaction tn = new Transaction(); 
            tn.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Loan loan = new Loan();
            loan.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // your load logic here
        }
        private void Main_FormClosing(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashbboard db = new Dashbboard();
            db.Show();
        }
    }
}
