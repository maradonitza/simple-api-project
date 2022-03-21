using System.Collections.Generic;
using AutoMapper;
using Comparis.Data.Interfaces;
using Comparis.Dtos;
using Comparis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comparis.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class InsuranceCompanyController : ControllerBase
    {
        private readonly IInsuranceCompanyRepository _repository;
        private readonly IMapper _mapper;
        public InsuranceCompanyController(IInsuranceCompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InsuranceCompanyReadDto>> GetAllInsuranceCompanies()
        {
            var companies = _repository.GetAllInsuranceCompanies();
            return Ok(_mapper.Map<IEnumerable<InsuranceCompanyReadDto>>(companies));                
        }    

        [HttpGet("{id}", Name="GetInsuranceCompanyById")]
        public ActionResult<InsuranceCompanyReadDto> GetInsuranceCompanyById(int id)
        {
            var company = _repository.GetInsuranceCompanyById(id);
            return Ok(_mapper.Map<InsuranceCompanyReadDto>(company));                
        }    

        [HttpGet]
        [Route("search")]
        public ActionResult<IEnumerable<InsuranceCompanyReadDto>> GetAllMatchingInsuranceCompanies([FromQuery] string name)
        {
            var companies = _repository.GetInsuranceCompanyWithNameLike(name);
            return Ok(_mapper.Map<IEnumerable<InsuranceCompanyReadDto>>(companies));                
        } 

        [HttpPost]
        public ActionResult<InsuranceCompanyReadDto> CreateInsuranceCompany([FromBody] InsuranceCompanyCreateDto insuranceCompanyCreateDto)
        {
            var company = _mapper.Map<InsuranceCompany>(insuranceCompanyCreateDto);
            _repository.CreateInsuranceCompany(company);
            _repository.SaveChanges();

            var companyReadDto = _mapper.Map<InsuranceCompanyReadDto>(company);

            return CreatedAtRoute(nameof(GetInsuranceCompanyById), new { id = company.Id}, companyReadDto);                
        }         
    }
}