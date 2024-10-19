using FMP_MVC.APPDB;
using FMP_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMP_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DBConfig _db;

        public CustomerController()
        {
            _db = new DBConfig();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return View();
            }
            catch (Exception ex) { return View(); }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Movie movie)
        {
            try
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return View();
            }
            catch (Exception ex) { return View(); }
        }

        [HttpGet]
        public ActionResult Get()
        {
            ViewBag.Customers = _db.Customers.ToList();
            ViewBag.Movies = _db.Movies.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Get(Ticket ticket)
        {
            try
            {
                _db.Tickets.Add(ticket);
                _db.SaveChanges();
                return Redirect("Get");
            }
            catch (Exception ex) { return View(); }
        }

        // GET: Customers
        public ActionResult view()
        {
            ViewBag.Customers = _db.Customers.ToList();
            ViewBag.Movies = _db.Movies.ToList();
            ViewBag.Tickets = _db.Tickets.ToList();
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return View();
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return View();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try{
                _db.Entry(customer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }catch (Exception ex) { return View(customer);}
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return View();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _db.Customers.Find(id);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
