using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        public string Image { get; set; }
        
        public Department Department { get; set; }
        //f.k
        [Display(Name = "Department")]
        public byte DepartmentId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

    }
}