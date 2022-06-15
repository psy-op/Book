using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace MyApplication
{
    class Program
    {
        static int menuchoice;
        public static void Menu()
        {
            bool errorloop=true;

            do
            {
                Console.WriteLine("\n 1.Rent Book\n 2.Show Renters\n 3.List all books\n 4.Remove Rent\n 5.End");
                Console.Write("Enter your choice: ");
                string MenuSelect = Console.ReadLine();
                int value;
                if (!int.TryParse(MenuSelect, out value)|| value > 5 || value < 1)
                {
                    Console.WriteLine("Wrong input, Please try again.");
                }             
                menuchoice = value;
                errorloop = false;
            } while (errorloop);



        }

        public static void MenuRent(List<Book> BookList,List<Info> InfoList)
        {
            string Choice;
            bool errorloop = true;
            do
            {
                Console.Write("Pick the number of the book you want to rent:");
                Choice = Console.ReadLine();
                int value;
                if (!int.TryParse(Choice, out value) || value > BookList.Count() || value < 0)
                {
                    Console.WriteLine("Wrong input, Please try again.");
                    errorloop = true;
                }
                else if (BookList[value].Copies > 0)
                {
                    Console.Write("Please enter your name: ");
                    string uname = Console.ReadLine();
                    if (string.IsNullOrEmpty(uname)){Console.WriteLine("Please enter a valid name: ");continue;}
                    BookList[value].RenterName = uname;
                    Console.Write("Please enter your phone: ");
                    BookList[value].RenterPhone = Convert.ToInt32(Console.ReadLine());
                    DateTime sDate = DateTime.Now;
                    BookList[value].SDate = sDate.ToString("d");
                    Console.Write("Please enter total days for rent: ");
                    double tdays = Convert.ToDouble(Console.ReadLine());
                    if (tdays<=0) { Console.WriteLine("Please enter a valid number of days: "); continue; }
                    DateTime eDate = sDate.AddDays(tdays);
                    BookList[value].EDate = eDate.ToString("d");
                    //Book.Rent(BookList,InfoList,value);
                    Console.WriteLine("Book Has been Rented successfully.");
                    errorloop = false;
                }
                else{Console.WriteLine("The book is out of copies.");}
            } while (errorloop);
        }
        public static void MenuUnRent(List<Book> BookList, List<Info> InfoList)
        {
            string Choice;
            bool errorloop = true;
            do
            {
                Console.Write("Pick the ID of the renter you want to remove:");
                Choice = Console.ReadLine();
                int value;
                if (!int.TryParse(Choice, out value) || value > InfoList.Count() || value < 0)
                {
                    Console.WriteLine("Wrong input, Please try again.");
                    errorloop = true;
                }
                else
                {
                    //Info.RRent(BookList,InfoList, value);
                    Console.WriteLine("Renter Has been removed successfully.");
                    errorloop = false;
                }



            } while (errorloop);
        }

        public static void MenuListBooks(List<Book> BookList)
        {
            Console.WriteLine("\t Books\n\n");
            Console.WriteLine("N" + " Title" + "\t Author" + "\t Copies");
            foreach (var book in BookList)
            { Console.WriteLine(book.Order + "  " + book.Title + "\t " + book.Author + "\t " + book.Copies); }
        }
        public static void MenuListInfo(List<Info> InfoList)
        {
            Console.WriteLine("\t Renters\n\n");
            Console.WriteLine("ID" + "  Name " + "\t Book" + "\t  Date ");
            foreach (var info in InfoList)
            { Console.WriteLine(InfoList.IndexOf(info) + "   " + info.Name + "\t  " + info.Bookname + "\t   " + info.SDate + "\t   " + info.EDate); }
        }
           
        public static void MenuReadBooks(string path, List<Book> BookList)
        {
            var linesB = File.ReadAllLines(path);
            foreach (string line in linesB)
            {
                var fields = line.Split(',');
                if (fields.Length != 4) { Console.WriteLine("Error reading book data. Application will end to preseve data."); Environment.Exit(0); }
                BookList.Add(new Book(Convert.ToInt32(fields[0]), fields[1], fields[2], Convert.ToInt32(fields[3])));
            }
        }
        public static void MenuWriteBooks(string path, List<Book> BookList)
        {
            using (var fb = new StreamWriter(path))
            {
                foreach (var book in BookList)
                {
                    fb.WriteLine(book.Order + "," + book.Title + "," + book.Author + "," + book.Copies);
                }
            }
        }

        public static void MenuReadInfo(string path, List<Info> InfoList)
        {
            var linesR = File.ReadAllLines(path);
            foreach (string line in linesR)
            {
                var fields = line.Split(',');
                if (fields.Length != 5) { Console.WriteLine("Error reading rent data. Application will end to preseve data."); Environment.Exit(0); }
                InfoList.Add(new Info(Convert.ToInt32(fields[0]), fields[1],fields[2],fields[3],fields[4],Convert.ToInt32(fields[5])));
            }
        }
        public static void MenuWriteInfo(string path, List<Info> InfoList)
        {
            using (var fi = new StreamWriter(path))
            {
                foreach (var info in InfoList)
                {
                    fi.WriteLine(InfoList.IndexOf(info) + "," + info.Name + "," + info.Bookname + "," + info.SDate + "," + info.EDate);
                }
            }
        }

        static void Main(string[] args)
        {
            List<Info> InfoList = new List<Info>();
            List<Book> BookList = new List<Book>();

            string pathB = @"D:\Projects(C#)\Book\Book\Books.csv";
            string pathR = @"D:\Projects(C#)\Book\Book\Renters.csv";

            MenuReadBooks(pathB,BookList);
            MenuReadInfo(pathR,InfoList);

            Console.WriteLine("\t Libary");
            bool MenuLoop = true;
            do
            {
                try
                {
                    Menu();
                    switch (menuchoice)
                    {
                        case 1:
                            MenuListBooks(BookList);
                            MenuRent(BookList,InfoList);
                        break;
                        case 2:
                            MenuListInfo(InfoList);
                        break;
                        case 3:
                            MenuListBooks(BookList);
                        break;
                        case 4:
                            MenuListInfo(InfoList);
                            MenuUnRent(BookList, InfoList);
                        break;
                        case 5:
                            MenuWriteInfo(pathR, InfoList);
                            MenuWriteBooks(pathB, BookList);
                            MenuLoop =false;                      
                        break;
                    }               
                }
                finally
                {
                    MenuWriteInfo(pathR, InfoList);
                    MenuWriteBooks(pathB, BookList);
                }
            }while (MenuLoop);
        }
    }
}
