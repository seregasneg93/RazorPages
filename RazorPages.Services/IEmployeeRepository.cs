using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Services
{
   public interface IEmployeeRepository
    {
        // для пречесления
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int Id);
        Employee Update(Employee updateEmployee);
        Employee Add(Employee newEmployee);
    }
}
