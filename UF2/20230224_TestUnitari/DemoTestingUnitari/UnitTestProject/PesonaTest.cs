using DemoTestingUnitari.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class PesonaTest
    {
        [TestMethod]
        public void construtorTest()
        {
            Persona p = new Persona("11111111H", "Paco Paquito");
            Assert.AreEqual("11111111H", p.Nif);
            Assert.AreEqual("Paco Paquito", p.Nom);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "constructor:nom null")]
        public void constructor_erroni_nom_Test()
        {
            new Persona("12345678Z", null);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "constructor:nom null")]
        public void constructor_erroni_nom2_Test()
        {
            new Persona("12345678Z", "J");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "constructor:nom null")]
        public void constructor_erroni_nom3_Test()
        {
            new Persona("12345678Z", "        J       ");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "constructor:nom null")]
        public void constructor_erroni_nom1_Test()
        {
            new Persona("12345678Z", "");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"constructor:nom null")]
        public void constructor_erroni_NIF_Test()
        {
            new Persona(null, "Paco paquito");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "constructor:nom null")]
        public void constructor_erroni_NIF2_Test()
        {
            new Persona("11111111G", "Paco paquito");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "constructor:nom null")]
        public void constructor_erroni_NIF3_Test()
        {
            new Persona("11111111", "Paco paquito");
        }

    }
}
