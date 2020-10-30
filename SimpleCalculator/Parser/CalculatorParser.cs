using System;
using SimpleCalculator.Interpretator;

namespace SimpleCalculator.Parser
{
    /// <summary>
    /// Парсер калькулятора.
    /// </summary>
    public class CalculatorParser
    {
        #region Поля и свойства

        private Tokenizer tokenizer;
        private IExpression lhs;
        private IExpression rhs;
        private ICalculatorOperator op;
        private readonly CalculatorOperatorManager _calculatorOperatorManager = new CalculatorOperatorManager();
        
        #endregion

        #region Методы

        /// <summary>
        /// Спарсить выражение.
        /// </summary>
        /// <returns>Выражение.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IExpression Parse()
        {
            while (this.tokenizer.NextToken())
            {
                if (_calculatorOperatorManager.HasKey(this.tokenizer.Token))
                {
                    this.op = this._calculatorOperatorManager.GetCalculatorOperator(this.tokenizer.Token);
                }
                else if (this.tokenizer.Token == Token.Number)
                {
                    switch (this.lhs)
                    {
                        case null:
                            this.lhs = new NumberExpression(this.tokenizer.Number);
                            break;
                       case BinaryExpression binaryLhs:
                           this.rhs = new NumberExpression(this.tokenizer.Number);
                           if (binaryLhs.Op.Priority == Priority.Low && this.op.Priority == Priority.High)
                           {
                               var newRhs = new BinaryExpression(binaryLhs.Rhs, this.rhs, this.op);
                               this.lhs = new BinaryExpression(binaryLhs.Lhs, newRhs, binaryLhs.Op);
                           }
                           else
                           {
                               this.lhs = new BinaryExpression(this.lhs, this.rhs, this.op);
                           }
                           break;
                        default:
                            this.rhs = new NumberExpression(this.tokenizer.Number);
                            this.lhs = new BinaryExpression(this.lhs, this.rhs, this.op);
                            break;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }              
            }

            return this.lhs;
        }
        
        #endregion


        #region Конструктор

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="expressionStr">Строка выражения.</param>
        public CalculatorParser(string expressionStr)
        {
            this.tokenizer = new Tokenizer(expressionStr);
        }
        
        #endregion
    }
}