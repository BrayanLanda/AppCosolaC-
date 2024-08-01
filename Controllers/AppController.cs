using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AppSchool.Models;
using AppSchool.Views;

namespace AppSchool.Controllers
{
    public class AppController
    {
        ConsoleView _view = new ConsoleView();

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                int mainOption = _view.ShowMainManu();
                switch (mainOption)
                {
                    case 1:
                        ManageStudents();
                        break;
                    case 2:
                        ManageProfessors();
                        break;
                    case 3:
                        PerformQueries();
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            }

            _view.ShowMessage("Gracias por usar el sistema de Gestion Escolar");
        }

        private void ManageStudents()
        {
            bool back = false;
            while (!back)
            {
                int option = _view.ShowStudentMenu();
                switch (option)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        EditStudent();
                        break;
                    case 3:
                        DeleteStudent();
                        break;
                    case 4:
                        ShowStudents();
                        break;
                    case 5:
                        back = true;
                        break;
                }
            }
        }

        private void AddStudent()
        {
            Student newStudent = _view.GetStudentInfo();
            AdministratorApp.AddStudent(newStudent);
            _view.ShowMessage("Estudiante agragado con exito");
        }

        private void EditStudent()
        {
            ShowStudents();
            Guid id = _view.GetIdForAction("Editar");
            Student student = AdministratorApp.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Student updatedStudent = _view.GetStudentInfo(student);
                _view.ShowMessage("Estudiante Actualziado con exito");
            }
            else
            {
                _view.ShowMessage("Estudiante no encontrado");
            }
        }

        private void DeleteStudent()
        {
            ShowStudents();
            Guid id = _view.GetIdForAction("eliminar");
            Student student = AdministratorApp.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                AdministratorApp.Students.Remove(student);
                _view.ShowMessage("Estudiante eliminado con éxito.");
            }
            else
            {
                _view.ShowMessage("Estudiante no encontrado.");
            }
        }

        private void ShowStudents()
        {
            AdministratorApp.ShowStudents();
            _view.ShowMessage("Presione cualquir tecla para continuar...");
        }

        private void ManageProfessors()
        {
            // bool back = false;
            // while (!back)
            // {
            //     int option = _view.ShowProfessorMenu();
            //     switch (option)
            //     {

            //     }
            // }
        }

        private void PerformQueries()
        {
            bool back = false;
            while (!back)
            {
                int option = ConsoleView.ShowQueryMenu();
                switch (option)
                {
                    case 1:
                        ShowStudentWithHighAverage();
                        break;
                    case 2:
                        ShowProfessorsTeachingMuiltipleCourses();
                        break;
                    case 3:
                        ShowStudentsOlderThan16();
                        break;
                    case 4:
                        ShowStudentsOrderedByLastName();
                        break;
                    case 5:
                        ShowTotalProfessorSalary();
                        break;
                    case 6:
                        ShowStudentWithHighesGrade();
                        break;
                    case 7:
                        ShowStudentCountByCourse();
                        break;
                    case 8:
                        ShowProfessorsWithLongTenure();
                        break;
                    case 9:
                        ShowUniqueSubjects();
                        break;
                    case 10:
                        ShowStudentsByParentName();
                        break;
                    case 11:
                        ShowProfessorsOrderedBySalary();
                        break;
                    case 12:
                        ShowAverageStudentAge();
                        break;
                    case 13:
                        ShowProfessorBySubject();
                        break;
                    case 14:
                        ShowStudentsWithMultipleGrades();
                        break;
                    case 15:
                        ShowAverageProfessorSeniority();
                        break;
                    case 16:
                        back = true;
                        break;
                }
            }
        }

        private void ShowStudentWithHighAverage()
        {
            var students = AdministratorApp.GetStudenWithHighAverage();
            foreach (var student in students)
            {
                student.ShowDetails();
                System.Console.WriteLine($"Promedio: {student.CalculateAverage():F2}");
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowProfessorsTeachingMuiltipleCourses()
        {
            var professors = AdministratorApp.GetProfessorsTeachingMultipleCourse();
            foreach (var professor in professors)
            {
                professor.ShowDetails();
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowStudentsOlderThan16()
        {
            var students = AdministratorApp.GetStudentsOlderThan(16);
            foreach (var student in students)
            {
                student.ShowDetails();
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowStudentsOrderedByLastName()
        {
            var students = AdministratorApp.GetStudentsOrderByLastName();
            foreach (var student in students)
            {
                student.ShowDetails();
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowTotalProfessorSalary()
        {
            double totalSalary = AdministratorApp.CalculateTotalProfessorSalary();
            System.Console.WriteLine($"Salario total de todos los professores: ${totalSalary:F2}");
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowStudentWithHighesGrade()
        {
            var student = AdministratorApp.GetStudentWithHighesGrade();
            if (student != null)
            {
                student.ShowDetails();
                System.Console.WriteLine($"Promedio mas alto: {student.CalculateAverage():F2}");
            }
            else
            {
                System.Console.WriteLine("No hay estudiantes registrados");
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowStudentCountByCourse()
        {
            var countByCourse = AdministratorApp.GetStudentsCountByCourse();
            foreach (var course in countByCourse)
            {
                System.Console.WriteLine($"Curso: {course.Key}, Numero de estudiante: {course.Value}");
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowProfessorsWithLongTenure()
        {
            var profesores = AdministratorApp.GetProfessorsWithLongTenure(10);
            foreach (var professor in profesores)
            {
                professor.ShowDetails();
                System.Console.WriteLine($"Antiguedad: {professor.CalculateSeniority()} años");
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowUniqueSubjects()
        {
            var subjects = AdministratorApp.GetUniqueSubjects();
            System.Console.WriteLine("Asignaturas unicas impartidas en la escuela");
            foreach (var subject in subjects)
            {
                System.Console.WriteLine(subject);
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowStudentsByParentName()
        {
            System.Console.Write("Ingre el nombre del acudiente: ");
            string parentName = Console.ReadLine();

            var students = AdministratorApp.GetStudentsByParentName(parentName);
            foreach (var student in students)
            {
                student.ShowDetails();
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowProfessorsOrderedBySalary()
        {
            var professors = AdministratorApp.GetProfessorsOrderredBySalaryDescending();
            foreach (var professor in professors)
            {
                professor.ShowDetails();
                System.Console.WriteLine($"Salario: {professor.GetSalary():F2}");
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowAverageStudentAge()
        {
            double averageAge = AdministratorApp.CalculateAverageStudentAge();
            System.Console.WriteLine($"Edad promedio de los estudiantes: {averageAge:F2} años");
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowProfessorBySubject()
        {
            System.Console.WriteLine("Ingrese la asignatura: ");
            string subject = Console.ReadLine();
            var professors = AdministratorApp.GetProfessorsBySubject(subject);
            foreach (var professor in professors)
            {
                professor.ShowDetails();
                System.Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar");
        }

        private void ShowStudentsWithMultipleGrades()
        {
            var students = AdministratorApp.GetStudentsWithMultipleGrades(3);
            foreach (var student in students)
            {
                student.ShowDetails();
                Console.WriteLine($"Número de calificaciones: {student.Grades.Count}");
                Console.WriteLine();
            }
            _view.ShowMessage("Presione cualquier tecla para continuar...");
        }

        private void ShowAverageProfessorSeniority()
        {
            double averageSeniority = AdministratorApp.CalculateAverageProfessorSeniority();
            Console.WriteLine($"Antigüedad promedio de los profesores: {averageSeniority:F2} años");
            _view.ShowMessage("Presione cualquier tecla para continuar...");
        }
    }
}