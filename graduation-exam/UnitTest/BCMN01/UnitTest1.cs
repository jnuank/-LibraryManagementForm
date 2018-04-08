using System;
using BCMN01.dialog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.exception;
using Common.singleton;
using Common.db;

namespace UnitTest.BCMN01
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BCMN0102 form = new BCMN0102();
            Assert.IsTrue(form.CheckTextBox(""));
        }

        [TestMethod]
        public void TestMethod2()
        {
            DbQuery dc = SingletonObject.GetDbQuery();
            bool result = dc.IsAdminPassword("admin");

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestMethod3()
        {
            BCMN0102 form = new BCMN0102();
            Assert.IsTrue(form.CheckTextBox(null));
        }

        [TestMethod]
        public void TestMethod4()
        {
            BCMN0102 form = new BCMN0102();
            Assert.IsFalse(form.CheckTextBox("admin"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            DbQuery dc = SingletonObject.GetDbQuery();
            bool result = dc.IsAdminPassword("password");

            Assert.IsFalse(result);

        }

    }
}
