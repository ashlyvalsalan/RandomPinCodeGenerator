using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomPinGenerator;

namespace RandomPinCodeGeneratorTestProject
{
    [TestClass]
    public class RandomPinGeneratorTests
    {
        [TestMethod]
        public void TestSizeOfBatchis1000()
        {
            int count = RandomPinGeneratorLibrary.BatchOfPinCodes().Count;
            Assert.AreEqual(count, 1000);
        }

        [TestMethod]
        public void TestSizeOfRandomPinCodes()
        {
            int size = RandomPinGeneratorLibrary.RandomPinGenerator().ToString().ToCharArray().Length;
            Assert.AreEqual(size, 4);
        }

        [TestMethod]
        public void TestValidRandomPin()
        {
            int randomPin = 1572;
            char[] randomPinCharArray = randomPin.ToString().ToCharArray();
            int[] randomPinIntArray = new int[4];
            for (int i = 0; i < 4; i++)
            {
                randomPinIntArray[i] = int.Parse(randomPinCharArray[i].ToString());
            }

            bool isValid = RandomPinGeneratorLibrary.ValidatePinDigits(randomPinIntArray);
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        public void TestSameConsecutiveDigitsRandomPin()
        {
            int randomPin = 1183;
            char[] randomPinCharArray = randomPin.ToString().ToCharArray();
            int[] randomPinIntArray = new int[4];
            for (int i = 0; i < 4; i++)
            {
                randomPinIntArray[i] = int.Parse(randomPinCharArray[i].ToString());
            }

            bool isValid = RandomPinGeneratorLibrary.ValidatePinDigits(randomPinIntArray);
            Assert.AreEqual(false, isValid);
        }

        [TestMethod]
        public void TestIncrementalDigitsRandomPin()
        {
            int randomPin = 1567;
            char[] randomPinCharArray = randomPin.ToString().ToCharArray();
            int[] randomPinIntArray = new int[4];
            for (int i = 0; i < 4; i++)
            {
                randomPinIntArray[i] = int.Parse(randomPinCharArray[i].ToString());
            }

            bool isValid = RandomPinGeneratorLibrary.ValidatePinDigits(randomPinIntArray);
            Assert.AreEqual(false, isValid);
        }
    }
}
