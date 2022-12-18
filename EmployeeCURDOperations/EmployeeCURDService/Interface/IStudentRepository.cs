using StudentCURDService.Models;

namespace StudentCURDService.Interface
{
    public interface IStudentRepository
    {
        Student GetStudentDetails(int id);

        bool AddStudent(Student employee);

        List<Student> GetAllStudents();
    }
}
