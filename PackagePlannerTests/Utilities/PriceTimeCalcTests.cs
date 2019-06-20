using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackagePlanner.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackagePlanner.Utilities.Tests
{
    [TestClass()]
    public class PriceTimeCalcTests
    {
        [TestMethod()]
        public void calcPriceTest()
        {
            Assert.Equals(PriceTimeCalc.calcPrice(15, 15, 15, 3), 15);
        }
    }
}