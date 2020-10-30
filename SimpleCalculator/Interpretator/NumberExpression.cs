namespace SimpleCalculator.Interpretator
{
    /// <inheritdoc />
    internal class NumberExpression : IExpression
    {
        #region Поля и свойства

        private readonly double number;

        #endregion

        #region IExpression

        /// <inheritdoc />
        public double Interpret()
        {
            return this.number;
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="number">Число.</param>
        public NumberExpression(double number)
        {
            this.number = number;
        }
        
        #endregion
    }
}