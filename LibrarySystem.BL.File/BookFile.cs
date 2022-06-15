using LibrarySystem.BL.Interface;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.BL.File
{
    public class BookManager : IBookManager
    {
        string path = @"C:\Users\faisa\source\repos\xDark911\Book\Book\Books.csv";
        List<Book> BookList = new List<Book>();

        public void ReadBookToList()
        {
                var linesB = System.IO.File.ReadAllLines(path);
                foreach (string line in linesB)
                {
                    var fields = line.Split(',');
                    if (fields.Length != 4) { Console.WriteLine("Error reading book data. Application will end to preseve data."); Environment.Exit(0); }
                    BookList.Add(new Book(Convert.ToInt32(fields[0]), fields[1], fields[2], Convert.ToInt32(fields[3])));
                }
        }

        public List<Book> GetList()
        {
            return BookList;
        }


        public int GetBookIDByName(string bookname)
        {
            foreach (var book in BookList)
            {
                if (bookname == book.Title)
                {
                    return book.Order;
                }    
            }
            return -1;
        }

        public string GetBookNameByID(int id)
        {
            foreach (var book in BookList)
            {
                if (id == book.Order)
                {
                    return book.Title;
                }
            }
            return null;
        }


        public void WriteList()
        {
            using (var fb = new StreamWriter(path))
            {
                foreach (var book in BookList)
                {
                    fb.WriteLine(book.Order + "," + book.Title + "," + book.Author + "," + book.Copies);
                }
            }
        }

        public void CopiesDecrement(int id)
        {
            foreach (var book in BookList) { if (id == book.Order) book.Copies--; }
        }

        public void Copiesincrement(int id)
        {
            foreach (var book in BookList) { if (id == book.Order) book.Copies++; }
        }
    }
}