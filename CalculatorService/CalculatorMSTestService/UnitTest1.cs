using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorService;

namespace CalculatorMSTestService
{
    [TestClass]
    public class CalculatotTestService1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int firstNumber = 10;
            int secondeNumber = 20;
            int finalResult = 30;
            int finalValue = CalculatorService.Repository.CalculatorRepository.Calculator(10,20,"Add");

            Assert.AreEqual(finalValue, finalResult);

        }
    }
}
