using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_Management.Models;

namespace Hospital_Management.ViewModels
{
    public class DoctorCreate
    {
        public Doctor Doctor { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}