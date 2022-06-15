using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.Models
{
    public class Book
    {        
        public string Title { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        public int Order { get; set; }

        public Book(int order, string title, string author, int copies)
        {
            Order = order;
            Title = title;
            Author = author;
            Copies = copies;
        }

    }
}