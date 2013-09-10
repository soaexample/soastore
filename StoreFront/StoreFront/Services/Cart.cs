using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreFront.Domain.Entities;

namespace StoreFront.Services
{
    public class Cart
    {
        public static Cart Instance
        {
            get
            {
                const string cart = "Cart";
                if (HttpContext.Current.Session[cart] == null)
                {
                    HttpContext.Current.Session[cart] = new Cart();
                }
                return (Cart)HttpContext.Current.Session[cart];
            }
        }

        protected Cart()
        {
            Products = new List<CartEntry>();
        }
        public List<CartEntry> Products { get; private set; }

        public void AddToCart(Product p, int count)
        {
            var entry = this.Products.SingleOrDefault(x => x.Product.Id == p.Id);

            if (entry != null)
            {
                entry.Count += count;
            }
            else
            {
                Products.Add(new CartEntry(p, count));
            }
        }
    }


    public class CartEntry
    {
        private readonly Product product;

        public CartEntry(Product product, int count)
        {
            this.product = product;
            this.Count = count;
        }

        public int Count { get; set; }

        public Product Product
        {
            get { return product; }
        }
    }

}