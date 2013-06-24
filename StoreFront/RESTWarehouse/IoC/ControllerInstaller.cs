using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace RESTWarehouse.IoC
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());
            container.Register(Component.For<DocumentStore>().UsingFactoryMethod(x =>
                {
                    var documentStore = new DocumentStore { ConnectionStringName = "RavenDB", DefaultDatabase = "RESTWarehouse"};
                    documentStore.Initialize();

                    IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), documentStore);
                    return documentStore;
                }).LifestyleSingleton());
            container.Register(Component.For<IDocumentSession>().UsingFactoryMethod(x =>
                {
                    var documentStore = x.Resolve<DocumentStore>();
                    return documentStore.OpenSession();
                }).LifestyleTransient());

            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());

            //container.Register(Component.For<InitStoreData>().LifestyleSingleton());
        }
    }
}