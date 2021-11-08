using System;

namespace IreBank
{
    internal class Welcome
    {
        public void Screen()
        {
            Console.WriteLine("--- Welcome to the IreBank ---");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1 - Customer");
            Console.WriteLine("2 - Employee");
            Console.WriteLine("3 - Exit");
            Console.Write(">");
            string inputLine = Console.ReadLine();
            while (!inputLine.Equals("") && !inputLine.ToLower().Equals("3"))
            {
                if (inputLine.Equals("1"))
                {
                    Console.WriteLine("Customer menu");

                }
                else if (inputLine.Equals("2"))
                {
                    Console.WriteLine("Employee menu");
                    Employee emp = new();
                    emp.EmpMainMenu();
                }
                else if (inputLine.Equals("3"))
                {
                    Console.WriteLine("Exit menu");
                }
                else
                {
                    Console.WriteLine("Please insert proper value: ");
                    Console.Write(">");
                    inputLine = Console.ReadLine();
                }
            }
        }
    }
}