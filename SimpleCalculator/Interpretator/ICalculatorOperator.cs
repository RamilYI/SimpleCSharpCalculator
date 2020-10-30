using System;
using SimpleCalculator.Parser;

namespace SimpleCalculator.Interpretator
{
    /// <summary>
    /// Оператор.
    /// </summary>
    public interface ICalculatorOperator
    {
        /// <summary>
        /// Делегат выполнения оператора.
        /// </summary>
        Func<double, double, double> Execute { get; }
        
        /// <summary>
        /// Приоритет операции.
        /// </summary>
        Priority Priority { get; }
    }
}