using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace LibraryMS
{
    class UserDB
    {
        public static OleDbConnection GetConnection()
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= Library.mdb";
            OleDbConnection connection = new OleDbConnection(connString);
            return connection;
        }
        public static List<Users> ListUsers()
        {
            OleDbConnection conn = GetConnection();
            string myquerry = "select * from Users";
            OleDbCommand selectCommand = new OleDbCommand(myquerry, conn);
            List<Users> user = new List<Users>();
            try
            {
                conn.Open();
                OleDbDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                   Users u = new Users();
                   u.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                   u.CustomerName = reader["CustomerName"].ToString();
                   u.CustomerSurname = reader["CustomerSurname"].ToString();
                   u.Bop = reader["Bop"].ToString();
                   u.BookID1 = Convert.ToInt32(reader["BookID1"]);
                   u.dayx = Convert.ToInt32(reader["dayx"]);
                  
                   u.yearx = Convert.ToInt32(reader["yearx"]);
              
                   u.monthx = Convert.ToInt32(reader["monthx"]);
        
                   u.DoB = Convert.ToInt32(reader["Dob"]);
                    user.Add(u);
                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return user;

        }
        public static Users GetUsers(int CustomerID)
        {
            OleDbConnection con = GetConnection();
            string myquery = "select * from Users where CustomerID = @Number";
            OleDbCommand selectCommand = new OleDbCommand(myquery, con);
            selectCommand.Parameters.AddWithValue("@Number", CustomerID);

            try
            {
                con.Open();
                OleDbDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    Users us = new Users();
                    us.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    us.CustomerName = reader["CustomerName"].ToString();
                    us.CustomerSurname = reader["CustomerSurname"].ToString();
                    us.Bop = reader["Bop"].ToString();
                    us.DoB = Convert.ToInt32(reader["DoB"]);
                    us.BookID1 = Convert.ToInt32(reader["BookID1"]);
                    us.dayx = Convert.ToInt32(reader["dayx"]);
       
                    us.yearx = Convert.ToInt32(reader["yearx"]);
     
                    us.monthx = Convert.ToInt32(reader["monthx"]);

                    return us;
                }
                else
                {
                    return null;
                }

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public static bool AddBooks(Users usr)
        {

            OleDbConnection conn = GetConnection();
            string query = "insert into Users (CustomerID, CustomerName, CustomerSurname, Bop, DoB, BooksID1, dayx, monthx, yearx)  " + "values (@cid, @nam,@sur ,@bop,@dob,@id1,@dy,@mthx,@yrx)";
            OleDbCommand addCommand = new OleDbCommand(query, conn);

            addCommand.Parameters.AddWithValue("@cid", usr.CustomerID);
            addCommand.Parameters.AddWithValue("@nam", usr.CustomerName);
            addCommand.Parameters.AddWithValue("@sur", usr.CustomerSurname);
            addCommand.Parameters.AddWithValue("@bop", usr.Bop);
            addCommand.Parameters.AddWithValue("@dob", usr.DoB);
            addCommand.Parameters.AddWithValue("@id1", usr.BookID1);
            addCommand.Parameters.AddWithValue("@dy", usr.dayx);
             addCommand.Parameters.AddWithValue("@mthx", usr.monthx);
            addCommand.Parameters.AddWithValue("@yrx", usr.yearx);
   

            try
            {
                conn.Open();
                int count = addCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }


        }
        public static bool ModifyUsers(Users currUsr, Users modifyUsr)
        {

            OleDbConnection con = GetConnection();
            string query = "update Users set CustomerID=@cid, CustomerName=@cname, CustomerSurname=@csur, Bop=@bop, DoB=@dob, BookID1=@id1, dayx=@dy, monthx=@mthx, yearx=@yr where CustomerID=@cid2";
            OleDbCommand updateCommand = new OleDbCommand(query, con);

            updateCommand.Parameters.AddWithValue("@cid", modifyUsr.CustomerID);
            updateCommand.Parameters.AddWithValue("@cname", modifyUsr.CustomerName);
            updateCommand.Parameters.AddWithValue("@csur", modifyUsr.CustomerSurname);
            updateCommand.Parameters.AddWithValue("@bop", modifyUsr.Bop);
            updateCommand.Parameters.AddWithValue("@dob", modifyUsr.DoB);
            updateCommand.Parameters.AddWithValue("@id1", modifyUsr.BookID1);
            updateCommand.Parameters.AddWithValue("@dy", modifyUsr.dayx);
           updateCommand.Parameters.AddWithValue("@mthx", modifyUsr.monthx);
            updateCommand.Parameters.AddWithValue("@yrx", modifyUsr.yearx);
            updateCommand.Parameters.AddWithValue("@cid2", currUsr.CustomerID);
            try
            {
                con.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }


        }

        public static bool DeleteUsers(int usrNum)
        {

            OleDbConnection conn = GetConnection();
            string query = "delete from Users where CustomerID=@id";
            OleDbCommand deleteCommand = new OleDbCommand(query, conn);


            deleteCommand.Parameters.AddWithValue("@id", usrNum);
            try
            {
                conn.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }


        }
    }
}
