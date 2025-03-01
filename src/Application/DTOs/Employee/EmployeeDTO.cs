#nullable disable

using Application.DTOs.Department;
using Domain.Enums;

namespace Application.DTOs.Employee;

public record EmployeeDTO(Guid Id, string FirstName, string LastName, string Email, DateOnly BirthDate, Gender Gender, Guid DepartmentId, DepartmentDTO Department);
