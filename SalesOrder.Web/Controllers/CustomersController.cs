using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesOrder.Entity;
using SalesOrder.Web.Models;

namespace SalesOrder.Web.Controllers
{   
    public class CustomersController : Controller
    {
        private SalesOrderWebContext context = new SalesOrderWebContext();

        public CustomersController()
        {
            
        }
        //
        // GET: /Customers/

        public ViewResult Index()
        {
            return View(context.Customers.Include(customer => customer.State).Include(customer => customer.Orders).ToList());
        }

        //
        // GET: /Customers/Details/5

        public ViewResult Details(int id)
        {
            Customer customer = context.Customers.Single(x => x.Id == id);
            return View(customer);
        }

        //
        // GET: /Customers/Create

        public ActionResult Create()
        {
            ViewBag.PossibleStates = context.States;
            return View();
        } 

        //
        // POST: /Customers/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleStates = context.States;
            return View(customer);
        }
        
        //
        // GET: /Customers/Edit/5
 
        public ActionResult Edit(int id)
        {
            Customer customer = context.Customers.Single(x => x.Id == id);
            ViewBag.PossibleStates = context.States;
            return View(customer);
        }

        //
        // POST: /Customers/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleStates = context.States;
            return View(customer);
        }

        //
        // GET: /Customers/Delete/5
 
        public ActionResult Delete(int id)
        {
            Customer customer = context.Customers.Single(x => x.Id == id);
            return View(customer);
        }

        //
        // POST: /Customers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = context.Customers.Single(x => x.Id == id);
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}