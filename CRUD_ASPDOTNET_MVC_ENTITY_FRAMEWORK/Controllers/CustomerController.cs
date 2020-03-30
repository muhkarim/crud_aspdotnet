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
    

    public class CustomerController : Controller
    {
        // GET: Customer/Index
        public ActionResult Index()
        {
            myContext conn = new myContext();

            return View(conn.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            myContext conn = new myContext();

            return View(conn.Customers.Where(X => X.Id ==  id).FirstOrDefault());
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            myContext conn = new myContext();
            try
            {
                // TODO: Add insert logic here
                conn.Customers.Add(customer);
                conn.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {

            myContext conn = new myContext();
            return View(conn.Customers.Where(X => X.Id == id).FirstOrDefault());
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            myContext conn = new myContext();

            try
            {
                // TODO: Add update logic here
                conn.Entry(customer).State = EntityState.Modified;
                conn.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            myContext conn = new myContext();
            return View(conn.Customers.Where(X => X.Id == id).FirstOrDefault());
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            myContext conn = new myContext();
            try
            {
                // TODO: Add delete logic here
                Customer customer = conn.Customers.Where(x => x.Id == id).FirstOrDefault();
                conn.Customers.Remove(customer);
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
