using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorService;

namespace CalculatorMSTestService
{
    [TestClass]
    public class CalculatotTestService1
    {
        [TestMethod]
        public void Addition_Test_Method1()
        {
            int firstNumber = 10;
            int secondeNumber = 20;

            var finalValue = CalculatorService.Repository.CalculatorRepository.Calculator(firstNumber, secondeNumber, "Addition");

            Assert.AreEqual(finalValue, firstNumber + secondeNumber);

            Assert.AreNotEqual(0, finalValue);

            Assert.IsFalse(finalValue == 0);

            Assert.IsNotNull(finalValue);

            Assert.IsTrue(finalValue > 0);

            finalValue = CalculatorService.Repository.CalculatorRepository.Calculator(firstNumber, secondeNumber, "Multiplication");

            Assert.AreEqual(finalValue, firstNumber * secondeNumber);

            finalValue = CalculatorService.Repository.CalculatorRepository.Calculator(firstNumber, secondeNumber, "Division");

            Assert.AreEqual(finalValue, firstNumber / secondeNumber);

            finalValue = CalculatorService.Repository.CalculatorRepository.Calculator(firstNumber, secondeNumber, "Substraction");

            Assert.AreEqual(finalValue, firstNumber - secondeNumber);

        }

    }
}
