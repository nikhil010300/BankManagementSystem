using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace BankManagementSystem
{
    public partial class Employee : Form
    {
      
        public Employee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("insert into Employees values(@EID, @Name, @Position, @Salary)", con);
                cnn.Parameters.AddWithValue("@EID", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@Name", textBox2.Text);
                cnn.Parameters.AddWithValue("@Position", textBox3.Text);
                cnn.Parameters.AddWithValue("@Salary", textBox4.Text);

                cnn.ExecuteNonQuery();
               
                MessageBox.Show("Record Saved Successfully");
                Grid_Refresh(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }

        private void Grid_Refresh(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("select * from Employees", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView5.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Grid_Refresh(sender, e);
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("update Employees set  Name=@Name, Position=@Position, Salary=@Salary where EID=@EID", con);
                cnn.Parameters.AddWithValue("@EID", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@Name", textBox2.Text);
                cnn.Parameters.AddWithValue("@Position", textBox3.Text);
                cnn.Parameters.AddWithValue("@Salary", textBox4.Text);

                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully");
                Grid_Refresh(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("delete Employees where EID=@EID", con);
                cnn.Parameters.AddWithValue("@EID", int.Parse(textBox1.Text));
                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully");
                Grid_Refresh(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("select * from Employees", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView5.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }
    }
    
}
