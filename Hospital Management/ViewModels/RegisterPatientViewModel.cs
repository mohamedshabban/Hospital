using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_Management.Models;

namespace Hospital_Management.ViewModels
{
    public class RegisterPatientViewModel
    {
       
        public IEnumerable<Patient> Patients { get; set; }

        public IEnumerable<Department> Departments { get; set; }


        public Department Department { get; set; }
        public Patient Patient { get; set; }
    }
}