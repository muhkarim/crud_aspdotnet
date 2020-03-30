using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.Models;
using CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.MyContext;
using System.Data.Entity;
using System.Data;

namespace CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.Controllers
{
    public class ItemController : Controller
    {
        myContext conn = new myContext();
        
        // GET: Item
        public ActionResult Index()
        {
            return View(conn.Items.Include(s=>s.Supplier).ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {

            return View(conn.Items.Where(X => X.Id == id).FirstOrDefault());
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(conn.Suppliers, "Id", "Name");

            PopulateSuppliersDropDownList();
            return View();
        }

        private void PopulateSuppliersDropDownList(object selectedSupplier = null)
        {
            var supplierQuery = from s in conn.Suppliers
                                   orderby s.Name
                                   select s;
            ViewBag.Id = new SelectList(supplierQuery, "Id", "Name", selectedSupplier);
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Price, Stock, SupplierID")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    conn.Items.Add(item);
                    conn.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            PopulateSuppliersDropDownList(item.SupplierID);

            return View(item);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            PopulateSuppliersDropDownList();
            return View(conn.Items.Where(X => X.Id == id).FirstOrDefault());
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Item item )
        {
            try
            {
                // TODO: Add update logic here
                conn.Entry(item).State = EntityState.Modified;
                conn.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View(conn.Items.Where(X => X.Id == id).FirstOrDefault());
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Item item = conn.Items.Where(x => x.Id == id).FirstOrDefault();
                conn.Items.Remove(item);
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
