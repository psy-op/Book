using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.Models
{
    public class Book
    {
        public string Title;
        public string Author;
        public int Copies;
        public int Order;
        public string RenterName { get; set; }
        public int RenterPhone { get; set; }
        public string SDate { get; set; }
        public string EDate { get; set; }

        public Book(int order, string title, string author, int copies)
        {
            Order = order;
            Title = title;
            Author = author;
            Copies = copies;
        }

        public static void Rent(List<Book> BookList, List<Info> InfoList,int value)
        {
            BookList[value].Copies--;
            InfoList.Add(new Info(InfoList.Count, BookList[value].RenterName, BookList[value].Title, BookList[value].SDate, BookList[value].EDate, BookList[value].RenterPhone));
        }      
    }
}