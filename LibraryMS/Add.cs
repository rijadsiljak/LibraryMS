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
    public partial class Add : Form

    {

        OleDbConnection con = new OleDbConnection("Provider= Microsoft.Jet.OLEDB.4.0;Data Source= Library.mdb");
        OleDbDataAdapter ad = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        public Add()
        {
            InitializeComponent();
            
        }

        private void Add_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Books bok = new Books();
            bok.BookID = Convert.ToInt32(textBox3.Text);
            bok.Title = textBox4.Text;
            bok.Author = textBox2.Text;
            bok.Genre = textBox5.Text;
            bok.Quantity = Convert.ToInt32(textBox6.Text);
            bok.Published = Convert.ToInt32(textBox1.Text);

            bool result;
            result = LibraryDB.AddBooks(bok);
            if (result)

                MessageBox.Show("The new book has been succesfully added");

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Modify admin = new Modify();
            admin.ShowDialog();
            this.Close();
        }
    }
}
