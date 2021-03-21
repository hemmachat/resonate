using System;

namespace ConsoleApp1
{
    public class AddTwoNumbersThenDivide<T>
    {
        private const double Zero = 0d;
        private readonly double _divisionNumber;
        private readonly ILogger _logger;

        public AddTwoNumbersThenDivide(T divisionNumber, ILogger logger)
        {
            _logger = logger;
            _divisionNumber = GetArgumentValue(divisionNumber);

            if (_divisionNumber != Zero)
            {
                return;
            }
            
            var ex = new DivideByZeroException();
            _logger.Log(ex.Message);
            throw ex;
        }

        public double Calculate(T firstNumber, T secondNumber)
        {
            var firstNumberValue = GetArgumentValue(firstNumber);
            var secondNumberValue = GetArgumentValue(secondNumber);
            var sumOfTwoNumbers = firstNumberValue + secondNumberValue;
            var result = sumOfTwoNumbers / _divisionNumber;

            return result;
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }
        
        private double GetArgumentValue(T argument)
        {
            double argumentValue;
            
            try
            {
                argumentValue = Convert.ToDouble(argument);
            }
            catch (FormatException e)
            {
                _logger.Log(e.Message);
                throw;
            }
            catch (InvalidCastException e)
            {
                _logger.Log(e.Message);
                throw;
            }
            catch (OverflowException e)
            {
                _logger.Log(e.Message);
                throw;
            }

            return argumentValue;
        }
        
        public static int HigherOrderCalculation(Func<int, int, int> highOrderFunction, int firstArgument, int secondArgument)
        {
            return highOrderFunction(firstArgument, secondArgument);
        }
    }
}