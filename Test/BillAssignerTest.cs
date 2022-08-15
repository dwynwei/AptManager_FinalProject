using BusinessLayer.Helper;
using BusinessLayer.Helper.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    /*
     * Success Test For BillAssigner
     */
    public class BillAssignerTest
    {
        private readonly IOutcomeCalculator _calculator;

        public BillAssignerTest(IOutcomeCalculator calculator)
        {
            _calculator = calculator;
        }

        [Fact]
        public void OutComeCalculator_Success()
        {
            decimal price = 100;
            int counter = 4;

            var response = _calculator.BillCalculator(price,counter);

            Assert.Equal(response, (decimal)25);
        }

    }
}
