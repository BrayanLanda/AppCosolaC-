using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSchool.Models;

namespace AppSchool.Views
{
    public class ConsoleView
    {
        public int ShowMainManu()
        {
            System.Console.Clear();
            Console.WriteLine("=== Sistema de Gestión Escolar ===");
            Console.WriteLine("1. Gestionar Estudiantes");
            Console.WriteLine("2. Gestionar Profesores");
            Console.WriteLine("3. Realizar Consultas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
            {
                System.Console.Write("Invalid Option, Try Again: ");
            }
            return opcion;
        }

        public int ShowStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Estudiantes ===");
            Console.WriteLine("1. Agregar Estudiante");
            Console.WriteLine("2. Editar Estudiante");
            Console.WriteLine("3. Eliminar Estudiante");
            Console.WriteLine("4. Mostrar Estudiantes");
            Console.WriteLine("5. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
            {
                System.Console.Write("Invalid Option, Try Again: ");
            }
            return opcion;
        }

        public int ShowProfessorMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Profesores ===");
            Console.WriteLine("1. Agregar Profesor");
            Console.WriteLine("2. Editar Profesor");
            Console.WriteLine("3. Eliminar Profesor");
            Console.WriteLine("4. Mostrar Profesores");
            Console.WriteLine("5. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
            {
                Console.Write("Opción inválida. Intente de nuevo: ");
            }
            return option;
        }

        public static int ShowQueryMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Consultas ===");
            Console.WriteLine("1. Estudiantes con promedio superior a 85");
            Console.WriteLine("2. Profesores que enseñan más de un curso");
            Console.WriteLine("3. Estudiantes mayores de 16 años");
            Console.WriteLine("4. Estudiantes ordenados por apellido");
            Console.WriteLine("5. Salario total de profesores");
            Console.WriteLine("6. Estudiante con la calificación más alta");
            Console.WriteLine("7. Número de estudiantes por curso");
            Console.WriteLine("8. Profesores con más de 10 años de antigüedad");
            Console.WriteLine("9. Asignaturas únicas impartidas");
            Console.WriteLine("10. Estudiantes con acudiente 'María'");
            Console.WriteLine("11. Profesores ordenados por salario descendente");
            Console.WriteLine("12. Promedio de edad de estudiantes");
            Console.WriteLine("13. Profesores que enseñan 'Matemáticas'");
            Console.WriteLine("14. Estudiantes con más de tres calificaciones");
            Console.WriteLine("15. Antigüedad promedio de profesores");
            Console.WriteLine("16. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 16)
            {
                Console.Write("Opción inválida. Intente de nuevo: ");
            }
            return option;
        }

        public Student GetStudentInfo(Student student = null)
        {
            Console.Clear();
            Console.WriteLine(student == null ? "=== Agregar Nuevo Estudiante ===" : "=== Editar Estudiante ===");

            System.Console.Write("Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Apellido: ");
            string lastName = Console.ReadLine();

            System.Console.Write("Tipo de Documento: ");
            string documentType = Console.ReadLine();

            System.Console.Write("Numero de Documento: ");
            string documentNumber = Console.ReadLine();

            System.Console.Write("Email: ");
            string email = Console.ReadLine();

            System.Console.Write("Phone: ");
            string phone = Console.ReadLine();

            System.Console.Write("Parent Name: ");
            string parentName = Console.ReadLine();

            System.Console.Write("Curso Actual: ");
            string currentCourse = Console.ReadLine();

            System.Console.Write("Fecha de Nacimiento (YYYY-MM-DD): ");
            DateTime birdDate;
            while(!DateTime.TryParse(Console.ReadLine(), out birdDate))
            {
                System.Console.Write("Formato invalido. Intente de nuevo (YYYY-MM-DD): ");
            }

            if(student == null)
            {
                return new Student(name, lastName, documentType, documentNumber, email, phone, parentName, currentCourse, birdDate);
            }
            else
            {
                //Actualizar los datos del estudiante existente
                student.Name = name;
                student.LastName = lastName;
                student.DocumentType = documentType;
                student.DocumentNumber = documentNumber;
                student.Email = email;
                student.Phone = phone;
                student.ParentName = parentName;
                student.CurrentCourse = currentCourse;
                student.BirthDate = birdDate;

                return student;
            }
        }

        //method para actualizar o editar un professor
        public Professor GetProfessorInfo(Professor professor = null)
        {
            Console.Clear();
            System.Console.WriteLine(professor == null ? "==== Agregar un nuevo professor ====" : "==== Editar un professor ====");

            System.Console.Write("Nombre: ");
            string name = Console.ReadLine();

            System.Console.Write("Apellido: ");
            string lastName = Console.ReadLine();

            System.Console.Write("Tipo de Documento: ");
            string documentType = Console.ReadLine();

            System.Console.Write("Numero de Documento: ");
            string documentNumber = Console.ReadLine();

            System.Console.Write("Email: ");
            string email = Console.ReadLine();

            System.Console.Write("Telefono: ");
            string phone = Console.ReadLine();

            System.Console.Write("Asignatura: ");
            string subject = Console.ReadLine();

            System.Console.Write("Salario: ");
            double salary;
            while(!double.TryParse(Console.ReadLine(), out salary))
            {
                System.Console.Write("Valor invalido. Intente de nuevo");
            }

            System.Console.Write("Fecha de contratacion (YYYY-MM-DD): ");
            DateTime hireDate;
            while(!DateTime.TryParse(Console.ReadLine(), out hireDate))
            {
                System.Console.Write("Formato invalido. Intente de nuevo (YYYY-MM-DD): ");
            }

            if(professor == null)
            {
                return new Professor(name, lastName, documentType, documentNumber, email, phone, subject, salary, hireDate);
            }
            else
            {
                //Actualizar datos del professor existente
                professor.Name = name;
                professor.LastName = lastName;
                professor.DocumentType = documentType;
                professor.DocumentNumber = documentNumber;
                professor.Email = email;
                professor.Phone = phone;
                professor.Subject = subject;
                professor.HireDate = hireDate;

                return professor;
            }
        }

        //Solicita un Id para editar o eliminar
        public Guid GetIdForAction(string action)
        {
            System.Console.Write($"Ingresa el id del registro a {action}: ");
            Guid id;
            while(!Guid.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Id invalido. Intente de nuevo: ");
            }
            return id;
        }

        //Monstrar mensaje y esperar confirmacion del usuario
        public void ShowMessage(string mensaje)
        {
            System.Console.WriteLine(mensaje);
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}