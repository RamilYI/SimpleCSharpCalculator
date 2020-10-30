using System;

namespace SimpleCalculator.Interpretator
{
    /// <inheritdoc />
    internal class BinaryExpression : IExpression
    {
        #region Поля и свойства

        /// <summary>
        ///  Левое выражение.
        /// </summary>
        internal IExpression Lhs { get; }
        
        /// <summary>
        ///  Правое выражение.
        /// </summary>
        internal IExpression Rhs { get; }
        
        /// <summary>
        ///  Операция.
        /// </summary>
        internal ICalculatorOperator Op { get; }
        
        #endregion

        #region IExpression

        /// <inheritdoc />
        public double Interpret()
        {
            return this.Op.Execute(this.Lhs.Interpret(), this.Rhs.Interpret());
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="lhs">Левое выражение.</param>
        /// <param name="rhs">Правое выражение.</param>
        /// <param name="op">Оператор.</param>
        public BinaryExpression(IExpression lhs, IExpression rhs, ICalculatorOperator op)
        {
            this.Lhs = lhs;
            this.Rhs = rhs;
            this.Op = op;
        }
        
        #endregion
    }
}