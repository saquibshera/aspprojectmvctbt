using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TbtAspmvc.Data;
using TbtAspmvc.Models;

namespace TbtAspmvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _dt;

        public ProductController(DataContext dt)
        {
            this._dt = dt;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProducts()
        {
            var products = _dt.Productable.ToList();
            return View(products);
        }
       
        public IActionResult form()
        {
            return View();
        }
        public IActionResult Senddata(Products product)
        {
            _dt.Productable.Add(product);
            _dt.SaveChanges();
            return RedirectToAction("Getproducts");
        }
    }
}
