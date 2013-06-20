using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RESTWarehouse.Init;

namespace RESTWarehouse.IoC
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                        .Where(type => type.Name.EndsWith("Service"))
                        .WithServiceDefaultInterfaces()
                        .Configure(c => c.LifestylePerWebRequest()));
            container.Register(Component.For<InitStoreData>());

        }
    }
}