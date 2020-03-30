using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.Models;
using CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.MyContext;
using System.Data.Entity;

namespace CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.Controllers
{
    public class SupplierController : Controller
    {
        myContext conn = new myContext();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(conn.Suppliers.ToList());

        }

        // GET: USING JSON
        //public ActionResult List()
        //{
        //    IEnumerable<Supplier> supplist = null;
        //    supplist = conn.Suppliers.ToList();
        //    return new JsonResult { Data = supplist, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            return View(conn.Suppliers.Where(X => X.Id == id).FirstOrDefault());
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                // TODO: Add insert logic here
                conn.Suppliers.Add(supplier);
                conn.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View(conn.Suppliers.Where(X => X.Id == id).FirstOrDefault());
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Supplier supplier)
        {
           

            try
            {
                // TODO: Add update logic here
                conn.Entry(supplier).State = EntityState.Modified;
                conn.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View(conn.Suppliers.Where(X => X.Id == id).FirstOrDefault());
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Supplier supplier = conn.Suppliers.Where(x => x.Id == id).FirstOrDefault();
                conn.Suppliers.Remove(supplier);
                conn.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
