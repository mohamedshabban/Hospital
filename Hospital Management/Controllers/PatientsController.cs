using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.Models;
using Hospital_Management.ViewModels;
using Microsoft.AspNet.Identity;

namespace Hospital_Management.Controllers
{
    
    public class PatientsController : Controller
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Patients
        public ActionResult Register()
        {
            var viewModel = new RegisterPatientViewModel
            {
                Department = new Department(),
                Departments = _context.Departments.ToList(),
                Patient = new Patient(),
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.UserId = User.Identity.GetUserId();
                _context.Patients.Add(patient);
                _context.SaveChanges();
                var patientInDb = _context.Patients.OrderByDescending(p => p.Id)
                    .FirstOrDefault();
                return RedirectToAction("BookingDetails", patientInDb);
            }

            return View(new RegisterPatientViewModel { Patient = patient, Departments = _context.Departments.ToList() });
        }

        public ActionResult BookingDetails(Patient patientInDb)
        {
            if (patientInDb == null)
                return HttpNotFound();
            return View(patientInDb);
        }
        [Authorize(Roles = "Patients")]
        public ActionResult Result()
        {
            var userId = User.Identity.GetUserId();
            var patient = _context.Patients.SingleOrDefault(u => u.UserId == userId);
            if (patient == null)
                return View();
            return View(patient);
        }
        // GET: Patients
        [Authorize(Roles = "Admins,Doctors")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Doctors"))
                {
                    //var userId = User.Identity.GetUserId();
                    //var doctor = _context.Doctors.Single(c=>c.);
                    var patients = _context.Patients.ToList();
                    return View(patients);
                }
                if (User.IsInRole("Admins"))
                {
                    var patients = _context.Patients.ToList();
                    return View(patients);
                }
            }
            
            return View();
        }
        
       
        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }



        // GET: Patients/Edit/5
        [Authorize(Roles = "Admins,Doctors")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return HttpNotFound();
            var viewModel=new RegisterPatientViewModel{Patient = patient,Departments = _context.Departments.ToList()};
            return View(viewModel);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admins,Doctors")]
        public ActionResult Edit(int? id, Patient patient)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new RegisterPatientViewModel { Patient = patient, Departments = _context.Departments.ToList() };
            try
            {
                var patientInDb = _context.Patients.Find(id);
                if (patientInDb == null)
                    return HttpNotFound();
                patientInDb.Age = patient.Age;
                patientInDb.DepartmentId = patient.DepartmentId;
                patientInDb.Name = patient.Name;
                patientInDb.Mobile = patient.Mobile;
                patientInDb.TreatmentId = patient.TreatmentId;
                patientInDb.Result = patient.Result;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Patients/Delete/5
        [Authorize(Roles = "Admins,Doctors")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return HttpNotFound();
            var viewModel = new RegisterPatientViewModel { Patient = patient, 
                Departments = _context.Departments.ToList() };
            return View(viewModel);
        }

        // POST: Patients/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admins,Doctors")]
        public ActionResult Delete(int? id,Patient patient)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patientInDb = _context.Patients.SingleOrDefault(p=>p.Id==id);
            try
            {
                if (patientInDb == null)
                    return HttpNotFound();
                _context.Patients.Remove(patientInDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new RegisterPatientViewModel{Patient = patientInDb,Departments = _context.Departments.ToList()});
            }
        }
    }
}
