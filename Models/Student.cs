using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSchool.Models
{
    public class Student : Person
    {
        public string ParentName { get; set; }
        public string CurrentCourse { get; set; }
        public DateTime BirthDate { get; set; }
        public List<double> Grades { get; set; }

        public Student(string name, string lastName, string documentType, string documentNumber, string email, string phone, string parentName, string currentCourse, DateTime birthDate) : base(name, lastName, documentType, documentNumber, email, phone)
        {
            ParentName = parentName;
            CurrentCourse = currentCourse;
            BirthDate = birthDate;
            Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }

        public double CalculateAverage()
        {
            return Grades.Count > 0 ? Grades.Average() : 0;
        }

        public int CalculateAge()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            System.Console.WriteLine($"Name Parent: {ParentName}");
            System.Console.WriteLine($"Current Course: {CurrentCourse}");
            System.Console.WriteLine($"Birth Date: {BirthDate.ToShortDateString()}");
            System.Console.WriteLine($"Age: {CalculateAge()}");
            System.Console.WriteLine($"Average Grade: {CalculateAverage()}");
        }
    }
}