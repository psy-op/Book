using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Interface
{
    public interface IInfoManager
    {
        public void ReadInfo(List<Info> InfoList, string path);
        public void RemoveRent(List<Book> BookList, List<Info> InfoList, int value);
        public void WriteRent(List<Info> InfoList, int days, string path);
    }
}
