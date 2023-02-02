using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DependencyInjection.CLI;

namespace TestProject.DependencyInjection.CLI.InjectionTypes.PropertyInjection
{
    public class EnrollmentServiceWithPI
    {
        public IDatabaseServiceWithPI DatabaseServiceWithPI { get; set; }
        public virtual void Enroll(Student newStudent)
        {
            var databaseResult = DatabaseServiceWithPI.Save(newStudent);

            Console.WriteLine(databaseResult);
            Console.WriteLine($"Student {newStudent.FirstName} has been enrolled.");
            Console.WriteLine("Angie! Property Injection..");
        }
    }

    //Service
    //by Practice. you should create this on a separate file
    public interface IDatabaseServiceWithPI
    {
        string Save(Student student);
    }


    public class DatabaseServiceWithPI : IDatabaseServiceWithPI
    {
        public virtual string Save(Student student)
        {
            return $"Student {student.FirstName} has been save to the database.";
        }
    }
}
