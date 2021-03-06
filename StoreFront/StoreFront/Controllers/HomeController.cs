﻿using System.Web.Mvc;
using StoreFront.Services;

namespace StoreFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            var products = productService.GetProducts();

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            var product = productService.GetProductById(id);
            
            //add to cart
            Cart.Instance.AddToCart(product,1);
            
            return new HttpStatusCodeResult(200);
        }

        public ActionResult ShowCart()
        {
            return View(Cart.Instance.Products);
        }
    }
}
