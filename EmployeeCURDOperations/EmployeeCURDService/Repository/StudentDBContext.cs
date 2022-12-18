using StudentCURDService.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentCURDService.Repository
{
    public class StudentDBContext: DbContext
    {
        public DbSet<Student> Student { get; set; }
    }
}
