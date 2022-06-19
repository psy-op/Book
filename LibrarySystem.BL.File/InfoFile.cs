using LibrarySystem.BL.Interface;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.BL.File
{
    public class InfoManger : IInfoManager
    {
        string path = @"C:\Users\faisa\source\repos\xDark911\Book\Book\Renters.csv";
        List<Info> InfoList = new List<Info>();

        public void ReadInfoToList()
        {
            var linesR = System.IO.File.ReadAllLines(path);
            foreach (string line in linesR)
            {
                var fields = line.Split(',');
                if (fields.Length != 6) { Console.WriteLine("Error reading rent data. Application will end to preseve data."); Environment.Exit(0); }
                InfoList.Add(new Info(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4], Convert.ToInt32(fields[5])));
            }
        }

        public List<Info> GetList()
        {
            return InfoList;
        }




        public void RentBook(string name, string bookname,int phone,int days, int bookid)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(days));

            InfoList.Add(new Info(InfoList.Count, name, bookname, sDate.ToString("d"), eDate.ToString("d"), phone));
        }




        public void RemoveRent(int id)
        {
            InfoList.RemoveAt(id);
        }


        public void WriteList(int days)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(days);
            using (var fi = new StreamWriter(path))
            {
                foreach (var info in InfoList)
                {
                    fi.WriteLine(InfoList.IndexOf(info) + "," + info.Name + "," + info.RentedBook + "," + info.SDate + "," + info.EDate + "," + info.Phone);
                }
            }
        }
    }
}
