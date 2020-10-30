using NUnit.Framework;
using SimpleCalculator.Parser;

namespace SimpleCalculator.Tests
{
    public class Tests
    {
        [Test]
        public void SimpleTest()
        {
            var expression = new CalculatorParser("5+7");
            Assert.AreEqual(expression.Parse().Interpret(), 12.0, 1e2);
            expression = new CalculatorParser("5 +111");
            Assert.AreEqual(expression.Parse().Interpret(), 116.0, 1e2);
            expression = new CalculatorParser("18 - 13");
            Assert.AreEqual(expression.Parse().Interpret(), 5.0, 1e2);
            expression = new CalculatorParser("12:5");
            Assert.AreEqual(expression.Parse().Interpret(), 2.4, 1e2);
            expression = new CalculatorParser("100* 13");
            Assert.AreEqual(expression.Parse().Interpret(), 1300.0, 1e2);
            expression = new CalculatorParser("11.5 - 13.7 + 25.6");
            Assert.AreEqual(expression.Parse().Interpret(), 23.4, 1e2);
            expression = new CalculatorParser("5 * 8 :10");
            Assert.AreEqual(expression.Parse().Interpret(), 4.0, 1e2);
        }

        [Test]
        public void OrderTest()
        {
            var expression = new CalculatorParser("5+7*9");
            Assert.AreEqual(expression.Parse().Interpret(), 68.0, 1e2);
            expression = new CalculatorParser("5 -111: 111");
            Assert.AreEqual(expression.Parse().Interpret(), 4.0, 1e2);
            expression = new CalculatorParser("7.5-3.5*3");
            Assert.AreEqual(expression.Parse().Interpret(), -3.0, 1e2);
        }
    }
}