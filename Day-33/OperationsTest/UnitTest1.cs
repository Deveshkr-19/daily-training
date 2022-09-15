using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace OperationsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFactMethodValid()
        {
            Operations obj = new Operations();
            int num = 7;
            double expectedFact = 5040;
            double actualFact = obj.fact(num);

            Assert.AreEqual(expectedFact, actualFact);
        }
        [TestMethod]
        public void TestFactLessThanZero()
        {
            Operations obj = new Operations();
            int num = -2;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => obj.fact(num));
        }
        [TestMethod]
        public void TestPrimeMethodValid()
        {
            Operations obj = new Operations();
            int num = 7;

            bool expected = true;
            bool actual = obj.isPrime(num);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPrimeLessThanZero()
        {
            Operations obj = new Operations();
            int num = -7;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => obj.isPrime(num));
        }
    }
}
