using AutoMapper;
using WebAPI.NET7.Domain.DTOs;
using WebAPI.NET7.Domain.Model;

namespace WebAPI.NET7.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
        }
    }
}

