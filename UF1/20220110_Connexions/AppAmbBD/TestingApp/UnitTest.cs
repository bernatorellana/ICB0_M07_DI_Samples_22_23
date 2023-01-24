
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBLib;

namespace TestingApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProvarInsercio()
        {
            EmpDB empleat = new EmpDB(123, "Paco", "PROGRAMADOR", null, DateTime.Now, 1234.2M, 12.2M, 10);
        }
    }
}
