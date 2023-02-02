using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DependencyInjection.CLI.InjectionTypes.ConstructorInjection
{
    public interface IEnrollmentServiceWithCI
    {
        void Enroll(Student newStudent);
    }

    public class EnrollmentServiceWithCI : IEnrollmentServiceWithCI
    {
        private readonly IDatabaseServiceWithCI _databaseService;
        private readonly IEnrollmentValidationWithCI _enrollmentValidationWithCI;

        public EnrollmentServiceWithCI(IDatabaseServiceWithCI databaseService, 
            IEnrollmentValidationWithCI enrollmentValidationWithCI)
        {
            _databaseService = databaseService;
            _enrollmentValidationWithCI = enrollmentValidationWithCI;
        }

        public virtual void Enroll(Student newStudent)
        {
            if (!_enrollmentValidationWithCI.ValidateAge(newStudent.Age))
            {
                Console.WriteLine("Angie! Age must be greater than 18..");
                return;
            }

            var databaseResult = _databaseService.Save(newStudent);

            Console.WriteLine(databaseResult);
            Console.WriteLine($"Student {newStudent.FirstName} has been enrolled. CI");
            Console.WriteLine("Angie! Constructor Injection..");
        }
    }


    //Service
    //by Practice. you should create this on a separate file
    public interface IDatabaseServiceWithCI
    {
        string Save(Student student);
    }
    public class DatabaseServiceWithCI : IDatabaseServiceWithCI
    {
        public virtual string Save(Student student)
        {
            return $"Student {student.FirstName} has been save to the database.";
        }
    }

    public interface IEnrollmentValidationWithCI
    {
        bool ValidateAge(int age);
    }
    public class EnrollmentValidationWithCI : IEnrollmentValidationWithCI
    {
        public virtual bool ValidateAge(int age)
        {
            return (age > 18);
        }
    }
}
