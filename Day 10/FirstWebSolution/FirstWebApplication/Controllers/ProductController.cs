﻿using Microsoft.AspNetCore.Mvc;
using FirstWebApplication.Models;
using FirstWebApplication.Interfaces;
using FirstWebApplication.Services;

namespace FirstWebApplication.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //Product product = new Product
        //{
        //    Id = 1,
        //    Name="Pencil",
        //    Price = 12.4f,
        //    Quantity = 5,
        //    Discount=5,
        //    Description = "Used for writing and drawing",
        //    Picture = "~/Images/Pencil.jpg",
        //    Rating=3
        //};
        //public IActionResult Index()
        //{
        //    return View(product);
        //}
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var result = _productService.AddProduct(product);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
