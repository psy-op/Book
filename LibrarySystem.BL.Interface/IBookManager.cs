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
         public void ReadBooks(List<Book> BookList, string path);
         public void RentBook(List<Book> BookList, List<Info> InfoList, int value);

         public void WriteBook(List<Book> BookList, string path);


    }
}