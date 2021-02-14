using System;
using System.Collections.Generic;
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
        // GET: Departments
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = _context.Departments.Single(p => p.Id == id);
            if (department == null)
                return HttpNotFound();
            return View(department);
        }
    }
}