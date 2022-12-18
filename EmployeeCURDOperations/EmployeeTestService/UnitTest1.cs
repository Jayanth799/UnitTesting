namespace StudentTestService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Test_GetStudentFee()
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            HttpResponseMessage httpRequestMessage = new()
            {
                Content = JsonContent.Create(new
                {
                    Fee = "10000"
                })
            };


            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpRequestMessage);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);

            var serviceClient = new ServiceClientHelper(httpClient);

            var retrievedPosts = await serviceClient.GetStudentFee(1);

            Assert.IsNotNull(retrievedPosts);
        }

        [TestMethod]
        public void TestMethod1()
        {

            List<Student> student = new List<Student>
            {
                new Employee{Id=1,Name="Jayanth",Address="Kavuri Hills",MobileNumber="7997699029"},
                new Employee{Id=2,Name="Srinu",Address="Srikakulam",MobileNumber="7997699029"}
            };



            Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();




            mockStudentRepository.Setup(mr => mr.GetAllEmployees()).Returns(employees);



            mockStudentRepository.Setup(mr => mr.GetEmployeeDetails(It.IsAny<int>())).Returns((int i) => employees.Where(e => e.Id == i).Single());



            // Allows us to test saving a product
            mockStudentRepository.Setup(mr => mr.AddEmployee(It.IsAny<Employee>())).Returns(
                (Employee target) =>
                {
                    DateTime now = DateTime.Now;



                    if (target.Id.Equals(default(int)))
                    {
                        target.Id = employees.Count() + 1;
                        employees.Add(target);
                    }
                    else
                    {
                        var original = employees.Where(
                            q => q.Id == target.Id).Single();



                        if (original == null)
                        {
                            return false;
                        }



                        original.Name = target.Name;
                        original.Address = target.Name;
                        original.MobileNumber = target.MobileNumber;
                        original.Role = target.Role;
                    }



                    return true;
                });



            this.MockEmployeeRepository = mockStudentRepository.Object;
        }



        public TestContext TestContext { get; set; }



        //public readonly IEmployeeRepository MockEmployeeRepository;



        public IEmployeeRepository MockEmployeeRepository;



        [TestMethod]
        public void Test_CanReturnEmployeeById()
        {
            Employee employee = MockEmployeeRepository.GetEmployeeDetails(1);



            Assert.IsNotNull(employee);
            Assert.IsInstanceOfType(employee, typeof(Employee));
            Assert.AreEqual("Jayanth", employee.Name);
        }



        [TestMethod]
        public void Test_CanInsertProduct()
        {
            Employee newEmployee = new Employee()
            { Name = "Ramesh", Address = "Chenni", MobileNumber = "8586586522", Role = "Dev" };



            int employeeCount = this.MockEmployeeRepository.GetAllEmployees().Count;
            Assert.AreEqual(2, employeeCount);




            this.MockEmployeeRepository.AddEmployee(newEmployee);



            employeeCount = this.MockEmployeeRepository.GetAllEmployees().Count;
            Assert.AreEqual(3, employeeCount);



            Employee testEmployee = this.MockEmployeeRepository.GetEmployeeDetails(3);
            Assert.IsNotNull(testEmployee);
            Assert.IsInstanceOfType(testEmployee, typeof(Employee));
            Assert.AreEqual("Ramesh", testEmployee.Name);
        }




        [TestMethod]
        public void CanUpdateProduct()
        {
            Employee testEmployee = this.MockEmployeeRepository.GetEmployeeDetails(1);



            testEmployee.Name = "Jayanth Kumar";



            this.MockEmployeeRepository.AddEmployee(testEmployee);



            Assert.AreEqual("Jayanth Kumar", this.MockEmployeeRepository.GetEmployeeDetails(1).Name);
        }


    }
}