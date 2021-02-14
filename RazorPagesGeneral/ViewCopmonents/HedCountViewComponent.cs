using Microsoft.AspNetCore.Mvc;
using RazorPages.Models;
using RazorPages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.General.ViewCopmonents
{
    public class HedCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HedCountViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke(Dept? department = null)
        {
            var result = _employeeRepository.EmployeCountByDept(department);
            return View(result);
        }
    }
}
