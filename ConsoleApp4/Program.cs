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
        }
    }
    public class List
    {
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
        public Owner owner;
        public List<int> MyList { get; set;}
        public List() 
        {
            this.MyList = new List<int>() { 1, 2, 3 };
            this.owner = new Owner(111,"Dima","BSTU");
        }

    } 
}
