using System.Collections.Generic;
using Comparis.Models;

namespace Comparis.Data.Interfaces
{
    public interface IInsuranceCompanyRepository
    {
        bool SaveChanges();
        IEnumerable<InsuranceCompany> GetAllInsuranceCompanies();
        InsuranceCompany GetInsuranceCompanyById(int id);
        IEnumerable<InsuranceCompany> GetInsuranceCompanyWithNameLike(string text);
        void CreateInsuranceCompany(InsuranceCompany insuranceCompany);
    }
}