using LibrarySystem.BL.Interface;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrartySystem.BL.File
{
    public class BookFile : IBookManager
    {
        public BookFile()
        {

            List<Book> BookList = new List<Book>();
            string pathB = @"D:\Projects(C#)\Book\Book\Books.csv";
            var linesB = File.ReadAllLines(pathB);

            foreach (string line in linesB)
            {
                var fields = line.Split(',');
                if (fields.Length != 4) { Console.WriteLine("Error reading book data. Application will end to preseve data."); Environment.Exit(0); }
                BookList.Add(new Book(Convert.ToInt32(fields[0]), fields[1], fields[2], Convert.ToInt32(fields[3])));
            }
        }






        public Book[] GetList()
        {
            return;
        }

        public Book GetByID(int id)
        {
            return id;
        }

        bool decrease()
        {
            return true;
        }

        Book Update(Book)
        {
            return;
        }


        
    }
}