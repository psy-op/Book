using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;
using MyApplication;
namespace LibrarySystemForm
{
    public partial class Form1 : Form
    {

        List<Info> InfoList = new List<Info>();
        List<Book> BookList = new List<Book>();

        string pathB = @"G:\Projects(C#)\Book\Book\Books.csv";
        string pathR = @"G:\Projects(C#)\Book\Book\Renters.csv";

        int rowIndex;
        string rowIndexBook;

        private void ReadInfo2Data()
        {
            var linesR = File.ReadAllLines(pathR);
            foreach (string line in linesR)
            {
                var fields = line.Split(',');
                if (fields.Length != 6) { Console.WriteLine("Error reading rent data. Application will end to preseve data."); Environment.Exit(0); }
                InfoList.Add(new Info(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4], Convert.ToInt32(fields[5])));
                dataGridView1.Rows.Add(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4]);

            }
        }

        private void ReadBook2Data()
        {
            var linesB = File.ReadAllLines(pathB);
            foreach (string line in linesB)
            {
                var fields = line.Split(',');
                if (fields.Length != 4) { Console.WriteLine("Error reading book data. Application will end to preseve data."); Environment.Exit(0); }
                BookList.Add(new Book(Convert.ToInt32(fields[0]), fields[1], fields[2], Convert.ToInt32(fields[3])));
                comboBox1.Items.Add(fields[1]);
            }

        }

        private void WriteBook2File()
        {
            using (var fb = new StreamWriter(pathB))
            {
                foreach (var book in BookList)
                {
                    fb.WriteLine(book.Order + "," + book.Title + "," + book.Author + "," + book.Copies);
                }
            }
        }

        private void WriteInfo2File()
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(numericUpDown1.Value));
            using (var fi = new StreamWriter(pathR))
            {
                foreach (var info in InfoList)
                {
                    fi.WriteLine(InfoList.IndexOf(info) + "," + info.Name + "," + info.Bookname + "," + info.SDate + "," + info.EDate + "," + info.Phone);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("Please enter a name.", "No name input"); return; }
            if (string.IsNullOrEmpty(textBox2.Text)) { MessageBox.Show("Please enter a phone.", "No phone input"); return; }
            if (string.IsNullOrEmpty(comboBox1.Text)) { MessageBox.Show("Please select a book.", "No book selection"); return; }
            foreach (var book in BookList) { if (comboBox1.Text == book.Title) if (book.Copies <= 0) { MessageBox.Show("Sorry, no copies are left of this book.", "No book copy found"); return; } }

            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(numericUpDown1.Value));

            InfoList.Add(new Info(InfoList.Count, textBox1.Text, comboBox1.Text, sDate.ToString("d"), eDate.ToString("d"),Convert.ToInt32(textBox2.Text)));
            foreach (var book in BookList) { if (comboBox1.Text == book.Title) book.Copies--; }
            dataGridView1.Rows.Add(InfoList.Count-1, textBox1.Text, comboBox1.Text, sDate.ToString("d"), eDate.ToString("d"));

            WriteBook2File();

            WriteInfo2File();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
            numericUpDown1.ResetText();

        }

        private void Form1_Load(object sender, EventArgs e)
        {        
            button2.Enabled = false;
            ReadInfo2Data();
            ReadBook2Data();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells["RentID"].Value != null)
            {
                
                button2.Enabled = true;
                button2.BackColor = Color.Red;
                rowIndex = dataGridView1.CurrentCell.RowIndex;
                rowIndexBook = dataGridView1.Rows[rowIndex].Cells["NameBook"].FormattedValue.ToString();
            }
            else
            {
                button2.Enabled = false;
                button2.BackColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InfoList.RemoveAt(rowIndex);
            dataGridView1.Rows.RemoveAt(rowIndex);

            foreach (var book in BookList) { if ( book.Title == rowIndexBook ) book.Copies++; }

            WriteBook2File();

            WriteInfo2File();

            dataGridView1.Rows.Clear();
            var linesR = File.ReadAllLines(pathR);   
            foreach (string line in linesR)
            {
                var fields = line.Split(',');
                if (fields.Length != 6) { Console.WriteLine("Error reading rent data. Application will end to preseve data."); Environment.Exit(0); }
                dataGridView1.Rows.Add(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3], fields[4]);

            }
            dataGridView1.ClearSelection();
            button2.Enabled = false;
            button2.BackColor = Color.Gray;

 
        }
    }
}