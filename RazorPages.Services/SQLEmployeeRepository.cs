using Microsoft.EntityFrameworkCore;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPages.Services
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee newEmployee)
        {
            //_context.Employees.Add(newEmployee);
            //_context.SaveChanges();
            _context.Database.ExecuteSqlRaw("spAddNewEmployee {0},{1},{2},{3}",
                                            newEmployee.Name,
                                            newEmployee.Email,
                                            newEmployee.PhotoPath,
                                            newEmployee.Departament);

            return newEmployee;
        }

        public Employee Delete(int id)
        {
            var employeeToDelete = _context.Employees.Find(id);

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }

            return employeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _context.Employees;

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
            //return _context.Employees;
            return _context.Employees
                            .FromSqlRaw<Employee>("SELECT * FROM Employees")
                            .ToList();
        }

        public Employee GetEmployee(int Id)
        {
            //return _context.Employees.Find(Id);
            return _context.Employees
                            .FromSqlRaw<Employee>("CodeFirstSpGetEmployeeById {0}", Id)
                            .ToList()
                            .FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _context.Employees;

            return _context.Employees.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Email.ToLower().Contains(searchTerm.ToLower()));
        }

        public Employee Update(Employee updateEmployee)
        {
            var employee = _context.Employees.Attach(updateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return updateEmployee;
        }
    }
}
