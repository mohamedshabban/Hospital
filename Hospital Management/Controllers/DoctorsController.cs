using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.ViewModels;

namespace Hospital_Management.Controllers
{
    [Authorize(Roles = "Doctors")]
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController()
        {
            _context=new ApplicationDbContext();
        }
        // GET: Doctors
        public ActionResult Index()
        {
            return View(_context.Doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var doctor=_context.Doctors.SingleOrDefault(d => d.Id == id);
            var departments = _context.Departments.ToList();
            var viewModel=new ListDoctorsViewModel{Doctor = doctor,Departments = departments};
            if (doctor == null)
                return HttpNotFound();
            return View(viewModel);
        }


        public ActionResult Create()
        {
            var departments = _context.Departments.ToList();
            
            return View(new ListDoctorsViewModel { Departments = departments });
        }
        // POST: Doctors/Create
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            var viewModel = new ListDoctorsViewModel
            {
                Departments = _context.Departments.ToList()
            };
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
          
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var doctorInDb = _context.Doctors.SingleOrDefault(d => d.Id == id);
            var viewModel = new DoctorCreate
            {
                Doctor = doctorInDb, Departments = _context.Departments.ToList()
            };
            return View(viewModel);
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Doctor doctor)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var doctorInDb = _context.Doctors.SingleOrDefault(d => d.Id == id);
            if (doctorInDb == null)
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                doctorInDb.DepartmentId= doctor.DepartmentId;
                doctorInDb.Name= doctor.Name;
                doctorInDb.Image= doctor.Image;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            var viewModel = new DoctorCreate
            {
                Doctor = doctorInDb,
                Departments = _context.Departments.ToList()
            };
            return View(viewModel);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int id)
        {

            var doctorInDb = _context.Doctors.SingleOrDefault(d => d.Id == id);
            if (doctorInDb == null)
                return HttpNotFound();
            var viewModel=new DoctorCreate{Doctor = doctorInDb,Departments = _context.Departments.ToList() };
            return View(viewModel);
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Doctor doctor)
        {
            var doctorInDb = _context.Doctors.SingleOrDefault(d => d.Id == id);
            if (doctorInDb == null)
                return HttpNotFound();
            var viewModel = new DoctorCreate { Doctor = doctorInDb, Departments = _context.Departments.ToList() };
            try
            {
                if (doctorInDb == null)
                    return HttpNotFound();
                _context.Doctors.Remove(doctorInDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }
    }
}
