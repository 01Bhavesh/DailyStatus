using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyEagerLoading.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company company { get; set; }
        [Required]
        public string? EmpName { get; set; }

    }
}