using LibrarySystem.BL.Interface;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.BL.File
{
    public class BookFile : IBookManager
    {

        public void ReadBooks(List<Book> BookList, string path)
        {
                var linesB = System.IO.File.ReadAllLines(path);
                foreach (string line in linesB)
                {
                    var fields = line.Split(',');
                    if (fields.Length != 4) { Console.WriteLine("Error reading book data. Application will end to preseve data."); Environment.Exit(0); }
                    BookList.Add(new Book(Convert.ToInt32(fields[0]), fields[1], fields[2], Convert.ToInt32(fields[3])));
                }
        }


        public void RentBook(List<Book> BookList, List<Info> InfoList, int value)
        {
            BookList[value].Copies--;
            InfoList.Add(new Info(InfoList.Count, BookList[value].RenterName, BookList[value].Title, BookList[value].SDate, BookList[value].EDate, BookList[value].RenterPhone));
        }


        public void WriteBook(List<Book> BookList, string path)
        {
            using (var fb = new StreamWriter(path))
            {
                foreach (var book in BookList)
                {
                    fb.WriteLine(book.Order + "," + book.Title + "," + book.Author + "," + book.Copies);
                }
            }
        }

    }
}