using EmployeeCURDService.Interface;
using EmployeeCURDService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmployeeCURDService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly  EmployeeDBContext _employeeDBContext;

        public EmployeeRepository(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }

        public Employee GetEmployeeDetails(string name)
        {
            Employee result = new();

            try
            {
                result =  _employeeDBContext.ITEmployee.FirstOrDefault(e => e.Name == name);
             
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
