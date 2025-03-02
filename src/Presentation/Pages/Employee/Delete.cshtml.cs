#nullable disable

using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Employee;

public class DeleteModel : PageModel
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteModel(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Domain.Entities.Employee Employee { get; set; }

    public async Task<IActionResult> OnGet(Guid? id)
    {
        if (id is null)
            return NotFound();
        
        Employee = await _employeeRepository.GetByIdAsync(id.Value);
        
        if (Employee is null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPost(Guid? id)
    {
        if (id is null)
            return NotFound();

        await _employeeRepository.DeleteAsync(id.Value);
        return RedirectToPage("/Employee/Index");
    }
}
