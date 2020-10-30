using System.Text;

namespace SimpleCalculator.Helpers
{
    /// <summary>
    /// Методы расширения.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Определяет, имеет ли объект StringBuilder заданный символ.
        /// </summary>
        /// <param name="stringBuilder">Объект.</param>
        /// <param name="symbol">Символ.</param>
        /// <returns>Булево значение.</returns>
        internal static bool HasSymbol(this StringBuilder stringBuilder, char symbol)
        {
            for (var i = 0; i < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] == symbol)
                {
                    return true;
                }
            }

            return false;
        }
    }
}