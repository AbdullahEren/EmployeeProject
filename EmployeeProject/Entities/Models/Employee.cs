using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeProject.Entities.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        public string IdNumber { get; set; }

        public int? SeniorId { get; set; }

        public Employee? Senior { get; set; }

    }
}