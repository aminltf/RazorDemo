#nullable disable

using Domain.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
}
