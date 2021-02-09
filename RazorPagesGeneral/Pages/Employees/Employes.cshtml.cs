using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPagesGeneral.Pages.Employes
{
    public class EmployesModel : PageModel
    {
        private readonly IEmployeeRepository _db;

        public EmployesModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employee { get; set; }

        public void OnGet()
        {
            Employee = _db.GetAllEmployees();
        }


    }
}
