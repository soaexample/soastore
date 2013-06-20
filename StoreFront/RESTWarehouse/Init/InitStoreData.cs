using Raven.Client;
using StoreFront.Domain.Entities;

namespace RESTWarehouse.Init
{
    public class InitStoreData
    {
        private readonly IDocumentSession session;

        public InitStoreData(IDocumentSession session)
        {
            this.session = session;
        }

        public void InitData()
        {
            var product1 = new Product {Name = "Chomik"};
            session.Store(product1);

            session.SaveChanges();
            
        }
    }
}