using System;
using SimpleCalculator.Parser;

namespace SimpleCalculator.Interpretator
{
    /// <inheritdoc />
    public class CalculatorOperator : ICalculatorOperator
    {
        #region ICalculatorOperator

        /// <inheritdoc />
        public Priority Priority { get; }

        /// <inheritdoc />
        public Func<double,double,double> Execute { get; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="execute">Делегат выполнения оператора.</param>
        /// <param name="priority">Приоритет операции.</param>
        public CalculatorOperator(Func<double,double,double> execute, Priority priority)
        {
            this.Execute = execute;
            this.Priority = priority;
        }
        
        #endregion
    }
}