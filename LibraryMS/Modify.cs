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
    public partial class Modify : Form
    {
        OleDbConnection con = new OleDbConnection("Provider= Microsoft.Jet.OLEDB.4.0;Data Source= Library.mdb");
        OleDbDataAdapter ad = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        public Modify()
        {
            InitializeComponent();
        }
        Books bok;



        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin admin = new Admin();
            admin.ShowDialog();
            this.Close();

        }

        private void Modify_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox3.Text);
            bok = LibraryDB.GetBooks(num);
            if (bok == null)
            {
                MessageBox.Show("The book has not been found");

            }
            else
            {
                button3.Enabled = true;
                button5.Enabled = true;
                this.DisplayBooks();
            }

            OleDbConnection conn = LibraryDB.GetConnection();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from Books Where (BookID=@id)", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@bookid", textBox3.Text);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

           

        }

        private void DisplayBooks()
        {
            textBox2.Text = bok.Author;
            textBox5.Text = bok.Genre;
            textBox4.Text = bok.Title;
            textBox1.Text = bok.Published.ToString();
            textBox6.Text = bok.Quantity.ToString();




        }
        private void ClearBooks()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

          


        }

        private void button3_Click(object sender, EventArgs e)
        {

            Books modifyBooks = new Books();
            modifyBooks.BookID = Convert.ToInt32(textBox3.Text);
            modifyBooks.Title = textBox4.Text;
            modifyBooks.Author = textBox2.Text;
            modifyBooks.Genre = textBox5.Text;
            modifyBooks.Quantity = Convert.ToInt32(textBox6.Text);
            modifyBooks.Published = Convert.ToInt32(textBox1.Text);

            bool result;
            result = LibraryDB.ModifyBooks(bok, modifyBooks);
            if (result)
            {
                bok = modifyBooks;
                DisplayBooks();
                MessageBox.Show("The Book info has been succesfully changed");
            }
            else
                MessageBox.Show("Sorry. The book information could not be updated");
            


        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Add admin = new Add();
            admin.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox3.Text);
            bool result;
            result = LibraryDB.DeleteBooks(num);
            if (result == true)
            {
                button3.Enabled = false;
                button5.Enabled = false;
                ClearBooks();
                MessageBox.Show("The book information has been succesfully changed! ");
            }
            else
                MessageBox.Show("Sorry. The book information was not able to change. ");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                ad.SelectCommand = new OleDbCommand("select * from Books", con);
                ds.Clear();
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }





    }
        }


