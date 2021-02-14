using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPagesGeneral.Pages.Employes
{
    public class EmployesModel : PageModel
    {
        private readonly IEmployeeRepository _db;
        public IEnumerable<Employee> Employee { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public EmployesModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Employee = _db.Search(SearchTerm);
        }
    }
}
