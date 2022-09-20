using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EKZ02;

namespace EKZ_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EKZ02.Class2 prog = new EKZ02.Class2();
            prog.minus(9, 10, 3);
           
        }
    }
}
