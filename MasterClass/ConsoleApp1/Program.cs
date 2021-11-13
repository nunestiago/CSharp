using System;
using System.Collections;

namespace ConsoleApp1
{
    class Employee
    {
        public int id;
    }
    internal class Program : IComparer
    {
        private static void Main(string[] args)
        {
           
        }

        public int Compare(object x, object y)
        {
            Employee employee1 = (Employee)x;
            Employee employee2 = (Employee)y;
            return employee1.id.CompareTo(employee2.id);
        }
    }
}