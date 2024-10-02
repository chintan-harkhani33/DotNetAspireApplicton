using System.ComponentModel.DataAnnotations;

namespace DotNet_aspire_app.ApiService.models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Position is required.")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }
    }
}
