#nullable disable

using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

    public Employee() { } // For EF Core
}
