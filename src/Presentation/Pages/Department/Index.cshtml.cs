#nullable disable

using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Department;

public class IndexModel : PageModel
{
    private readonly IDepartmentRepository _departmentRepository;

    public IndexModel(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [BindProperty]
    public IEnumerable<Domain.Entities.Department> Departments { get; set; }

    public async Task OnGet()
    {
        Departments = await _departmentRepository.GetAllAsync();
    }
}
