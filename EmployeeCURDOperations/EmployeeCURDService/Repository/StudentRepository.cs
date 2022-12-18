using StudentCURDService.Interface;
using StudentCURDService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StudentCURDService.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly  StudentDBContext _studentDBContext;

        public StudentRepository(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }

        public Student GetStudentDetails(int id)
        {
            Student employee = new();

            try
            {
                employee = _studentDBContext.Student.FirstOrDefault(e => e.Id == id);

            }
            catch (Exception ex)
            {

            }

            return employee;
        }

        public List<Student> GetAllStudents()
        {
            List <Student> employees = new List<Student>();
            try
            {
                 employees = _studentDBContext.Student.ToList();

            }
            catch (Exception ex)
            {

            }

            return employees;
        }

        public bool AddStudent(Student employee)
        {
            bool result = new();

            try
            {
                if (employee.Id > 0) 
                {
                    Student employeeData = new();

                    employeeData = _studentDBContext.Student.FirstOrDefault(e => e.Id == employee.Id);

                    if (employee != null)
                    {
                        employeeData = employee;
                        int response = _studentDBContext.SaveChanges();

                        if (response > 0)
                        {
                            result = true;
                        }
                    }
                }
                else
                {
                    _studentDBContext.Student.Add(employee);
                    _studentDBContext.SaveChanges();
                }
                 
            }
            catch(Exception ex)
            {

            }

            return result;
        }


        public bool DeleteStudentById(int id)
        {
            Student employee = new();

            bool result = false;

            try
            {
                employee = _studentDBContext.Student.FirstOrDefault(e => e.Id == id);

                if (employee != null)
                {
                    _studentDBContext.Student.Remove(employee);

                    int response = _studentDBContext.SaveChanges();

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
