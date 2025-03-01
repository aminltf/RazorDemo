#nullable disable

using Domain.Enums;

namespace Application.DTOs.Employee;

public record EmployeeUpdateDTO(Guid Id, string FirstName, string LastName, string Email, DateOnly BirthDate, Gender Gender, Guid DepartmentId);
