using Ninject;
using System;

using TestProject.DependencyInjection.CLI.InjectionTypes.ConstructorInjection;
using TestProject.DependencyInjection.CLI.InjectionTypes.MethodInjection;
using TestProject.DependencyInjection.CLI.InjectionTypes.PropertyInjection;
using TestProject.DependencyInjection.CLI.IocContainer;

namespace TestProject.DependencyInjection.CLI
{
    class Program
    {
        //Tightly Coupled Class - isang class dependent sa isang class.
        //Loosely Coupled Class - isang class hindi dependent sa isang class.

        //There are 3 main types of Dependency Injection.
        // 1. Property Injection
        // 2. Method Injection
        // 3. Constructor Injection
        // 4. Inversion of Control Container(IoC)
        //
        static void Main(string[] args)
        {
            //var studentService = new EnrollmentService();
            //var studentService = new EnrollmentServiceWithCI(new DatabaseServiceWithCI());
            IKernel containerNgTubig = new ServiceRegistration().Register();

            var studentService = containerNgTubig.Get<IEnrollmentServiceWithCI>();
            //var studentService = new EnrollmentServiceWithCI(new DatabaseServiceWithCI());

            var newStudent = new Student()
            {
                FirstName = "Joe",
                LastName = "Smith",
                Age = 19
            };

            studentService.Enroll(newStudent);

            Console.ReadLine();
        }
    }

    //Service Class
    public class EnrollmentService
    {
        public virtual void Enroll(Student newStudent)
        {
            var databaseService = new DatabaseService();

            var databaseResult = databaseService.Save(newStudent);

            Console.WriteLine(databaseResult);
            Console.WriteLine($"Student {newStudent.FirstName} has been enrolled.");
            Console.WriteLine("Angie! Tightly Coupled..");
        }
    }

    //Service
    public class DatabaseService
    {
        public virtual string Save(Student student)
        {
            return $"Student {student.FirstName} has been save to the database.";
        }
    }

    public class EnrollmentValidation
    {
        //var enrollmentValidation = new EnrollmentValidation();
        //if (!enrollmentValidation.ValidateAge(newStudent.Age))
        //{
        //    Console.WriteLine("ERROR: Student must be 18 and above.");
        //    return;
        //}

        public virtual bool ValidateAge(int age)
        {
            return (age > 18);
        }
    }

    //Entities
    //by practice, this should be in separate file.
    //POCO - Plain Old CLR Object.
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        //public School School { get; set; }
        //public List<Subject> Subjects { get; set; }
    }

    public class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Subject
    {
        public string Title { get; set; }
    }
}
