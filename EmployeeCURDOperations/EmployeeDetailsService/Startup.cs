using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Owin;
using System;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(EmployeeDetailsService.Startup))]

namespace EmployeeDetailsService
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
