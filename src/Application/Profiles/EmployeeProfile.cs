#nullable disable

using Application.DTOs.Employee;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        // Map Employee DTO to Employee Entity
        CreateMap<EmployeeCreateDTO, Employee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Department, opt => opt.Ignore());

        CreateMap<EmployeeUpdateDTO, Employee>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));
    }
}
