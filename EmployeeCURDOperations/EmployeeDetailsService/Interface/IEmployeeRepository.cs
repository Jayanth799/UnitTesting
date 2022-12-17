using EmployeeCURDService.Models;

namespace EmployeeCURDService.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeDetails(string Name);
    }
}
