using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Repository
{
    public static class CalculatorRepository
    {
        public static  int Calculator(int firstNumber,int secondNumber,string operation)
        {
            int finalValue = 0;

            try
            {
                switch (operation)
                {
                    case "Add":
                        finalValue = firstNumber + secondNumber;
                        break;
                    case "Multiplication":
                        finalValue = firstNumber * secondNumber;
                        break;
                    case "Division":
                        if(secondNumber != 0)
                            finalValue = firstNumber / secondNumber;
                        break;
                    case "Substraction":
                        finalValue = firstNumber - secondNumber;
                        break;
                      
                }

            }
            catch(Exception ex)
            {

            }

            return finalValue;
        }

        //public int Substraction(int firstNumber, int secondNumber)
        //{
        //    int finalValue = 0;

        //    try
        //    {
        //        finalValue = firstNumber - secondNumber;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return finalValue;
        //}

        //public int Division(int firstNumber, int secondNumber)
        //{
        //    int finalValue = 0;

        //    try
        //    {
        //        if(secondNumber !=0)
        //            finalValue = firstNumber/secondNumber;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return finalValue;
        //}

        //public int Multiplication(int firstNumber, int secondNumber)
        //{
        //    int finalValue = 0;

        //    try
        //    {
        //            finalValue = firstNumber * secondNumber;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return finalValue;
        //}


    }
}
