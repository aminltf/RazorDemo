#nullable disable

using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Department;

public class EditModel : PageModel
{
    private readonly IDepartmentRepository _departmentRepository;

    [BindProperty]
    public Domain.Entities.Department Department { get; set; }

    public EditModel(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Department = await _departmentRepository.GetByIdAsync(id.Value);

        if (Department == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _departmentRepository.UpdateAsync(Department);
        return RedirectToPage("/Department/Index");
    }

}
