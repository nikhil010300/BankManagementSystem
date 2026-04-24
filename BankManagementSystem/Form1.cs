using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace BankManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            {
                //Sqlconnection con = new Sqlconnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=False;Trust Server Certificate=True");
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                //SqlConnection con = new SqlConnection("Data Source = DESKTOP-2SBJ98E\\SQLEXPRESS; Initial Catalog=BankDB; " + "User Id = sa; Password=abc123");
                con.Open();

                string Username = txtUsername.Text;
                string Password = txtPassword.Text;
                SqlCommand cmd = new SqlCommand("select username, password from logintab where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Main mn = new Main();
                    mn.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed, Please Check Username and Password");
                }
                con.Close();
            }

            




            

        }
    }
}
