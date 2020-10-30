using System;
using System.Collections.Generic;
using System.IO;
using SimpleCalculator.Parser;

namespace SimpleCalculator.Interpretator
{
    /// <summary>
    /// Менеджер калькулятора.
    /// </summary>
    public class CalculatorOperatorManager
    {
        #region Поля и свойства

        private readonly Dictionary<Token, Func<double, double, double>> operatorsMap;
        private readonly Dictionary<Token, Priority> prioritiesMap;

        #endregion

        #region Методы

        /// <summary>
        /// Получить оператор.
        /// </summary>
        /// <param name="token">Токен.</param>
        /// <returns>Оператор.</returns>
        public ICalculatorOperator GetCalculatorOperator(Token token)
        {
            return new CalculatorOperator(this.operatorsMap[token], this.prioritiesMap[token]);
        }

        /// <summary>
        /// Определить, содержится ли ключ словаря или нет. 
        /// </summary>
        /// <param name="token">Токен.</param>
        /// <returns>Булево значение.</returns>
        public bool HasKey(Token token)
        {
            return this.operatorsMap.ContainsKey(token) && this.prioritiesMap.ContainsKey(token);
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор.
        /// </summary>
        public CalculatorOperatorManager()
        {
            this.operatorsMap = new Dictionary<Token, Func<double, double, double>>
            {
                {Token.Add, (a, b) => a + b},
                {Token.Substract, (a, b) => a - b},
                {Token.Multiply, (a, b) => a * b},
                {Token.Divide, (a, b) => a / b},
            };
            this.prioritiesMap = new Dictionary<Token, Priority>
            {
                {Token.Add, Priority.Low},
                {Token.Substract, Priority.Low},
                {Token.Multiply, Priority.High},
                {Token.Divide, Priority.High},
            };
        }
        
        #endregion
    }
}