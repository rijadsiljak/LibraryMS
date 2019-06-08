using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMS
{
  public class Books
    {
        public int BookID;
        public string Title;
        public string Genre;
        public string Author;
        public int Published;
        public int Quantity;

        public Books()
        { }
        public Books(int BooID, string Title, string Genre, string Author, int Published, int Quantity)
        {

            this.BookID = BookID;
            this.Title = Title;
            this.Genre = Genre;
            this.Author = Author;
            this.Published = Published;
            this.Quantity = Quantity;
        }
        public string Display ()
    {

        return BookID.ToString() + "\t " + Title + "\t " + Genre + "\t " + Author + "\t " + "\t " + Quantity.ToString() + "\t " + Published.ToString();
    }
    }
}
