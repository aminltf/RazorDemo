#nullable disable

using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Employee;

public class IndexModel : PageModel
{
    private readonly IEmployeeRepository _employeeRepository;

    public IndexModel(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<Domain.Entities.Employee> Employees { get; set; }

    public async Task OnGet()
    {
        Employees = await _employeeRepository.GetAllAsync();
    }
}
