using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace AppSchool.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName {get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set;}
        public string Email { get; set; }
        public string Phone { get; set; }

        public Person(string name, string lastName, string documentType, string documentNumber, string email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            Email = email;
            Phone = phone;
        }

        public virtual void ShowDetails()
        {
            System.Console.WriteLine($"ID: {Id}");
            System.Console.WriteLine($"Name {Name} {LastName}");
            System.Console.WriteLine($"Document: {DocumentType}-{DocumentNumber}");
            System.Console.WriteLine($"Email: {Email}");
            System.Console.WriteLine($"Phone: {Phone}");
        }
    }
}