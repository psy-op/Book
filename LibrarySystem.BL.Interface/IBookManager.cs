using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Interface
{
    public interface IBookManager
    {
        public int GetBookIDByName(string bookname);

        public List<Book> GetList();

        public void ReadBookToList();

        public void WriteList();

        public void CopiesDecrement(int id);
        public void Copiesincrement(int id);

        public string GetBookNameByID(int id);


    }
}