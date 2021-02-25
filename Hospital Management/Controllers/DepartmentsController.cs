using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;

namespace Hospital_Management.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmentsController()
        {
            _context=new ApplicationDbContext();
        }
        [Authorize(Roles = "Admins")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = _context.Departments.SingleOrDefault(c => c.Id == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [Authorize(Roles = "Admins")]
        [HttpPost]
        public ActionResult Edit(int? id,Department department)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var deptInDb = _context.Departments.
                SingleOrDefault(d => d.Id == id);
            if (deptInDb == null)
                return HttpNotFound();
            if (!ModelState.IsValid) return View(department);
            deptInDb.Image = department.Image;
            deptInDb.Name = department.Name;
            deptInDb.ShortDescription = department.ShortDescription;
            deptInDb.LongDescription = department.LongDescription;
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
            
           
        }

        [Authorize(Roles = "Admins")]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(department);
        }
        // GET: Departments
        public ActionResult Details(int? id)
        {
            var department = _context.Departments.SingleOrDefault(p => p.Id == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (department == null)
                return HttpNotFound();
            return View(department);
        }

        public ActionResult Delete(int? id)
        {
            if(id==null)return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var department = _context.Departments.SingleOrDefault(d => d.Id == id);
            if (department == null)
                return HttpNotFound();
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}