using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace LibraryMS
{
    public partial class Admin : Form
    {
        OleDbConnection con = new OleDbConnection("Provider= Microsoft.Jet.OLEDB.4.0;Data Source= Library.mdb");
        OleDbDataAdapter ad = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login admin = new Login();
            admin.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          

            Return admin = new Return();
            admin.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
         

            Issue admin = new Issue();
            admin.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            Modify admin = new Modify();
            admin.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button9.Visible = true;
            button7.Visible = true;
           button10.Visible = true;


        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = LibraryDB.GetConnection();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from Books Where (Title=@tit)", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@title", textBox1.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button6.Visible = false;
            button9.Visible = false;

            button10.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = LibraryDB.GetConnection();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from Books Where (Genre=@gen)", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@genre", textBox1.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button6.Visible = false;
            button9.Visible = false;

            button10.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = LibraryDB.GetConnection();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from Books Where (Author=@ath)", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@author", textBox1.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button6.Visible = false;
            button9.Visible = false;

            button10.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = LibraryDB.GetConnection();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from Users Where (CustomerName=@cname)", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@cname", textBox1.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button6.Visible = false;
            button9.Visible = false;

            button10.Visible = false;
        }

    }  
    }
