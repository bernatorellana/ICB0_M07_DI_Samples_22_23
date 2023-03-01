
using System;
using DemoTestingUnitari.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TarifaTest
    {

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "si tens -1 anys, no pots anar al cine")]
        public void getPreu_casos_erronis_Test()
        {
            // -1
            Tarifes.getPreu(-1);                    
        }

        [TestMethod]
        public void getPreu_casos_erronis_2_Test()
        {
            // -1
            //  2
            // 121
            testejarPreuErroni(2);
            testejarPreuErroni(121);
        }

        private static void testejarPreuErroni(int edat)
        {
            bool hePetat = false;
            try
            {
                Tarifes.getPreu(edat);
            }
            catch (Exception ex)
            {
                hePetat = true;
            }
            if (!hePetat) Assert.Fail("No es verifica l'edat errónia amb valor "+edat);
        }

        [TestMethod]
        public void getPreuTest()
        {

            /// <summary>
            /// Calcula el preu de l'entrada.
            ///  - jubilats: gratuït
            ///  - menors: 10€
            ///  - public general: 20€
            /// </summary>
            /// <param name="edat">L'edat. Ha d'estar entre 3 i 120 (inclosos) anys.
            /// Altrament llança excepció.</param>
            /// <returns>el preu de l'entrada</returns>

            int[] edats = {  3, 15, 17, 18, 45, 64, 65, 80, 120 };
            int[] preus = { 10, 10, 10, 20, 20, 20,  0,  0,   0 };

            for(int i=0;i<edats.Length;i++)
            {
                Assert.AreEqual(preus[i], Tarifes.getPreu(edats[i]), 
                    $"cas amb edat = {edats[i]} erroni ");
            }
            /*
            //  3
            int i = 0;
            Assert.AreEqual(10, Tarifes.getPreu(3), $"cas {i++}");
            // 15
            Assert.AreEqual(10, Tarifes.getPreu(15), $"cas {i++}");
            // 17
            Assert.AreEqual(10, Tarifes.getPreu(17), $"cas {i++}");
            // 18
            Assert.AreEqual(20, Tarifes.getPreu(18), $"cas {i++}");
            // 45
            Assert.AreEqual(20, Tarifes.getPreu(45), $"cas {i++}");
            // 64
            Assert.AreEqual(20, Tarifes.getPreu(64), $"cas {i++}");
            // 65
            Assert.AreEqual(0, Tarifes.getPreu(65), $"cas {i++}");
            // 80
            Assert.AreEqual(0, Tarifes.getPreu(80), $"cas {i++}");
            //120
            Assert.AreEqual(0, Tarifes.getPreu(120), $"cas {i++}");
            */

        }
    }
}
