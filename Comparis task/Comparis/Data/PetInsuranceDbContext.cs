using Comparis.Models;
using Microsoft.EntityFrameworkCore;

namespace Comparis.Data
{
    public class PetInsuranceDbContext: DbContext
    {
        public PetInsuranceDbContext(DbContextOptions<PetInsuranceDbContext> opt): base(opt)
        {
        }
        public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
    }
}