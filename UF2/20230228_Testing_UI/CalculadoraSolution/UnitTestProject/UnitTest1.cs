using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
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

            string ruta = System.AppDomain.CurrentDomain.BaseDirectory;

            var app = FlaUI.Core.Application.Launch(
                    ruta + @"\..\..\..\Calculadora\bin\Debug\Calculadora.exe");

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                var txtOp1 = window.FindFirstDescendant(cf => cf.ByAutomationId("txtOp1")).AsTextBox();
                var txtOp2 = window.FindFirstDescendant(cf => cf.ByAutomationId("txtOp2")).AsTextBox();
                var txtResult = window.FindFirstDescendant(cf => cf.ByAutomationId("txtResult")).AsTextBox();
                txtOp1.Text = "2";
                txtOp2.Text = "3";

                var btnCalcula = window.FindFirstDescendant(cf => cf.ByAutomationId("btnCalcula")).AsButton();
                btnCalcula.Click();
                Assert.AreEqual("5", txtResult.Text);

            }
                /*var app = FlaUI.Core.Application.Launch("Chrome.exe");
                using (var automation = new UIA3Automation())
                {
                    var window = app.GetMainWindow(automation);
                    var adreca = window.FindFirstDescendant(
                        cf => cf.ByText("Barra d'adreces i de cerca"))?.
                        AsTextBox();
                    Keyboard.Type("www.uoc.edu");
                    Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
                    //adreca.Text = "www.uoc.edu";
                }*/

            }         
    }
}
