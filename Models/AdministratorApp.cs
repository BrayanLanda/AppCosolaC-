using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AppSchool.Models
{
    public static class AdministratorApp
    {
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Professor> Professors { get; set; } = new List<Professor>();


        public static void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public static void AddProfessor(Professor professor)
        {
            Professors.Add(professor);
        }

        // public static Guid DeleteStudent(Guid id)
        // {
        //     return Students.FirstOrDefault(s => s.Id == id);
        // }

        public static void ShowStudents()
        {
            foreach(var student in Students)
            {
                student.ShowDetails();
                System.Console.WriteLine();
            }
        }

        public static void ShowProfessors()
        {
            foreach(var professor in Professors)
            {
                professor.ShowDetails();
                System.Console.WriteLine();
            }
        }

        // public AdministratorApp()
        // {
        //     var professor = new Professor();
        // }

        public static List<Student> GetStudenWithHighAverage(double threshold = 85)
        {
            return Students.Where(s => s.CalculateAverage() > threshold).ToList();
        }

        public static List<Professor> GetProfessorsTeachingMultipleCourse()
        {
            return Professors.Where(p => p.Courses.Count > 1).ToList();
        }

        public static List<Student> GetStudentsOlderThan(int age)
        {
            return Students.Where(s => s.CalculateAge() > age).ToList();
        }

        public static List<Student> GetStudentsOrderByLastName()
        {
            return Students.OrderBy(s => s.LastName).ToList();
        }

        public static double CalculateTotalProfessorSalary()
        {
            return Professors.Sum(p => p.GetSalary());
        }

        public static Student GetStudentWithHighesGrade()
        {
            return Students.OrderByDescending(s => s.CalculateAge()).FirstOrDefault();
        }

        public static Dictionary<string, int> GetStudentsCountByCourse()
        {
            return Students.GroupBy(s => s.CurrentCourse)
                           .ToDictionary(g => g.Key, g => g.Count());
        }

        public static List<Professor> GetProfessorsWithLongTenure(int years)
        {
            return Professors.Where(p => p.CalculateSeniority() > years).ToList();
        }

        public static List<string> GetUniqueSubjects()
        {
            return Professors.Select(p => p.Subject).Distinct().ToList();
        }

        public static List<Student> GetStudentsByParentName(string parentName)
        {
            return Students.Where(s => s.ParentName == parentName).ToList();
        }

        public static List<Professor> GetProfessorsOrderredBySalaryDescending()
        {
            return Professors.OrderByDescending(p => p.GetSalary()).ToList();
        }

        public static double CalculateAverageStudentAge()
        {
            return Students.Average(s => s.CalculateAge());
        }

        public static List<Professor> GetProfessorsBySubject(string subject)
        {
            return Professors.Where(p => p.Subject == subject).ToList();
        }

        public static List<Student> GetStudentsWithMultipleGrades(int gradeCount)
        {
            return Students.Where(s => s.Grades.Count > gradeCount).ToList();
        }

        public static double CalculateAverageProfessorSeniority()
        {
            return Professors.Average(p => p.CalculateSeniority());
        }
    }
}