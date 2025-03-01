#nullable disable

using Application.DTOs.Employee;

namespace Application.DTOs.Department;

public record DepartmentDTO(Guid Id, string Name, ICollection<EmployeeDTO> Employees);
