using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // these will need to inject by IoC container
            var consoleLogger = new ConsoleLogger();
            var fileLogger = new FileLogger();
            
            var firstFunction = new AddTwoNumbersThenDivide<double>(1.5d, consoleLogger);
            firstFunction.Log("hello console logger");
            var result1 = firstFunction.Calculate(1, 2);
            var result2 = AddTwoNumbersThenDivide<double>.HigherOrderCalculation((x, y) => x + y, 3, 4);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            
            var secondFunction = new AddTwoNumbersThenDivide<double>(2d, fileLogger);
            secondFunction.Log("hello file logger");
            var result3 = secondFunction.Calculate(1, 2);
            var result4 = AddTwoNumbersThenDivide<double>.HigherOrderCalculation((x, y) => x - y, 3, 4);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
            
            //*** SMALL INPUT ***//
            double[,] smallInput = new double[,] { { 1, 4, 3 }, { 2, 3, 4 }, { 1, 3, 7 }, { 5, 4, 2 } };

            // Mocked example of execution
            Console.WriteLine("=== Small Input - Mocked Execution ===");
            var mockResult = Mock.DoAggregations(smallInput);
            IsResultCorrect(mockResult);

            // Your code execution
            Console.WriteLine("\n=== Small Input - Solution Execution ===");
            var result = Solution.DoAggregations(smallInput);
            IsResultCorrect(result);

            //*** LARGE INPUT ***//
            Console.WriteLine("\n=== Large Input - Solution Execution ===");
            var largeInput = GenerateLargeInput();
            var sw = Stopwatch.StartNew();
            for(int i = 0; i<5; i++)
                Solution.DoAggregations(largeInput);
            sw.Stop();
            IsExecutionFastEnough(sw.ElapsedMilliseconds/5);
        }
        
        public static double[,] GenerateLargeInput()
        {		
            int numRows = 15000;
            int numCols = 100;
		
            var input = new double[numRows, numCols];
            Random rnd = new Random(123);
            for (int col = 0; col < numCols; col++)
            for (int row = 0; row < numRows; row++)
                input[row, col] = rnd.Next(100000);
		
            return input;
        }

        public static void IsResultCorrect(Dictionary<string, double>[] result)
        {
            if (
                result[0]["SUM"] == 9d &&
                result[1]["SUM"] == 14d &&
                result[2]["SUM"] == 16d &&
                result[0]["AVERAGE"] == 2.25d &&
                result[1]["AVERAGE"] == 3.5d &&
                result[2]["AVERAGE"] == 4d &&
                result[0]["COUNT DISTINCT"] == 3d &&
                result[1]["COUNT DISTINCT"] == 2d &&
                result[2]["COUNT DISTINCT"] == 4d
            )
            {
                Console.WriteLine("IsResultCorrect Passed");
                return;
            }

            Console.WriteLine("IsResultCorrect Failed");
        }

        public static void IsExecutionFastEnough(double milliSeconds)
        {
		
            if(milliSeconds < 90)
                Console.WriteLine($"IsExecutionFastEnough DIAMOND!!!: {milliSeconds}ms");
            else if(milliSeconds < 105)
                Console.WriteLine($"IsExecutionFastEnough GOLD!: {milliSeconds}ms");
            else if(milliSeconds < 150)
                Console.WriteLine($"IsExecutionFastEnough SILVER: {milliSeconds}ms");
            else
                Console.WriteLine($"IsExecutionFastEnough BRONZE: {milliSeconds}ms");
        }
    }
}