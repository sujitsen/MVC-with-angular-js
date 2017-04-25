using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVC_with_Ajax_JsonResult.Models;
using System.Data.Entity;

namespace MyMVC_with_Ajax_JsonResult.Controllers
{
    public class ProductController : Controller
    {
        TestDMEntities _dbContext;
        public ProductController()
        {
            _dbContext = new TestDMEntities();
        }

     
        public ActionResult Index()
        {
            return View();
        }

     [HttpGet]
        public ActionResult GetProducts()
        {
            var tblProducts = _dbContext.Products.ToList();

            return Json(tblProducts, JsonRequestBehavior.AllowGet);
        }

    
        public ActionResult Get(int id)
        {
            var product = _dbContext.Products.ToList().Find(x => x.Id == id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        public ActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }

            return Json(product, JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }

            return Json(product, JsonRequestBehavior.AllowGet);
        }

     
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = _dbContext.Products.ToList().Find(x => x.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AngularDelete(Product Emp)
        {
            var product = _dbContext.Products.ToList().Find(x => x.Id == Emp.Id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }

            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult reactJSRetreive()
        {
            return View();
        }

        public ActionResult AngularjsRetreive()
        {
            return View();
        }

    }
}
