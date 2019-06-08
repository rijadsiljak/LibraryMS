using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace LibraryMS
{
  public static class LibraryDB
    {
       public static OleDbConnection GetConnection()
            {
             string connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= Library.mdb";
            OleDbConnection connection = new OleDbConnection(connString);
            return connection;
            }

       public static List<Books> ListBooks()
       {
           OleDbConnection conn = GetConnection();
           string myquerry = "select * from Books";
           OleDbCommand selectCommand = new OleDbCommand(myquerry, conn);
           List<Books> books = new List<Books>();
           try
           {
               conn.Open();
               OleDbDataReader reader = selectCommand.ExecuteReader();
               while (reader.Read())
               {
                   Books b = new Books();
                   b.BookID = Convert.ToInt32(reader["BookID"]);
                   b.Title = reader["Title"].ToString();
                   b.Genre = reader["Genre"].ToString();
                   b.Author = reader["Author"].ToString();
                   b.Published = Convert.ToInt32(reader["Published"]);
                   b.Quantity = Convert.ToInt32(reader["Quantity"]);
                   books.Add(b);
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
           return books;

       }
       public static Books GetBooks(int BookID)
        {
           OleDbConnection conn = GetConnection();
           string myquery = "select * from Books where BookID = @Number";
           OleDbCommand selectCommand = new OleDbCommand(myquery, conn);
           selectCommand.Parameters.AddWithValue("@Number", BookID);

           try
           {
               conn.Open();
               OleDbDataReader reader = selectCommand.ExecuteReader();
               if (reader.Read())
               {
                   Books bo = new Books();
                   bo.BookID = Convert.ToInt32(reader["BookID"]);
                   bo.Title= reader["Title"].ToString();
                   bo.Genre = reader["Genre"].ToString();
                   bo.Author = reader["Author"].ToString();
                   bo.Published = Convert.ToInt32(reader["Published"]);
                   bo.Quantity = Convert.ToInt32(reader["Quantity"]);
                   return bo;
               }
               else
                   return null;
               
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

       public static bool AddBooks (Books bok)
       {

           OleDbConnection conn = GetConnection();
           string query = "insert into  Books (BookID, Title, Genre, Author, Published, Quantity)  " +
       "values (@id, @tit,@gen ,@ath,@pub,@quan)";
           OleDbCommand addCommand = new OleDbCommand(query, conn);

           addCommand.Parameters.AddWithValue("@id", bok.BookID);
           addCommand.Parameters.AddWithValue("@tit", bok.Title);
           addCommand.Parameters.AddWithValue("@gen", bok.Genre);
           addCommand.Parameters.AddWithValue("@ath", bok.Author);
           addCommand.Parameters.AddWithValue("@pub", bok.Published);
           addCommand.Parameters.AddWithValue("@quan", bok.Quantity);

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
       public static bool ModifyBooks(Books currBk, Books modifyBk)
       {

           OleDbConnection conn = GetConnection();
           string query = "update Books set BookID=@id, " +
           "Title=@tit, Author=@ath, Genre=@gen, Published=@pub, Quantity=@qnt where BookID=@id2";
           OleDbCommand updateCommand = new OleDbCommand(query, conn);

           updateCommand.Parameters.AddWithValue("@id", modifyBk.BookID);
           updateCommand.Parameters.AddWithValue("@tit", modifyBk.Title);
           updateCommand.Parameters.AddWithValue("@gen", modifyBk.Genre);
           updateCommand.Parameters.AddWithValue("@ath", modifyBk.Author);
           updateCommand.Parameters.AddWithValue("@pub", modifyBk.Published);
           updateCommand.Parameters.AddWithValue("@qnt", modifyBk.Quantity);
           updateCommand.Parameters.AddWithValue("@id2", currBk.BookID);
           try
           {
               conn.Open();
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
               conn.Close();

           }


       }

       public static bool DeleteBooks(int bkNum)
       {

           OleDbConnection conn = GetConnection();
           string query = "delete from Books where BookID=@id";
           OleDbCommand deleteCommand = new OleDbCommand(query, conn);

   
           deleteCommand.Parameters.AddWithValue("@id", bkNum);
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


