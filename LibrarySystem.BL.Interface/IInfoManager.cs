﻿using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Interface
{
    public interface IInfoManager
    {
        public void RentBook(string name, string bookname, int phone, int days, int bookid);

        public List<Info> GetList();

        public void ReadInfoToList();

        public void WriteList(int days);

        public void RemoveRent(int id,int Index);


        
    }
}
