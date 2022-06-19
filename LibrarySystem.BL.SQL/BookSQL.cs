using LibrarySystem.BL.Interface;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.SQL
{
    public class BookSQL : IBookManager
    {
        List<Book> BookList = new List<Book>();
        SqlConnection DB = new SqlConnection(@"Data Source=AHMEDPC\MSSQLSERVER02;Initial Catalog=Library;Integrated Security=True");



        public void ReadBookToList()
        {
            DB.Open();
            SqlCommand cmd= new SqlCommand("SELECT * FROM Book",DB);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                BookList.Add(new Book(Convert.ToInt32(read[0]), read[1].ToString(), read[2].ToString(), Convert.ToInt32(read[3])));
            }
            DB.Close();
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
            
        }

        public void CopiesDecrement(int id)
        {
            DB.Open();
            SqlCommand update = new SqlCommand("Update Book set Copies=@Copies where ID = @ID", DB);
            int copi;
            foreach (var book in BookList) 
            { 
                if (id == book.Order) 
                { 
                    book.Copies--; 
                    copi = book.Copies;
                    update.Parameters.AddWithValue("@ID", id);
                    update.Parameters.AddWithValue("@Copies", copi);
                    update.ExecuteNonQuery();

                }
            }
            DB.Close();          
        }

        public void Copiesincrement(int id)
        {
            DB.Open();
            SqlCommand update = new SqlCommand("Update Book set Copies=@Copies where ID = @ID", DB);
            int copi;
            foreach (var book in BookList)
            {
                if (id == book.Order)
                {
                    book.Copies++;
                    copi = book.Copies;
                    update.Parameters.AddWithValue("@ID", id);
                    update.Parameters.AddWithValue("@Copies", copi);
                    update.ExecuteNonQuery();
                    DB.Close();
                }
            }
        }
    }
}