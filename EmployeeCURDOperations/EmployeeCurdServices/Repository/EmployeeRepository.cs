using EmployeeCURDService.Interface;
using EmployeeCURDService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeCURDService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly  EmployeeDBContext _employeeDBContext;

        public EmployeeRepository(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }

        public Employee GetEmployeeDetails(int id)
        {
            Employee employee = new();

            try
            {
                employee = _employeeDBContext.ITEmployee.FirstOrDefault(e => e.Id == id);

            }
            catch (Exception ex)
            {

            }

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            List <Employee> employees = new List<Employee>();
            try
            {
                 employees = _employeeDBContext.ITEmployee.ToList();

            }
            catch (Exception ex)
            {

            }

            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
            bool result = new();

            try
            {
                if (employee.Id > 0) 
                {
                    Employee employeeData = new();

                    employeeData = _employeeDBContext.ITEmployee.FirstOrDefault(e => e.Id == employee.Id);

                    if (employee != null)
                    {
                        employeeData = employee;
                        int response = _employeeDBContext.SaveChanges();

                        if (response > 0)
                        {
                            result = true;
                        }
                    }
                }
                else
                {
                    _employeeDBContext.ITEmployee.Add(employee);
                    _employeeDBContext.SaveChanges();
                }
                 
            }
            catch(Exception ex)
            {

            }

            return result;
        }


        public bool DeleteEmployeeById(int id)
        {
            Employee employee = new();

            bool result = false;

            try
            {
                employee = _employeeDBContext.ITEmployee.FirstOrDefault(e => e.Id == id);

                if (employee != null)
                {
                    _employeeDBContext.ITEmployee.Remove(employee);

                    int response = _employeeDBContext.SaveChanges();

                    if (response > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

    }
}
