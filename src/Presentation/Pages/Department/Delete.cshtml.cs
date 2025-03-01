#nullable disable

using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Department;

public class DeleteModel : PageModel
{
    private readonly IDepartmentRepository _departmentRepository;

    public Domain.Entities.Department Department { get; set; }

    public DeleteModel(IDepartmentRepository departmentRepository)
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

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        await _departmentRepository.DeleteAsync(id.Value);
        return RedirectToPage("/Department/Index");
    }

}
