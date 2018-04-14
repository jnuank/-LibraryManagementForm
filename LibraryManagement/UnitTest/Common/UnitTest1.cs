using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.ErrorCheck;
using Common.exception;
using System.Windows.Forms;

namespace UnitTest.Common
{
    [TestClass]
    public class UnitTest1
    {
        TextBox txtBox = new TextBox();


        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void TestMethod1()
        {
            txtBox.Text = "'";
            InputCheck.IsSingleQuotation(txtBox);
        }

        [TestMethod]
        public void TestMethod3()
        {
            txtBox.Text = "'";
            Assert.IsTrue(txtBox.CheckSingleQuotation());
        }

        [TestMethod]
        public void TestMethod4()
        {
            txtBox.Text = " ";
            Assert.IsFalse(txtBox.CheckSingleQuotation());
        }

    }
}
