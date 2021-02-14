using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.General.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DeleteModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Employee Employe { get; set; }
        public IActionResult OnGet(int id)
        {
            Employe = _employeeRepository.GetEmployee(id);

            if (Employe == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            Employee deleteEmploye = _employeeRepository.Delete(Employe.Id);

            if (deleteEmploye.PhotoPath != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", deleteEmploye.PhotoPath);

                if (deleteEmploye.PhotoPath != "noimage.png")
                    System.IO.File.Delete(filePath);
            }

            if (deleteEmploye == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Employes");
        }
    }
}
