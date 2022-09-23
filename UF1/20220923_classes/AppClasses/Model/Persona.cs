using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClasses.Model
{
    class Persona
    {
        private int id;
        private String nom;

        private int identificador;

        public int Identificador
        {
            get { return identificador; }
            set {
                if (value < 100) throw new Exception("PUGGGGGGG");
                identificador = value; }
        }


        private static void prova()
        {
            Persona p = new Persona();
            p.Identificador = 12;
            int i = p.Identificador;
        }
    }
}
