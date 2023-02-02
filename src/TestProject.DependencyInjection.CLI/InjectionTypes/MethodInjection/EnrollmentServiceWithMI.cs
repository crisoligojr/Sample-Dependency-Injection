using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DependencyInjection.CLI.InjectionTypes.MethodInjection
{
    public class EnrollmentServiceWithMI
    {
        private IDatabaseServiceWithMI _databaseService;
        public virtual void Enroll(Student newStudent)
        {
            var databaseResult = _databaseService.Save(newStudent);

            Console.WriteLine(databaseResult);
            Console.WriteLine($"Student {newStudent.FirstName} has been enrolled.");
            Console.WriteLine("Angie! Method Injection..");
        }

        public virtual void SetDatabaseService(IDatabaseServiceWithMI databaseService)
        {
            _databaseService = databaseService;
        }
    }

    //Service
    //by Practice. you should create this on a separate file
    public interface IDatabaseServiceWithMI
    {
        string Save(Student student);
    }

    public class DatabaseServiceWithMI : IDatabaseServiceWithMI
    {
        public virtual string Save(Student student)
        {
            return $"Student {student.FirstName} has been save to the database.";
        }
    }
}
