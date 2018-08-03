using NUnit.Framework;

namespace RaiBlocks.Tests
{
    public class RaiUnitsTests
    {
        [Test]
        public void OperatorPlusTest()
        {
            const int a = 1;
            const int b = 1;
            const int c = a + b;

            var aRai = new RaiUnits.RaiRaw(a.ToString());
            var bRai = new RaiUnits.RaiRaw(b.ToString());

            var cRai = aRai + bRai;

            Assert.AreEqual(cRai, new RaiUnits.RaiRaw(c.ToString()));
        }

        [Test]
        public void OperatorMinusTest()
        {
            const int a = 1;
            const int b = 1;
            const int c = a - b;

            var aRai = new RaiUnits.RaiRaw(a.ToString());
            var bRai = new RaiUnits.RaiRaw(b.ToString());

            var cRai = aRai - bRai;

            Assert.AreEqual(cRai, new RaiUnits.RaiRaw(c.ToString()));
        }
    }
}
