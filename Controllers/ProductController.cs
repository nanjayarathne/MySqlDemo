using MySqlDemo.DataAccess.Factory;
using MySqlDemo.DataAccess.Interface;
using MySqlDemo.DataAccess.Model;
using MySqlDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySqlDemo.Controllers
{
    public class ProductController : Controller
    {
        IProductDao objProductDao = null;

        public ProductController()
        {
            this.objProductDao = DaoFactory.CreateProductDao();
        }

        // GET: Product
        public ActionResult Index()
        {
            List<ProductModel> list = (from data in objProductDao.GetData().ToList()
                                       select new ProductModel()
                                       {
                                           Id=data.Id,
                                           Name=data.Name,
                                           Price=data.Price,
                                           qty=data.qty
                                       }).ToList();
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objProductDao.AddProduct(new Product() {Name=model.Name,Price=model.Price,qty=model.qty });
                    return RedirectToAction("Index");
                }
                

            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
