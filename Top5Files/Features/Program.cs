using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{Id = 1, Name ="Rafa" },
                new Employee{Id = 2, Name = "Roger"},
                new Employee{Id = 2, Name = "Andy"}
            };

            IEnumerable<Employee> Sales = new List<Employee>()
            {
                new Employee{Id = 3, Name = "Djokovic"}
            };

            int cntEmpl = developers.Count();
            Console.WriteLine(cntEmpl);
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            foreach(var emp in developers.Where(e => e.Name.StartsWith("R")))
            {
                Console.WriteLine(emp.Name);
            }
            Console.ReadLine();
        }
    }
}
