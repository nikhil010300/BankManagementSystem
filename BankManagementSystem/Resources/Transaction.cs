

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


namespace BankManagementSystem.Resources
{
    public partial class Transaction : Form
    {
        public Transaction()
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
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into transactions values(@TID, @Transaction_Type, @Amount, @Transaction_Date, @Account_ID)", con);
            cnn.Parameters.AddWithValue("@TID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Transaction_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Transaction_Date", dateTimePicker2.Value);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox4.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from Transactions", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView3.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update transactions set  Transaction_Type=@Transaction_Type, Amount=@Amount, Transaction_Date=@Transaction_Date, Account_ID=@Account_ID where TID=@TID", con);
            cnn.Parameters.AddWithValue("@TID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Transaction_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Transaction_Date", dateTimePicker2.Value);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox4.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete Transactions where TID=@TID", con);
            cnn.Parameters.AddWithValue("@TID", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            string sql = "select * from Transactions";
            con.Open();
            SqlCommand cnn = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView3.DataSource = table;
            con.Close();
        }
    }
}



