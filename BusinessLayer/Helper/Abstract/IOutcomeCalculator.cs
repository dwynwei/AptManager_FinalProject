using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helper.Abstract
{
    public interface IOutcomeCalculator
    {
        public decimal BillCalculator(decimal price, int cnt);
        public void BillAssigner(decimal price);
    }
}
