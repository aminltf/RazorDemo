#nullable disable

using Domain.Common;

namespace Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; }

    public Department() { } // For EF Core
}
