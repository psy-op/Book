using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;
using LibrarySystem.BL.Interface;
using LibrarySystem.BL.File;
using System.Data.SqlClient;
using System.Data;

namespace LibrarySystemForm
{
    public partial class Form1 : Form
    {

        IBookManager bookmanager = new BookManager();
        IInfoManager infomanager = new InfoManger();

        int rowIndex;
        string rowIndexBook;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("Please enter a name.", "No name input"); return; }
            if (string.IsNullOrEmpty(textBox2.Text)) { MessageBox.Show("Please enter a phone.", "No phone input"); return; }
            if (string.IsNullOrEmpty(comboBox1.Text)) { MessageBox.Show("Please select a book.", "No book selection"); return; }
            foreach (var book in bookmanager.GetList()) { if (comboBox1.Text == book.Title) if (book.Copies <= 0) { MessageBox.Show("Sorry, no copies are left of this book.", "No book copy found"); return; } }

            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(numericUpDown1.Value));
            
            infomanager.RentBook(textBox1.Text, comboBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(numericUpDown1.Value),bookmanager.GetBookIDByName(comboBox1.Text));
            bookmanager.CopiesDecrement(bookmanager.GetBookIDByName(comboBox1.Text));
            dataGridView1.Rows.Add(infomanager.GetList().Count - 1, textBox1.Text, comboBox1.Text, sDate.ToString("d"), eDate.ToString("d"));
            bookmanager.WriteList();
            infomanager.WriteList(Convert.ToInt32(numericUpDown1.Value));

            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
            numericUpDown1.ResetText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {        
            button2.Enabled = false;
            infomanager.ReadInfoToList();
            bookmanager.ReadBookToList();
            foreach (var book in bookmanager.GetList())
            {
                comboBox1.Items.Add(book.Title);
            }
            foreach(var info in infomanager.GetList()){dataGridView1.Rows.Add(info.ID,info.Name,info.RentedBook,info.SDate,info.EDate);}
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar))){e.Handled = true;}
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
            infomanager.RemoveRent(rowIndex);
            dataGridView1.Rows.RemoveAt(rowIndex);                        
            bookmanager.Copiesincrement(bookmanager.GetBookIDByName(rowIndexBook));
            bookmanager.WriteList();
            infomanager.WriteList(Convert.ToInt32(numericUpDown1.Value));
            dataGridView1.Rows.Clear();

            foreach (var info in infomanager.GetList())
            {
                dataGridView1.Rows.Add(infomanager.GetList().IndexOf(info), info.Name, info.RentedBook, info.SDate, info.EDate) ;
            }
            dataGridView1.ClearSelection();
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
        }
    }
}