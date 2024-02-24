using EmployeeCURDService.Interface;
using EmployeeCURDService.Models;
using EmployeeCURDService.ServiceClient;
using EmployeeTestService.MockRepository;
using Moq;
using Moq.Protected;
using System.Net.Http.Json;

namespace EmployeeTestService
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public async Task Test_GetEmployeeSalary()
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            HttpResponseMessage httpRequestMessage = new()
            {
                Content = JsonContent.Create(new
                {
                    Salary = "1000"
                })
            };

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpRequestMessage);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);

            var serviceClient = new ServiceClientHelper(httpClient);

            var retrievedPosts = await serviceClient.GetEmployeeSalary(1);

            Assert.IsNotNull(retrievedPosts);
        }
    }
}