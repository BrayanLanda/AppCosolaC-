using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSchool.Models
{
    public class Professor : Person
    {
        public string Subject { get; set; }
        private double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public List<string> Courses { get; set; }

        public Professor(string name, string lastName, string documentType, string documentNumber, string email, string phone, string subject, double salary, DateTime hireDate) : base(name, lastName, documentType, documentNumber, email, phone) 
        {
            Subject = subject;
            Salary = salary;
            HireDate = hireDate;
            Courses = new List<string>();
        }

        public int CalculateSeniority()
        {
            return DateTime.Now.Year - HireDate.Year;
        }

        public double GetSalary()
        {
            return Salary;
        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            System.Console.WriteLine($"Subject: {Subject}");
            System.Console.WriteLine($"Hire Date: {HireDate.ToShortDateString()}");
            System.Console.WriteLine($"Seniority: {CalculateSeniority()} years");
            System.Console.WriteLine("Courses: ");
            foreach(var course in Courses)
            {
                System.Console.WriteLine($"- {course}");
            }
        }
    }
}