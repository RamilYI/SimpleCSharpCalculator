using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using SimpleCalculator.Helpers;

namespace SimpleCalculator.Parser
{
    /// <summary>
    /// Токенизатор выражения.
    /// </summary>
    public class Tokenizer
    {
        #region Поля и свойства
        
        private Token currentToken;
        private char currentChar;
        private double currentNumber;
        private readonly StringBuilder expression;
        private readonly Dictionary<char, Token> operatorSymbols;
        private bool isExpressionParsed = false;
        private const char DOT = '.';
        /// <summary>
        /// Текущий токен.
        /// </summary>
        public Token Token => this.currentToken;

        /// <summary>
        ///  Текущее число (в случае, если токен - число).
        /// </summary>
        public double Number => currentToken == Token.Number ? currentNumber : throw new InvalidDataException($"Unexpected token: {currentToken}");

        #endregion

        #region Методы

        /// <summary>
        /// Получить следующий токен.
        /// </summary>
        public bool NextToken()
        {
            if (this.isExpressionParsed)
            {
                return false;
            }
            
            while (char.IsWhiteSpace(this.currentChar) || this.currentChar == '\0')
            {
                this.NextChar();
            }

            if (this.operatorSymbols.ContainsKey(this.currentChar))
            {
                this.currentToken = this.operatorSymbols[this.currentChar];
                this.NextChar();
                return true;
            }
            else if (char.IsDigit(this.currentChar))
            {
                var sb = new StringBuilder();
                while (char.IsDigit(this.currentChar) || (!sb.HasSymbol(DOT) && this.currentChar == DOT))
                {
                    sb.Append(this.currentChar);
                    NextChar();
                }

                this.currentNumber = double.Parse(sb.ToString(), CultureInfo.InvariantCulture);
                this.currentToken = Token.Number;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получить следующий char.
        /// </summary>
        private void NextChar()
        {
            if (expression.Length == 0)
            {
                this.currentChar = '\0';
                this.isExpressionParsed = true;
                return;
            }
            
            this.currentChar = char.Parse(expression[0].ToString());
            expression.Remove(0, 1);
        }
        
        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="expression">Выражение для вычисления.</param>
        public Tokenizer(string expression)
        {
            this.expression = new StringBuilder(expression);
            this.operatorSymbols = new Dictionary<char, Token>
            {
                { '+', Token.Add },
                { '-', Token.Substract },
                { '*', Token.Multiply },
                { ':', Token.Divide },
            };
        }
        
        #endregion
    }
}