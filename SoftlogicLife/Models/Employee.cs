using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftlogicLife.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Epf is Required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Epf { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [Column(TypeName = "nvarchar(10)")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number must be a 10-digit number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [Column(TypeName = "varchar(100)")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
