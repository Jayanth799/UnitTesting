using EmployeeCURDService.Models;

namespace EmployeeCURDService.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeDetails(int id);

        bool AddEmployee(Employee employee);

        List<Employee> GetAllEmployees();
    }
}
