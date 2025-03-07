#nullable disable

using Application.DTOs.Employee;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Employee;

public class CreateModel : PageModel
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public CreateModel(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    [BindProperty]
    public EmployeeCreateDTO EmployeeCreate { get; set; }

    public IEnumerable<Domain.Entities.Department> Departments { get; set; }

    public async Task<IActionResult> OnGet()
    {
        Departments = await _departmentRepository.GetAllAsync();
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            Departments = await _departmentRepository.GetAllAsync();
            return Page();
        }

        var employee = new Domain.Entities.Employee
        {
            FirstName = EmployeeCreate.FirstName,
            LastName = EmployeeCreate.LastName,
            Email = EmployeeCreate.Email,
            BirthDate = EmployeeCreate.BirthDate,
            Gender = Domain.Enums.Gender.Male,
            DepartmentId = EmployeeCreate.DepartmentId
        };

        await _employeeRepository.AddAsync(employee);
        return RedirectToPage("/Employee/Index");
    }
}
