using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.BL.Interface;
using LibrarySystem.Models;
using System.Data;

namespace LibrarySystem.BL.SQL
{
    public class InfoSQL : IInfoManager
    {
        List<Info> InfoList = new List<Info>();
        SqlConnection DB = new SqlConnection(@"Data Source=AHMEDPC\MSSQLSERVER02;Initial Catalog=Library;Integrated Security=True");

        public void ReadInfoToList()
        {
            DB.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Renter", DB);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                InfoList.Add(new Info(Convert.ToInt32(read[0]), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), Convert.ToInt32(read[5]), Convert.ToInt32(read[6])));
            }
            DB.Close();

        }

        public List<Info> GetList()
        {
            return InfoList;
        }



        public void RentBook(string name, string bookname, int phone, int days,int bookid)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(days));

            InfoList.Add(new Info(0, name, bookname, sDate.ToString(), eDate.ToString(), phone,bookid));
            DB.Open();
            SqlCommand update = new SqlCommand("INSERT INTO Renter values(@Name,@Book,@StartDate,@EndDate,@PhoneNumber,@BookID)", DB);
            update.Parameters.AddWithValue("@Name",name);
            update.Parameters.AddWithValue("@Book", bookname);
            update.Parameters.AddWithValue("@StartDate", sDate);
            update.Parameters.AddWithValue("@EndDate", eDate);
            update.Parameters.AddWithValue("@PhoneNumber", phone);
            update.Parameters.AddWithValue("@BookID", bookid);
            update.ExecuteNonQuery();
            DB.Close();

        }




        public void RemoveRent(int id, int Index)
        {
            DB.Open();
            InfoList.RemoveAt(Index);
            SqlCommand update = new SqlCommand("Delete Renter where ID=@ID", DB);
            update.Parameters.AddWithValue("@ID", id);
            update.ExecuteNonQuery();
            DB.Close();
        }


        public void WriteList(int days)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(days);
            
        }
    }
}

