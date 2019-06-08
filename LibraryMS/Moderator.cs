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
    public partial class Moderator : Form
    {
        public Moderator()
        {
            InitializeComponent();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
 this.Hide();

            Login close = new Login();
            close.ShowDialog();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button7.Visible = true;

            button8.Visible = true;
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
            button7.Visible = false;
            button8.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = LibraryDB.GetConnection();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from Books Where (Genre=@gen)", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@genre", textBox1.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = LibraryDB.GetConnection();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from Books Where (Author=@ath)", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@author", textBox1.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
        }

       
    }
}
