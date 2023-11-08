using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeProject.Entities.Dtos
{
    public record EmployeeDtoForUpdate
    {
        
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        public string IdNumber { get; init; }
        [AllowNull]
        public int? SeniorId { get; init; } 
    }
}
