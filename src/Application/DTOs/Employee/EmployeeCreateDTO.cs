#nullable disable

using Domain.Enums;

namespace Application.DTOs.Employee;

public record EmployeeCreateDTO(string FirstName, string LastName, string Email, DateOnly BirthDate, Gender Gender, Guid DepartmentId);
