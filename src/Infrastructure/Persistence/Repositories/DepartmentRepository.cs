#nullable disable

using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
}
