using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class StatisticOperation
    {
        public static int Sum(this List list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list.MyList[i];
            }
            return sum;
        }
        public static int MinOrMax(this List list)
        {
            int min = list.MyList[0];
            int max = list.MyList[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list.MyList[i] > max)
                {
                    max = list.MyList[i];
                }
                if (list.MyList[i] < min)
                {
                    min = list.MyList[i];
                }
            }
            return max - min;
        }
        public static int count(this List list)
        {
            return list.Count;
        }
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

        public List<int> MyList { get; set;}
        public List() 
        {
            MyList = new List<int>() { 1, 2, 3,4 };
            owner = new Owner(777,"Daniil","BSTU");
            date = new Date(DateTime.Now.ToString());

        }
        public int Count => this.MyList.Count;
    }
    class Program
    {
        static void Main(string[] args)
        {

            List list = new List();
            List.Info();
            Console.WriteLine($"Количество элементов: {list.count()}");
            Console.WriteLine($"Сумма эементов: {list.Sum()}");
            Console.WriteLine($"разница между максимальным и минимальным элементом: {list.MinOrMax()}");
            Console.ReadKey();
        }

    }
}
