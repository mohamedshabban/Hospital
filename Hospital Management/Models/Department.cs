using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models
{
    public class Department
    {
        [Key]
        [Display(Name = "Department" )]
        public byte Id { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "ShortDescription")]
        [MaxLength(150)]
        public string ShortDescription { get; set; }
        [Required]
        [Display(Name = "LongDescription")]
        [MaxLength(1000)]
        public string LongDescription { get; set; }
        public string Image { get; set; }
        //1
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        //1
        public Department()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
        }

    }
}