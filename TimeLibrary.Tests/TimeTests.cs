using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TimeLibrary.Tests
{
    [TestClass]
    public class TimeTests
    {
        private Time systemUnderTest;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingTimeObjectWithMoreMinutesThanInTheDay()
        {
            systemUnderTest = new Time(1500);
            
            Assert.ThrowsException<ArgumentException>(() => systemUnderTest);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingTimeObjectWithNegativeArgument()
        {
            systemUnderTest = new Time(-1);

            Assert.ThrowsException<ArgumentException>(() => systemUnderTest);
        }

        [TestMethod]
        public void CreatingTimeObjectWithDateTimeArgument()
        {
            systemUnderTest = new Time(DateTime.Parse("7:00 PM"));

            Assert.AreEqual(1140, systemUnderTest.TimeInMins);
        }

        [TestMethod]
        public void CreatingTimeObjectWithValidIntArgument()
        {
            systemUnderTest = new Time(700);

            Assert.AreEqual(700, systemUnderTest.TimeInMins);
        }

        [TestMethod]
        public void TimeInMinsProperty()
        {
            systemUnderTest = new Time(160);

            Assert.AreEqual(160, systemUnderTest.TimeInMins);
        }

        [TestMethod]
        public void HoursProperty()
        {
            systemUnderTest = new Time(160);

            Assert.AreEqual(2, systemUnderTest.Hours);
        }

        [TestMethod]
        public void MinutesProperty()
        {
            systemUnderTest = new Time(160);

            Assert.AreEqual(40, systemUnderTest.Minutes);
        }

        [TestMethod]
        public void NoonProperty()
        {
            Assert.AreEqual(720, systemUnderTest.Noon);
        }

        [TestMethod]
        public void ExplisitCastTimeToInt()
        {
            systemUnderTest = new Time(160);

            Assert.AreEqual(160, (int)systemUnderTest);
        }

        [TestMethod]
        public void ImplicitCastIntToTime()
        {
            systemUnderTest = 160;

            Assert.AreEqual(160, systemUnderTest.TimeInMins);
        }

        [TestMethod]
        public void OperatorPlusResulWithMoreMinutesThanInTheDay()
        {
            systemUnderTest = new Time(1380);
            Time time = new Time(120);            

            Assert.AreEqual(60, (systemUnderTest + time).TimeInMins);
        }

        [TestMethod]
        public void OperatorPlusResultWithLessMinutesThanInTheDay()
        {
            systemUnderTest = new Time(160);
            Time time = new Time(100);

            Assert.AreEqual(260, (systemUnderTest + time).TimeInMins);
        }

        [TestMethod]
        public void OperatorMinusWithBiggerSubtrahend()
        {
            systemUnderTest = new Time(160);
            Time time = new Time(220);

            Assert.AreEqual(1380, (systemUnderTest - time).TimeInMins);
        }

        [TestMethod]
        public void OperatorMinusWithSmallerSubtrahend()
        {
            systemUnderTest = new Time(160);
            Time time = new Time(60);

            Assert.AreEqual(100, (systemUnderTest - time).TimeInMins);
        }

        [TestMethod]
        public void ToStringTest1()
        {
            systemUnderTest = new Time(160);
            Assert.AreEqual("02:40", systemUnderTest.ToString());
        }

        [TestMethod]
        public void ToStringTest2()
        {
            systemUnderTest = new Time(601);
            Assert.AreEqual("10:01", systemUnderTest.ToString());
        }

        [TestMethod]
        public void ToStringTest3()
        {
            systemUnderTest = new Time(7);
            Assert.AreEqual("00:07", systemUnderTest.ToString());
        }

        [TestMethod]
        public void ToStringTest4()
        {
            systemUnderTest = new Time(620);
            Assert.AreEqual("10:20", systemUnderTest.ToString());
        }
    }
}
