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
    public partial class Issue : Form


    {

        OleDbConnection con = new OleDbConnection("Provider= Microsoft.Jet.OLEDB.4.0;Data Source= Library.mdb");
        OleDbDataAdapter ad = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        public Issue()
        {
            InitializeComponent();
        }
        Users u;
        Books bok;

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox5.Text);
            u = UserDB.GetUsers(num);
            if (u == null)
            {
                MessageBox.Show("The user has not been found");

            }
            else
            {
                
                this.DisplayUsers();
            }

            if (textBox9.Text == "no")
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                label1.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
                label12.Visible = true;
                label15.Visible = true;
                label4.Visible = true;
                label7.Visible = true;

                label5.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox15.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox11.Visible = true;

                textBox2.Visible = true;
                textBox6.Visible = true;
 
            }
        }
        private void DisplayUsers()
        {
            textBox7.Text = u.CustomerName;
            textBox10.Text = u.CustomerSurname;
            textBox8.Text = u.DoB.ToString();
            textBox9.Text = u.Bop;




        }
        private void ClearUsers()
        {
            
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text ="";
           
          



        }
          

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Issue_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox3.Text);
            bok = LibraryDB.GetBooks(num);
            if (bok == null)
            {
                MessageBox.Show("The book has not been found");

            }
            else
            {
                
                this.DisplayBooks();
            }
            int a = Convert.ToInt32(textBox6.Text);
            if (a == 0)
            {
                MessageBox.Show("The book is not in stock at the moment!");
            }

           

           

        }

        private void DisplayBooks()
        {
            textBox11.Text = bok.Author;
            textBox1.Text = bok.Genre;
            textBox4.Text = bok.Title;
            textBox2.Text = bok.Published.ToString();
            textBox6.Text = bok.Quantity.ToString();




        }
        private void ClearBooks()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox11.Text = "";
            textBox6.Text = "";

          


        }

        private void button4_Click(object sender, EventArgs e)
        {

            Books modifyBooks = new Books();

            modifyBooks.BookID = Convert.ToInt32(textBox3.Text);
            modifyBooks.Title = textBox4.Text;
            modifyBooks.Author = textBox11.Text;
            modifyBooks.Genre = textBox1.Text;
            modifyBooks.Quantity = Convert.ToInt32(textBox6.Text);
            modifyBooks.Published = Convert.ToInt32(textBox2.Text);

           

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

        private void button5_Click(object sender, EventArgs e)
        {
            Users modifyUsers = new Users();
           
            modifyUsers.BookID1 = Convert.ToInt32(textBox15.Text);
            modifyUsers.dayx = Convert.ToInt32(comboBox1.Text);
            modifyUsers.monthx = Convert.ToInt32(comboBox2.Text);
            modifyUsers.yearx = Convert.ToInt32(comboBox3.Text);
            modifyUsers.CustomerID = Convert.ToInt32(textBox5.Text);
            modifyUsers.DoB = Convert.ToInt32(textBox8.Text);

            modifyUsers.CustomerName = textBox7.Text;
            modifyUsers.CustomerSurname = textBox10.Text;
            modifyUsers.Bop = textBox9.Text;



            bool results;
            results = UserDB.ModifyUsers(u, modifyUsers);
            if (results)
            {
                u = modifyUsers;
                DisplayUsers();
                MessageBox.Show("The Book User has been succesfully changed");
            }
            else
                MessageBox.Show("Sorry. The book information could not be updated");

        }

       
        
    }
}
