using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMS
{
    class Users
    {
        
        public int CustomerID;
        public string CustomerName;
        public string CustomerSurname;
        public string Bop;
        public int DoB;
        public int BookID1;
        public int dayx;
   
        public int monthx;
      
        public int yearx;
       
        

        public Users()
        { }
        public Users(int CustomerID, string CustomerName, string CustomerSurname, string Bookinpossetion, int DoB,int BookID1, int dayx, int day1, int monthx, int month1, int yearx, int year1)
        {

            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.CustomerSurname = CustomerSurname;
            this.Bop = Bop;
            this.DoB = DoB;
            this.dayx = dayx;
            this.monthx = monthx;
            this.yearx = yearx;
            this.BookID1 = BookID1;
           
        }
        public string Display ()
    {

        return CustomerID.ToString() + "\t " + CustomerName + "\t " + CustomerSurname + "\t " + Bop + "\t " + "\t " + DoB.ToString() + "\t " + dayx.ToString() +  "\t " + BookID1.ToString();
    }
    }
}
