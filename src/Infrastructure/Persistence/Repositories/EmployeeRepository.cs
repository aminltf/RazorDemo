#nullable disable

using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }
}
