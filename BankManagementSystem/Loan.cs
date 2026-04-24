using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace BankManagementSystem
{
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("insert into loans values(@Loan_ID, @Loan_Type, @Loan_Date, @Amount, @Intrest_Rate, @Customer_Name)", con);
                cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@Loan_Type", textBox2.Text);
                cnn.Parameters.AddWithValue("@Loan_Date", dateTimePicker2.Value);
                cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
                cnn.Parameters.AddWithValue("@Intrest_Rate", textBox4.Text);
                cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);

                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Saved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("select * from Loans", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView4.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("update Loans set  Loan_Type=@Loan_Type, Loan_Date=@Loan_Date, Amount=@Amount,  Intrest_Rate=@Intrest_Rate, Customer_Name=@Customer_Name where Loan_ID=@Loan_ID", con);
                cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@Loan_Type", textBox2.Text);
                cnn.Parameters.AddWithValue("@Loan_Date", dateTimePicker2.Value);
                cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
                cnn.Parameters.AddWithValue("@Intrest_Rate", textBox4.Text);
                cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);

                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully");
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
                SqlCommand cnn = new SqlCommand("delete Loans where Loan_ID=@Loan_ID", con);
                cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
                cnn.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cnn = new SqlCommand("select * from Loans", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView4.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Desc: " + ex.Message, "Some Error", MessageBoxButtons.OK);
            }
        }
    }
}
