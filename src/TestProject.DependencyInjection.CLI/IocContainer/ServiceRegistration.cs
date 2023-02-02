using Ninject;

using TestProject.DependencyInjection.CLI.InjectionTypes.ConstructorInjection;

namespace TestProject.DependencyInjection.CLI.IocContainer
{
    public class ServiceRegistration
    {
        //Container kernel.
        public IKernel Register()
        {
            //Bind<>
            IKernel kernel = new StandardKernel();

            kernel.Bind<IDatabaseServiceWithCI>()
                .To<DatabaseServiceWithCI>();

            kernel.Bind<IEnrollmentServiceWithCI>()
                .To<EnrollmentServiceWithCI>();

            kernel.Bind<IEnrollmentValidationWithCI>()
                .To<EnrollmentValidationWithCI>();

            return kernel;
        }
    }
}
