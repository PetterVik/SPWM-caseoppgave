using Xunit;
using SPWM.Assignment;

namespace SPWM.Assignment.Tests
{
    public class TWRCalculatorTests
    {
        [Fact]
        public void Calculator_Returns_0_When_Null_Input()
        {

            decimal twr = TWRCalculator.CalculateTWR(null);
            

            Assert.Equal(0m, twr);
        }

        [Fact]
        public void Calculator_Returns_0_When_Empty_Input()
        {

            decimal twr = TWRCalculator.CalculateTWR([]);

            Assert.Equal(0m, twr);
        }

        [Fact]
        public void Calculator_Returns_Input_When_One_Element()
        {
            decimal twr = TWRCalculator.CalculateTWR(new decimal[] { 0.05m });
            Assert.Equal(0.05m, twr);
        }

        [Fact]
        public void Calculator_Returns_Correct_Value_When_Valid_Input()
        {
            decimal twr = TWRCalculator.CalculateTWR(new decimal[] { 0.01m, -0.02m, 0.03m });
            Assert.Equal(0.019494m, twr);
        }
    }
}
