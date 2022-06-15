using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Console
{
    internal class UnusedFunctions
    {
        /*var linesR = File.ReadAllLines(pathR);   
    foreach (string line in linesR)
    {
        var fields = line.Split(',');
        if (fields.Length != 6) { Console.WriteLine("Error reading rent data. Application will end to preseve data."); Environment.Exit(0); }
        dataGridView1.Rows.Add(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4]);
    }*/

        //foreach (var book in bookmanager.GetList()) { if ( book.Title == rowIndexBook ) book.Copies++; }
        //foreach (var book in bookmanager.GetList()) { if (comboBox1.Text == book.Title) book.Copies--; }
        //InfoList.Add(new Info(InfoList.Count, textBox1.Text, comboBox1.Text, sDate.ToString("d"), eDate.ToString("d"),Convert.ToInt32(textBox2.Text)));

        /*private void ReadInfo2Data()
        {
            var linesR = File.ReadAllLines(pathR);
            foreach (string line in linesR)
            {
                var fields = line.Split(',');
                if (fields.Length != 6) { Console.WriteLine("Error reading rent data. Application will end to preseve data."); Environment.Exit(0); }
                InfoList.Add(new Info(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4], Convert.ToInt32(fields[5])));
                dataGridView1.Rows.Add(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4]);

            }
        }*/

        /*private void ReadBook2Data()
        {
            var linesB = File.ReadAllLines(pathB);
            foreach (string line in linesB)
            {
                var fields = line.Split(',');
                if (fields.Length != 4) { Console.WriteLine("Error reading book data. Application will end to preseve data."); Environment.Exit(0); }
                BookList.Add(new Book(Convert.ToInt32(fields[0]), fields[1], fields[2], Convert.ToInt32(fields[3])));
                comboBox1.Items.Add(fields[1]);
            }

        }*/

        /*private void WriteBook2File()
        {
            using (var fb = new StreamWriter(pathB))
            {
                foreach (var book in BookList)
                {
                    fb.WriteLine(book.Order + "," + book.Title + "," + book.Author + "," + book.Copies);
                }
            }
        }*/

        /*private void WriteInfo2File()
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(numericUpDown1.Value));
            using (var fi = new StreamWriter(pathR))
            {
                foreach (var info in InfoList)
                {
                    fi.WriteLine(InfoList.IndexOf(info) + "," + info.Name + "," + info.RentedBook + "," + info.SDate + "," + info.EDate + "," + info.Phone);
                }
            }
        }*/

    }
}
