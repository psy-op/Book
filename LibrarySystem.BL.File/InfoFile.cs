using LibrarySystem.BL.Interface;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.BL.File
{
    public class InfoFile : IInfoManager
    {
        public void ReadInfo(List<Info> InfoList, string path)
        {
            var linesR = System.IO.File.ReadAllLines(path);
            foreach (string line in linesR)
            {
                var fields = line.Split(',');
                if (fields.Length != 6) { Console.WriteLine("Error reading rent data. Application will end to preseve data."); Environment.Exit(0); }
                InfoList.Add(new Info(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4], Convert.ToInt32(fields[5])));
            }
        }
        public void RemoveRent(List<Book> BookList, List<Info> InfoList, int value)
        {
            foreach (var y in BookList) { if (y.Title == InfoList[value].Bookname) { y.Copies++; } }
            InfoList.RemoveAt(value);
        }
        public void WriteRent(List<Info> InfoList,int days, string path)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(days);
            using (var fi = new StreamWriter(path))
            {
                foreach (var info in InfoList)
                {
                    fi.WriteLine(InfoList.IndexOf(info) + "," + info.Name + "," + info.Bookname + "," + info.SDate + "," + info.EDate + "," + info.Phone);
                }
            }
        }
    }
}
