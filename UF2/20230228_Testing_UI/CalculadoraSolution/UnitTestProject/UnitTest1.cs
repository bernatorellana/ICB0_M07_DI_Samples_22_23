using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var app = FlaUI.Core.Application.Launch("notepad.exe");
     
            using (var automation = new UIA3Automation())
            {

            }

        }         
    }
}
