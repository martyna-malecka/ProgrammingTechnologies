using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRentalLogic;

namespace VideoRentalTest
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void TestCheckDueDate()
        {
            Logic logic = new Logic();
            DateTime due =DateTime.Today.AddDays(-1);
            TimeSpan span = DateTime.Today.Subtract(due);
            int expected = (int)span.TotalDays;

            Assert.AreEqual(expected, logic.CheckDueDate(due));
        }
    }
}
