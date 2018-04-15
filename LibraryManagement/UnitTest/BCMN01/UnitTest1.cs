using System;
using BCMN01.logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.exception;
using Common.singleton;
using Common.db;
using Common.define;

namespace UnitTest.BCMN01
{
    [TestClass]
    public class UnitTest1
    {
        AdminPasswordLogic logic = new AdminPasswordLogic();

        [TestMethod]
        public void TestMethod1()
        {
            string actual = logic.Apply("");

            Assert.AreEqual(GlobalDefine.ERROR_CODE[7].message, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string actual = logic.Apply("password");

            Assert.AreEqual(GlobalDefine.ERROR_CODE[8].message, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string actual = logic.Apply("admin");

            Assert.AreEqual(GlobalDefine.MESSAGE_ADMIN_MODE_ENABLE, actual);
        }

    }
}
