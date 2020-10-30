using System;
using SimpleCalculator.Parser;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var expression = new CalculatorParser(Console.ReadLine()).Parse();
                if (expression != null) Console.WriteLine(expression.Interpret());
            }            
        }
    }
}