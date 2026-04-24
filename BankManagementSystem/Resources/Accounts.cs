
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
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into accounts values(@Account_ID, @Account_Type, @Balance, @Date_Opened, @Customer_name)", con);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Account_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Balance", textBox3.Text);
            cnn.Parameters.AddWithValue("@Date_Opened", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Customer_name", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");
            */
          
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();

            // ✅ Specify column names and remove @Account_ID
            SqlCommand cnn = new SqlCommand(
                "INSERT INTO accounts (Account_Type, Balance, Date_Opened, Customer_Name) " +
                "VALUES (@Account_Type, @Balance, @Date_Opened, @Customer_Name)", con);

            cnn.Parameters.AddWithValue("@Account_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Balance", textBox3.Text);
            cnn.Parameters.AddWithValue("@Date_Opened", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");
            refreshGrid(sender, e);
        }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void refreshGrid(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from accounts", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;
            con.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            refreshGrid(sender, e);
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            refreshGrid(sender, e);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update accounts set Account_Type=@Account_Type, Balance=@Balance, Date_Opened=@Date_Opened, Customer_Name=@Customer_name where Account_ID=@Account_ID", con);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Account_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Balance", textBox3.Text);
            cnn.Parameters.AddWithValue("@Date_Opened", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("Delete from accounts where Account_ID=@Account_ID", con);
            cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2SBJ98E\\SQLEXPRESS;Initial Catalog=BankDB;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("Select * from accounts where Customer_Name=@Customer_Name", con);
            //cnn.Parameters.AddWithValue("@Account_ID", int.Parse(textBox6.Text));
            cnn.Parameters.AddWithValue("@Customer_Name", textBox6.Text);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;
            con.Close();
        }
    }
    
}



