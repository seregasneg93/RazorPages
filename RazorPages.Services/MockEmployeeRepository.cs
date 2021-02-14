using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employeeDelete = _employeeList.FirstOrDefault(x => x.Id == id);

            if (employeeDelete != null)
                _employeeList.Remove(employeeDelete);

            return employeeDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _employeeList;

            if (dept.HasValue)
                query = query.Where(x => x.Departament == dept.Value);

            return query.GroupBy(x => x.Departament)
                                .Select(x => new DeptHeadCount()
                                {
                                    Department = x.Key.Value,
                                    Count = x.Count()
                                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _employeeList;

            return _employeeList.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Email.ToLower().Contains(searchTerm.ToLower()));
        }

        public Employee Update(Employee updateEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == updateEmployee.Id);

            if (employee != null)
            {
                employee.Name = updateEmployee.Name;
                employee.Email = updateEmployee.Email;
                employee.Departament = updateEmployee.Departament;
                employee.PhotoPath = updateEmployee.PhotoPath;
            }

            return employee;
        }
    }
}
