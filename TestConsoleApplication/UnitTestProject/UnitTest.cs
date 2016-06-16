using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestConsoleApplication;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod_RegexMatExp()
        {
            // Arrange
            string testStr1 = "(34+5)-6*3/5-(-4+7)";
            string testStr2 = "3/(3-2)+(-4,5)";
            string testStr3 = "3/(3-2)+(-,4,5)";

            // Act
           bool testStrReg1 = Infrastract.RegexMatExp(testStr1);
           bool testStrReg2 = Infrastract.RegexMatExp(testStr2);
           bool testStrReg3 = Infrastract.RegexMatExp(testStr3);

            // Assert
           Assert.IsTrue(testStrReg1);
           //Assert.IsTrue(testStrReg2);
           //Assert.IsFalse(testStrReg3);
        }

        [TestMethod]
        public void TestMethod_ParenthesesEqual()
        {
            string testStr1 = "(34+5)-6*3/5-(-4+7)";
            string testStr2 = "3/(3-2+(-4,5)";

            bool testStrReg1 = Infrastract.ParenthesesEqual(testStr1);
            bool testStrReg2 = Infrastract.ParenthesesEqual(testStr2);

            Assert.IsTrue(testStrReg1);
            //Assert.IsFalse(testStrReg2);
        }

        [TestMethod]
        public void TestMethod_SigMatExpLocWro()
        {
            string testStr1 = "3/(3-2+(-4,5)";
            string testStr2 = ")34+5(-6*3/5-(-4+7)";
            string testStr3 = "3/+(3-2+(-4,5)";

            bool testStrReg1 = Infrastract.SigMatExpLocWro(testStr1);
            bool testStrReg2 = Infrastract.SigMatExpLocWro(testStr2);
            bool testStrReg3 = Infrastract.SigMatExpLocWro(testStr3);

            Assert.IsTrue(testStrReg1);
            //Assert.IsFalse(testStrReg2);
            //Assert.IsFalse(testStrReg3);
        }

        [TestMethod]
        public void TestMethod_ConverList()
        {
            string testStr1 = "3/(3-2+(-4,5)";
            string testStr2 = "3/+(3-2+(-4,5)";

            var testStrReg1 = Infrastract.ConverList(testStr1);
            var testStrReg3 = Infrastract.ConverList(testStr2);

            Assert.IsInstanceOfType(testStrReg1,typeof(List<string>));
            //Assert.IsNull(testStrReg3);
            
        }

        [TestMethod]
        public void Can_Add_To_MathFormulaExecutor()
        {
            List<string> strList = new List<string>(){"3","+","1","-","2","*","4","/","1"};
            MathFormulaExecutor math = new MathFormulaExecutor(strList);

            float sum = math.Calculate();

            Assert.IsInstanceOfType(sum, typeof(float));
        }
        
    }
}