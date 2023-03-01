using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestingUnitari.Model
{
    public class Tarifes
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
        public static decimal getPreu(int edat)
        {
 
            if( edat<3 || edat>120)
            {
                throw new Exception("Edat incorrecta");
            }
            else if (edat>=65)
            {
                return 0.00m;
            } else if(edat < 18)
            {
                return 10.00m;
            } else
            {
                return 20.00m;
            }
        }
    }
}
