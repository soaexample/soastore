using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace StoreFront.IoC
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                        .Where(type => type.Name.EndsWith("Service"))
                        .WithServiceDefaultInterfaces()
                        .Configure(c => c.LifestylePerWebRequest()));
          

        }
    }
}