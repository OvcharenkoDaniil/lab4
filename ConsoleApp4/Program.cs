using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List.Info();
            Console.ReadKey();
        }

    }
    public static class StaticOperation
    {

    }
    public class List
    {
        public class Date
        {
            private string dateOfCreation;

            public string DateOfCreation
            {
                get
                {
                    return dateOfCreation;
                }
            }

            public Date(string _dateOfCreation)
            {
                dateOfCreation = _dateOfCreation;
            }
        }
        public class Owner
        {
            public int id { get; set; }
            public string name { get; set; }
            public string organisation { get; set; }

            public Owner(int id, string name, string organisation)
            {
                this.id = id;
                this.name = name;
                this.organisation = organisation;
            }
        }
        public static Owner owner;
        public static Date date;
        public static void Info()
        {
            Console.WriteLine($"Дата создания: {date.DateOfCreation}, Имя владельца: {owner.name},Идентификационный номер: {owner.id},Организация: {owner.organisation}");
        }

        public static List<int> MyList { get; set;}
        static List() 
        {
            MyList = new List<int>() { 1, 2, 3 };
            owner = new Owner(777,"Daniil","BSTU");
            date = new Date(DateTime.Now.ToString());

        }
        
    } 
}
