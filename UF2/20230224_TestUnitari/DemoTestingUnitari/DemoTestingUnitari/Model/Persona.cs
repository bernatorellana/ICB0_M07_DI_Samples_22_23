using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestingUnitari.Model
{
    public class Persona
    {

        public Persona(string nif, string nom)
        {
            this.Nif = nif;
            this.Nom = nom;
        }
        //--------------------------------------------------------
        private String nif;

        public String Nif
        {
            get { return nif; }
            set {
                if (!CheckDNI(value)) throw new Exception("NIF erroni");
                nif = value; 
            }
        }

        private String nom;


        public String Nom
        {
            get { return nom; }
            set { 
                if(value==null || value.Trim().Length < 2)
                {
                    throw new Exception("Nom incorrecte");
                }
                nom = value; }
        }


        static bool CheckDNI(string dni)
        {

            if (dni == null) return false;

            //Comprobamos si el DNI tiene 9 digitos
            if (dni.Length != 9)
            {
                //No es un DNI Valido
                return false;
            }

            //Extraemos los números y la letra
            string dniNumbers = dni.Substring(0, dni.Length - 1);
            string dniLeter = dni.Substring(dni.Length - 1, 1);
            //Intentamos convertir los números del DNI a integer
            var numbersValid = int.TryParse(dniNumbers, out int dniInteger);
            if (!numbersValid)
            {
                //No se pudo convertir los números a formato númerico
                return false;
            }
            if (CalculateDNILeter(dniInteger) != dniLeter)
            {
                //La letra del DNI es incorrecta
                return false;
            }
            //DNI Valido 🙂
            return true;
        }


        static string CalculateDNILeter(int dniNumbers)
        {
            //Cargamos los digitos de control
            string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            var mod = dniNumbers % 23;
            return control[mod];
        }

    }
}
