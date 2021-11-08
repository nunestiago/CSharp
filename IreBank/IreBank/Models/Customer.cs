using System;

namespace IreBank.Models
{
    [Serializable]
    internal class Customer
    {
        public Customer()
        {

        }
        public Customer(string data)
        {
            string[] info = data.Split(',');
            this.Id = Int32.Parse(info[0]);
            this.Name = info[1];
            this.Surname = info[2];
            this.Email = info[3];

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string NewCustomer()
        {
            return $"{Id}, {Name}, {Surname}, {Email}";
        }
    }
}