using System;
using System.IO;
using System.Linq;
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
            Console.WriteLine("3 - Lodgement");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Show All Customers");
            Console.WriteLine("6 - Main menu");
            Console.WriteLine("7 - Exit");
            Console.Write(">");
            string inputLine = Console.ReadLine();
            while (!inputLine.Equals("") && !inputLine.ToLower().Equals("7"))
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
                    Lodgement();
                }
                else if (inputLine.Equals("4"))
                {
                    Console.WriteLine("Withdraw");
                }
                else if (inputLine.Equals("5"))
                {
                    ShowAll();
                }
                else if (inputLine.Equals("6"))
                {
                    Welcome main = new();
                    main.Screen();
                }
                else if (inputLine.Equals("7"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please insert proper value: ");
                    Console.Write(">");
                    inputLine = Console.ReadLine();
                }
            }
        }

        private readonly string path = AppDomain.CurrentDomain.BaseDirectory + "customers.txt";

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
            sw.WriteLine($"{file}\t{custName}\t{custSurname}\t{email}");
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

        public void Lodgement()
        {
            Console.WriteLine("Please insert customer id:");
            Console.WriteLine("ex: xx-nn-yy-zz");
            Console.Write("> ");
            string customer = Console.ReadLine();

            Console.WriteLine("From which account:");
            Console.WriteLine("1 - Current");
            Console.WriteLine("2 - Savings");
            Console.WriteLine("3 - Employee menu");
            Console.WriteLine("4 - Main menu");
            Console.WriteLine("5 - Exit");
            Console.Write("> ");
            string whichAcc = Console.ReadLine();

            while (!whichAcc.Equals("") && !whichAcc.ToLower().Equals("5"))
            {
                if (whichAcc.Equals("1"))
                {
                    whichAcc = "current";
                    AccOperation(customer, whichAcc);
                }
                else if (whichAcc.Equals("2"))
                {
                    whichAcc = "savings";
                    AccOperation(customer, whichAcc);
                }
                else if (whichAcc.Equals("3"))
                {
                    EmpMenu();
                }
                else if (whichAcc.Equals("4"))
                {
                    Welcome main = new();
                    main.Screen();
                }
                else
                {
                    Console.WriteLine("Please insert proper value: ");
                    Console.Write(">");
                    whichAcc = Console.ReadLine();
                }
            }
        }

        private void AccOperation(string customer, string whichAcc)
        {
            Console.WriteLine($"How much would you like to deposit?");
            Console.Write("> ");
            string value = Console.ReadLine();

            DateTime thisDay = DateTime.Today;
            string curFile = @$"{AppDomain.CurrentDomain.BaseDirectory}{customer}-{whichAcc.ToLower()}.txt";

            if (File.Exists(curFile))
            {
                string last = File.ReadLines(curFile).Last();
                Console.WriteLine(curFile);
                Console.WriteLine(last);
                string[] total = last.Split('\t');
                float fullLodge = float.Parse(value) + float.Parse(total[3]);
                using StreamWriter sw = File.AppendText(curFile);
                sw.WriteLine($"{thisDay:d}\t Lodgement\t{value}\t{fullLodge}");
                Console.WriteLine("Funds lodged");
                sw.Close();
                EmpMenu();
            }
            else
            {
                using StreamWriter sw = File.CreateText(curFile);
                Console.WriteLine(curFile);

                sw.WriteLine($"{thisDay:d}\tLodgement\t{value}\t{value}");
                Console.WriteLine("Funds lodged");
                sw.Close();
                EmpMenu();
            }
        }
    }
}