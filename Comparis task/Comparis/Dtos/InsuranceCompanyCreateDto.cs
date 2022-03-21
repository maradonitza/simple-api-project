using System.ComponentModel.DataAnnotations;

namespace Comparis.Dtos
{
    public class InsuranceCompanyCreateDto
    {
        [Required]
        public string Name { get; set; }    
        public string Description { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    
    }
}