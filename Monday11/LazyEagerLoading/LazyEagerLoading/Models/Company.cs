using System.ComponentModel.DataAnnotations;

namespace LazyEagerLoading.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        public ICollection<Employee> Emp{ get; set; }  //why not IList beacause IList gave indexer
                                                             //to search element in list while ICollection
                                                             //does not have indexer for serching element
                                                             //using index 
                                                             //IList inherite ICollection 
                                                             //ICollection inherite IEnumerable
    }
}
