#nullable disable

using Application.DTOs.Department;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Department;

public class CreateModel : PageModel
{
    private readonly IDepartmentRepository _departmentRepository;

    public CreateModel(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [BindProperty]
    public DepartmentCreateDTO DepartmentCreate { get; set; }
    
    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var department = new Domain.Entities.Department
        {
            Name = DepartmentCreate.Name
        };

        await _departmentRepository.AddAsync(department);

        return RedirectToPage("/Department/Index");
    }
}
