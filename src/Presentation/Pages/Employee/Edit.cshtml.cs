#nullable disable

using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Employee;

public class EditModel : PageModel
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EditModel(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    [BindProperty]
    public Domain.Entities.Employee Employee { get; set; }
    public IEnumerable<Domain.Entities.Department> Departments { get; set; }

    public async Task<IActionResult> OnGet(Guid? id)
    {
        if (id is null)
            return NotFound();

        Employee = await _employeeRepository.GetByIdAsync(id.Value);
        Departments = await _departmentRepository.GetAllAsync();

        if (Employee is null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            Departments = await _departmentRepository.GetAllAsync();
            return Page();
        }
        await _employeeRepository.UpdateAsync(Employee);
        return RedirectToPage("/Employee/Index");
    }
}
