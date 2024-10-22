﻿using FMP_MVC.APPDB;
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
        public ActionResult Delete_C(string id)
        {
            _db.Customers.Remove(_db.Customers.Find(int.Parse(id)));
            _db.SaveChanges();
            return Redirect("view");
        }

        [HttpPost]
        public ActionResult Update_C(Composite composite)
        {
            _db.Customers.Update(composite.customer);
            _db.SaveChanges();
            return Redirect("view");
        }

        public ActionResult Delete_M(string id)
        {
            _db.Movies.Remove(_db.Movies.Find(int.Parse(id)));
            _db.SaveChanges();
            return Redirect("view");
        }

        [HttpPost]
        public ActionResult Update_M(Composite composite)
        {
            _db.Movies.Update(composite.movie);
            _db.SaveChanges();
            return Redirect("view");
        }

        public ActionResult Delete_T(string id)
        {
            _db.Tickets.Remove(_db.Tickets.Find(int.Parse(id)));
            _db.SaveChanges();
            return Redirect("view");
        }

        [HttpPost]
        public ActionResult Update_T(Composite composite)
        {
            _db.Tickets.Update(composite.ticket);
            _db.SaveChanges();
            return Redirect("view");
        }
    }
}
