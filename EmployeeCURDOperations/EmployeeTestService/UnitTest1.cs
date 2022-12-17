using EmployeeCURDService.Interface;
using EmployeeCURDService.Models;
using EmployeeCURDService.ServiceClient;
using Microsoft.Extensions.Hosting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Reflection;

namespace EmployeeTestService
{
    [TestClass]
    public class UnitTest1
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