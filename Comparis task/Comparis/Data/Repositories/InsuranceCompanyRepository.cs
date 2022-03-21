using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Comparis.Data.Interfaces;
using Comparis.Models;
using Microsoft.Extensions.Logging;

namespace Comparis.Data.Repositories
{
    public class InsuranceCompanyRepository : IInsuranceCompanyRepository
    {
        private readonly PetInsuranceDbContext _context;
        private readonly ILogger _logger;
        public InsuranceCompanyRepository(PetInsuranceDbContext context, ILogger<InsuranceCompanyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void CreateInsuranceCompany(InsuranceCompany insuranceCompany)
        {
            _logger.LogInformation($"Creating insurance company... {JsonSerializer.Serialize(insuranceCompany)}");
            
            if(insuranceCompany == null)
            {
                throw new ArgumentNullException(nameof(insuranceCompany));
            }
            _context.InsuranceCompanies.Add(insuranceCompany);
        }

        public IEnumerable<InsuranceCompany> GetAllInsuranceCompanies()
        {
            _logger.LogInformation($"Retrieving all companies");

            return _context.InsuranceCompanies.ToList();
        }

        public InsuranceCompany GetInsuranceCompanyById(int id)
        {
            _logger.LogInformation($"Retrieving company by id: {id}...");

            return _context.InsuranceCompanies.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<InsuranceCompany> GetInsuranceCompanyWithNameLike(string text)
        {
            _logger.LogInformation($"Retrieving company with name like: {text}...");

            var matchingCompanies = _context.InsuranceCompanies.Where(c => c.Name.Contains(text));
            
            if(matchingCompanies == null)
                return null;
            return matchingCompanies.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}