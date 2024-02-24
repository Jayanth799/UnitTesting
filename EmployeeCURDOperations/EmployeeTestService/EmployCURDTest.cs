using EmployeeCURDService.Interface;
using EmployeeCURDService.Models;
using EmployeeTestService.MockRepository;
using Moq;

namespace EmployeeTestService
{
    [TestClass]
    public class EmployCURDTest
    {

        public TestContext TestContext { get; set; }

        public MockEmployeeRepository MockEmployeeRepository = new MockEmployeeRepository();


        [TestMethod]
        public void MockEmployee()
        {

            List<Employee> employees = new List<Employee>
            {
                //new Employee
                //{
                //Id= 1,
                //Name = "Jayanth",
                //Address = "hyd",
                //MobileNumber="7997699029",
                //Role = "Dev"
                //},
            new Employee {Id = 1,Name = "Venkatesh Kandregula", Role = "Developer"},
            new Employee {Id = 2,Name = "Goutham Jampula", Role = "Developer"},
            new Employee {Id = 3,Name = "Charan Neermula", Role = "Developer"}
            };

            Mock<IEmployeeRepository> mockEmployeeRepository = new Mock<IEmployeeRepository>();

            mockEmployeeRepository.Setup(mr => mr.GetAllEmployees()).Returns(employees);

            mockEmployeeRepository.Setup(mr => mr.GetEmployeeDetails(It.IsAny<int>())).Returns((int i) => employees.FirstOrDefault(e => e.Id == i));

            // Allows us to test saving a product
            mockEmployeeRepository.Setup(mr => mr.AddEmployee(It.IsAny<Employee>())).Returns(
                (Employee target) =>
                {

                    if (target.Id.Equals(default(int)))
                    {
                        target.Id = employees.Count() + 1;
                        employees.Add(target);
                    }
                    else
                    {
                        var original = employees.FirstOrDefault(
                            q => q.Id == target.Id);

                        if (original == null)
                        {
                            return true;
                        }

                        original.Name = target.Name;
                        original.Role = target.Role;
                    }

                    return true;
                });
        }


        [TestMethod]
        public void Test_CanReturnEmployeeById()
        {
            Employee employee = MockEmployeeRepository.GetEmployeeDetails(1);

            Assert.IsNotNull(employee);
            Assert.IsInstanceOfType(employee, typeof(Employee));
            Assert.AreEqual("Venkatesh Kandregula", employee.Name);
        }



        [TestMethod]
        public void Test_CanInsertEmployee()
        {
            Employee newEmployee = new Employee()
            { Id = 4, Name = "Ramesh", Role = "Developer" };

            int employeeCount = this.MockEmployeeRepository.GetAllEmployees().Count;
            Assert.AreEqual(3, employeeCount);

            this.MockEmployeeRepository.AddEmployee(newEmployee);

            employeeCount = this.MockEmployeeRepository.GetAllEmployees().Count;
            Assert.AreEqual(4, employeeCount);

            Employee testEmployee = this.MockEmployeeRepository.GetEmployeeDetails(3);
            Assert.IsNotNull(testEmployee);
            Assert.IsInstanceOfType(testEmployee, typeof(Employee));
            Assert.AreEqual("Charan Neermula", testEmployee.Name);
        }


        [TestMethod]
        public void CanUpdateEmployee()
        {
            Employee testEmployee = this.MockEmployeeRepository.GetEmployeeDetails(1);

            testEmployee.Name = "Venkatesh Kandregula";

            this.MockEmployeeRepository.AddEmployee(testEmployee);

            Assert.AreEqual("Venkatesh Kandregula", this.MockEmployeeRepository.GetEmployeeDetails(1).Name);
        }
    }
}