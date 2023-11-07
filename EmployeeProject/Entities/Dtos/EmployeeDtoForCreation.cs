using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.Entities.Dtos
{
    public record EmployeeDtoForCreation 
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
       
        public string IdNumber { get; init; }
        public int? SeniorId { get; init; }
    }
}
