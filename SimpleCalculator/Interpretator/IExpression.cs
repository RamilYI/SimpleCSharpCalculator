namespace SimpleCalculator.Interpretator
{
    /// <summary>
    /// Выражение.
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        ///  Интерпретировать.
        /// </summary>
        /// <returns>Результат.</returns>
        double Interpret();
    }
}