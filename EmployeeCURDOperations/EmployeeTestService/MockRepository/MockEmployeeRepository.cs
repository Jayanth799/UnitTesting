using EmployeeCURDService.Interface;
using EmployeeCURDService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTestService.MockRepository
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public MockEmployeeRepository()
        {

        }

        private List<Employee> employees = new List<Employee>()
        {
            //new Employee
            //{
            //    Id= 1,
            //    Name = "Jayanth",
            //    Address = "hyd",
            //    MobileNumber="7997699029",
            //    Role = "Dev"
            //},

                     new Employee {Id = 1,Name = "Venkatesh Kandregula", Role = "Developer"},
            new Employee {Id = 2,Name = "Goutham Jampula", Role = "Developer"},
            new Employee {Id = 3,Name = "Charan Neermula", Role = "Developer"}
        };


        public bool AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return employees.ToList();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
