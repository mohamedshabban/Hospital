using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_Management.Models;

namespace Hospital_Management.ViewModels
{
    public class ListDoctorsViewModel
    {
        
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public Doctor Doctor { get; set; }
        public Department Department { get; set; }
    }
}