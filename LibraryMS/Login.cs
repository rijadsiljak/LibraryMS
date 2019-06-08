using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  
       
            if (textBox1.Text == "admin" && textBox2.Text == "ibulib")
            {
                
                this.Hide();
                Admin sistema = new Admin();
                sistema.ShowDialog();
                this.Close();
            }
            else if (textBox1.Text == "moderator" && textBox2.Text == "library")
            {
                this.Hide();
                Moderator sistema = new Moderator();
                sistema.ShowDialog();
                this.Close();
 
            }
            else
            {

                MessageBox.Show("Username or password incorrect. ");
               
                
                }
                
            }
        }
          
        
    }

