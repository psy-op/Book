using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Info
    {
        public string SDate { get; }
        public string EDate { get; }
        public string Bookname { get; }
        public string Name { get;  }
        public int ID { get; }
        public int Phone { get; set; }

        public Info(int id,string name, string bookname, string sdate, string edate, int phone)
        {
            ID = id;
            Name = name;
            SDate = sdate;
            EDate = edate;
            Bookname = bookname;
            Phone = phone;
        }

        public static void RRent(List<Book> BookList, List<Info> InfoList, int value)
        {
            foreach (var y in BookList){if (y.Title == InfoList[value].Bookname){y.Copies++;}}
            InfoList.RemoveAt(value);
        }           
    }
}
        

