using EmployeeCURDService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCURDService.Repository
{
    public class EmployeeDBContext: DbContext
    {
        public DbSet<Employee> ITEmployee { get; set; }
    }
}
