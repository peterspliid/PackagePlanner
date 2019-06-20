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
            Assert.AreEqual(PriceTimeCalc.calcPrice(15.0, 15.0, 15.0, 3.0), 15);
            Assert.AreEqual(PriceTimeCalc.calcPrice(30.0, 35.0, 32.0, 0.5), 15);
            Assert.AreEqual(PriceTimeCalc.calcPrice(7.0, 50.0, 1.0, 15.0), 90);
        }
    }
}