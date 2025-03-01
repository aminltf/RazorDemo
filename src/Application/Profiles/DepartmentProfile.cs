#nullable disable

using Application.DTOs.Department;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        // Map Department DTO to Department Entity
        CreateMap<DepartmentCreateDTO, Department>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Employees, opt => opt.Ignore());

        CreateMap<DepartmentUpdateDTO, Department>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Department, DepartmentDTO>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
    }
}
