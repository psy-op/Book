using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Info
    {
        

        public string SDate { get; set; }
        public string EDate { get; set; }
        public string Bookname { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
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

    }
}
        

