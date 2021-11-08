using System;
using System.IO;
using IreBank.Utils;

namespace IreBank
{
    internal class Employee
    {
        public void EmpMainMenu()
        {
            Console.WriteLine("--- Welcome to the IreBank Employee ---");
            Console.WriteLine("Please insert super safe all employees password:");
            Console.WriteLine("or");
            Console.WriteLine("1 - to return to main menu");
            Console.WriteLine("2 - exit");
            Console.Write(">");
            string inputLine = Console.ReadLine();
            while (!inputLine.Equals("") && !inputLine.ToLower().Equals("2"))
            {
                if (inputLine.Equals("A1234"))
                {
                    Console.WriteLine("Customer menu");
                    Employee emp = new();
                    emp.EmpMenu();
                }
                else if (inputLine.Equals("1"))
                {
                    Welcome main = new();
                    main.Screen();
                }
                else
                {
                    Console.WriteLine("Please insert proper value: ");
                    Console.Write(">");
                    inputLine = Console.ReadLine();
                }
            }
        }

        public void EmpMenu()
        {
            Console.WriteLine("--- Welcome to the IreBank Employee ---");
            Console.WriteLine("1 - Create Customer");
            Console.WriteLine("2 - Delete Customer");
            Console.WriteLine("3 - Show All Customers");
            Console.WriteLine("4 - Main menu");
            Console.WriteLine("5 - Exit");
            Console.Write(">");
            string inputLine = Console.ReadLine();
            while (!inputLine.Equals("") && !inputLine.ToLower().Equals("5"))
            {
                if (inputLine.Equals("1"))
                {
                    CreateCustFile();
                    NewCustomer();
                }
                else if (inputLine.Equals("2"))
                {
                    Console.WriteLine("Delete");
                }
                else if (inputLine.Equals("3"))
                {
                    ShowAll();
                }
                else if (inputLine.Equals("4"))
                {
                    Welcome main = new();
                    main.Screen();
                }
                else
                {
                    Console.WriteLine("Please insert proper value: ");
                    Console.Write(">");
                    inputLine = Console.ReadLine();
                }
            }
        }

        private readonly string path = Environment.CurrentDirectory + "customers.txt";

        public void CreateCustFile()
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using StreamWriter sw = File.CreateText(path);
                sw.Close();
            }

            // Open the file to read from.
            //  using StreamReader sr = File.OpenText(path);
            // string s = "";
            // while ((s = sr.ReadLine()) != null)
            // {
            //   Console.WriteLine(s);
            // }
        }

        public void NewCustomer()
        {
            using StreamWriter sw = File.AppendText(path);
            Console.WriteLine("-- New Customer --");
            Console.WriteLine("Please insert customer's name:");
            Console.Write("> ");
            string custName = Console.ReadLine();
            Console.WriteLine("Please insert customer's surname:");
            Console.Write("> ");
            string custSurname = Console.ReadLine();
            Console.WriteLine("Please insert customer's e-mail:");
            Console.Write("> ");
            string email = Console.ReadLine();
            FileName fileName = new();
            string file = fileName.NameConverter(custName, custSurname);
            sw.WriteLine($"{file} \t {custName} \t {custSurname} \t {email}");
            sw.Close();
            EmpMenu();
        }

        public void ShowAll()
        {
            using StreamReader sr = File.OpenText(path);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            sr.Close();
            EmpMenu();
        }
    }
}