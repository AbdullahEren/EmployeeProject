using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.Entities.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        private string? idNumber;

        public string IdNumber
        {
            get { return idNumber; }
            set
            {
                if (IsAlphanumeric(value))
                {
                    idNumber = value;
                }
                else
                {
                    throw new ArgumentException("The Id number can only contain numbers and letters.");
                }
            }
        }

        public int? SeniorId { get; set; }

        public Employee? Senior { get; set; }

        
        
        private bool IsAlphanumeric(string text)
        {
            return !string.IsNullOrEmpty(text) && text.All(char.IsLetterOrDigit);
        }
    }

}