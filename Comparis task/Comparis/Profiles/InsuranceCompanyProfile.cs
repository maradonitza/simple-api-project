using AutoMapper;
using Comparis.Dtos;
using Comparis.Models;

namespace Comparis.Profiles
{
    public class InsuranceCompanyProfile : Profile
    {
        public InsuranceCompanyProfile()
        {
            CreateMap<InsuranceCompany, InsuranceCompanyReadDto>();
            CreateMap<InsuranceCompanyCreateDto, InsuranceCompany>();
        }
    }
}