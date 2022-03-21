using System.ComponentModel.DataAnnotations;

namespace Comparis.Models
{
    public class InsuranceCompany
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }    
        public string Description { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    
    }
}