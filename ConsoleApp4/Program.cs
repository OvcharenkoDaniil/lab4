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
        public static string truncation(this List list)
        {
            Console.WriteLine("Введите строку:");
            string base_string = Console.ReadLine();
            Console.WriteLine($"Строка: {base_string}");
            Console.WriteLine("Введите нужную длину усеченной строки:");
            int n = int.Parse(Console.ReadLine());
            string new_string = base_string.Substring(0, base_string.Length - n);
            return new_string;
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
            Console.WriteLine($"Дата создания: {date.DateOfCreation}, Имя владельца: {owner.name}, Организация: {owner.organisation}, Идентификационный номер: {owner.id}");
        }

        public List<int> MyList { get; set;}
        public List() 
        {
            MyList = new List<int>() {2, 3,4 };
            owner = new Owner(777,"Daniil","BSTU");
            date = new Date(DateTime.Now.ToString());

        }
        public int Count => this.MyList.Count;
        public static List operator <(List list1, List list2)     //добаление списка 2 к списку 1 
        {
            list1.MyList.AddRange(list2.MyList);
            return list1;
        }
        public static List operator >(List list1, List list2)     //добавление списка 1 к списку 2
        {
            list2.MyList.AddRange(list1.MyList);
            return list2;
        }
        public static List operator +(List list1, List list2)      //объединение двух списков
        {
            List newlist = new List();
            newlist.MyList[0] = list1.MyList[0] + list2.MyList[0];
            newlist.MyList[1] = list1.MyList[1] + list2.MyList[1];
            newlist.MyList[2] = list1.MyList[2] + list2.MyList[2];
            return newlist;
        }

        public static List operator ~(List list)                   //инверсия элементов списка
        {
            List s = new List();
            s.MyList[0] = ~s.MyList[0];
            s.MyList[1] = ~s.MyList[1];
            s.MyList[2] = ~s.MyList[2];
            return s;
        }

        public static bool operator ==(List list1, List list2)  //проверка на равенство списков
        {
            return list1.Equals(list2);
        }

        public static bool operator !=(List list1, List list2)  //проверка на неравенство списков
        {
            return !list1.Equals(list2);
        }

        //если перегружаются операторы == и !=, то для этого требуется переопределить методы Object.Equals() и Object.GetHashCode().

        public override bool Equals(object list)                //переопределение
        {
            if (list == null)
            {
                return false;
            }
            if (list.GetType() != this.GetType())
            {
                return false;
            }
            List temp = (List)list;
            return this.Count == temp.Count && this.MyList[0] == temp.MyList[0] && this.MyList[1] == temp.MyList[1] && this.MyList[2] == temp.MyList[2] ;
        }
        public override int GetHashCode()
        {
            int hash;
            string wd = Convert.ToString(Count);
            hash = string.IsNullOrEmpty(wd) ? 0 : Count.GetHashCode();
            hash = (hash * 47) + Count.GetHashCode();
            return hash;
        }
        




        public int this[int index]                              //индексатор
        {
            get
            {
                return this.MyList[index];
            }

            set
            {
                this.MyList[index] = value;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List list = new List();
            List inversion_list;
            inversion_list = ~list;
            Console.WriteLine("Инверсия элементов:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(inversion_list[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Объединение:");
            List list1 = new List();
            List list2 = new List();
            List union_list;
            union_list = list1 + list2;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(union_list[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Проверка на равенство:");
            Console.WriteLine($"list1 == list2 is { list1 == list2}");
            Console.WriteLine($"list1 == union_list is { list1 == union_list}");
            Console.WriteLine();
            List added_list1 = list1 < list2;
            Console.WriteLine("list2 added to list1:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(added_list1[i]);
            }
            Console.WriteLine();
            List added_list2 = union_list > list2;
            Console.WriteLine("union_list added to list2:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(added_list2[i]);
            }
            Console.WriteLine();
            List.Info();
            Console.WriteLine($"Количество элементов: {list.count()}");
            Console.WriteLine($"Сумма эементов: {list.Sum()}");
            Console.WriteLine($"разница между максимальным и минимальным элементом: {list.MinOrMax()}");
            Console.WriteLine($"Усеченная строка: {list.truncation()}");
            Console.ReadKey();
        }

    }
}
