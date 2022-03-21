using Comparis.Data;
using Comparis.Data.Repositories;
using Comparis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparisTests
{
    [TestClass]
    public class InsuranceCompanyRepositoryTests : BaseRepositoryTests
    {
        private readonly Mock<PetInsuranceDbContext> dbContext;
        private readonly Mock<ILogger<InsuranceCompanyRepository>> logger;
        public InsuranceCompanyRepositoryTests()
        {
            var companies = new List<InsuranceCompany>() {
                new InsuranceCompany() {
                    Id = 1,
                    Description = "Protecting all nine lives.",
                    Name = "Animalia",
                    Address = "Address 1",
                    PhoneNumber = "555 555 555"
                },
                new InsuranceCompany() {
                    Id = 2,
                    Description = "Best care for your feathered pets!",
                    Name = "The Happy Rooster",
                    Address = "Address 2",
                    PhoneNumber = "555 555 000" 
                }
            };    

            var companiesDbSet = CreateDbSet(companies.AsQueryable());

            dbContext = new Mock<PetInsuranceDbContext>(new DbContextOptionsBuilder<PetInsuranceDbContext>()
                .UseInMemoryDatabase(databaseName: "PetInsuranceDB").Options);

            dbContext.Setup(o => o.InsuranceCompanies).Returns(companiesDbSet);

            logger = new Mock<ILogger<InsuranceCompanyRepository>>();
        }
        
        [TestMethod]
        public void GetAllInsuranceCompanies_ShouldReturnAllCompanies()
        {
            var sut = new InsuranceCompanyRepository(dbContext.Object, logger.Object);
            var allCompanies = sut.GetAllInsuranceCompanies();
            var actualResult = allCompanies?.Count();
            int expectedResult = 2;
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CreateInsuranceCompany_WithNullArgument_ThenThrowException()
        {
            var sut = new InsuranceCompanyRepository(dbContext.Object, logger.Object);
            Assert.ThrowsException<ArgumentNullException>(() => sut.CreateInsuranceCompany(null));
            // Assert.ThrowsException<IndexOutOfRangeException>(() => sut.CreateInsuranceCompany(null));
        }
    }
}
