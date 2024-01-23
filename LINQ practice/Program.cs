using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> list1 = new List<Person>();
            IEnumerable<Person> list = new List<Person>()
            {
                new Person() {Name = "Kennedy", Id = 3},
                 new Person() {Name = "Kennedy", Id = 3 },
                new Person() {Name = "fesf", Id=4},
                new Person() {Name = "dsfsj", Id = 5},
                new Person() {Id = 7, Name = "FWFWEF"},
                new Person() {Id = 7, Name = "jfjfhhef"}

            };

            //var nameList = list1.MyWhere(x => x.Id == 3);
            //foreach (var name in nameList)
            //{
            //    Console.WriteLine(name.Name);
            //}
            //var chice = list.Sum(x => x.Id);
            //var select = list.Select(x => x.Name);
            //var IdSum = list.MySum(x => x.Id);
            //Console.WriteLine(IdSum.ToString());
            //var o = list.SingleOrDefault(x => x.Id == 0);
            var Order = list.MySingleOrDefault(x => x.Id == 4);
            Console.WriteLine(Order.Name);

            //var ToDict = list.MyToDictionary(s => s.Name);
            ////Console.WriteLine(ToDict);
            //foreach (var x in ToDict)
            //{
            //    Console.WriteLine("key : {0}, value {1}", x.Key, x.Value.Id);
            //}
            //var order = list.OrderBy(s => s.Name);
            //foreach (var x in order)
            //{
            //    Console.WriteLine(x.Name);
            //}
            //var sorted = list.MyOrderBy(s => s.Id);
            //foreach (var x in sorted)
            //{
            //    Console.WriteLine(x.Id);
            //}

        }
    }
}
