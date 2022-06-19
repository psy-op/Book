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
        SqlConnection DB = new SqlConnection(@"Data Source=AHMEDPC\MSSQLSERVER02;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void ReadInfoToList()
        {
           
            
        }

        public List<Info> GetList()
        {
            return InfoList;
        }




        public void RentBook(string name, string bookname, int phone, int days,int bookid)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(days));
            DB.Open();
            SqlCommand cmd = new SqlCommand("Instert into Renter values (@Name,@Book,@StartDate,@EndDate,@PhoneNumber,@BookID",DB);
            cmd.Parameters.AddWithValue("@Name",name);
            cmd.Parameters.AddWithValue("@Book", bookname);
            cmd.Parameters.AddWithValue("@StartDate", sDate);
            cmd.Parameters.AddWithValue("@EndDate", eDate);
            cmd.Parameters.AddWithValue("@PhoneNumber", phone);
            cmd.Parameters.AddWithValue("@BookID", bookid);
            cmd.ExecuteNonQuery(); 
        }




        public void RemoveRent(int id)
        {
            DB.Open();
            SqlCommand cmd = new SqlCommand("Delete Renter where ID = @ ID", DB);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }


        public void WriteList(int days)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(days);
            
        }
    }
}

