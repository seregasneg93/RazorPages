using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1, Name = "Mary", Email = "mary@index.mail", PhotoPath = "avatar.png", Departament = Dept.HR
                },
                new Employee()
                {
                    Id = 2, Name = "Mark", Email = "Marky@index.mail", PhotoPath = "avatar2.png", Departament = Dept.IT
                },
                new Employee()
                {
                    Id = 3, Name = "Sveta", Email = "Sergei@index.mail", PhotoPath = "avatar3.png", Departament = Dept.IT
                },
                new Employee()
                {
                    Id = 4, Name = "Boris", Email = "Boris@index.mail", PhotoPath = "avatar4.png", Departament = Dept.Payroll
                },
                new Employee()
                {
                    Id = 5, Name = "Sergei", Email = "Olya@index.mail", PhotoPath = "avatar5.png", Departament = Dept.HR
                },
                new Employee()
                {
                    Id = 6, Name = "Dima", Email = "Dima@index.mail", Departament = Dept.Payroll
                }
            };
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}
