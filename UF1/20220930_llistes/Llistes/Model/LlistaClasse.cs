using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llistes.Model
{
    class LlistaClasse
    {
        public List<Persona> alumnes = new List<Persona>();

        public bool esborrarAlumne(int id){
            int index = alumnes.BinarySearch(
                new Persona(id, "DUMMY_XXXX"));
            if(index>=0)
            {
                alumnes.RemoveAt(index);
                return true;
            }
            return false;
            /*
            for(int i=0;i<alumnes.Count;i++){
                if (alumnes[i].Id == id)
                {
                    alumnes.RemoveAt(i);
                    return true;
                }
            }
            return false;
            //-------------------------------------
            alumnes.Remove(new Persona(id, "DUMMY"));
            */
        }

        public Persona get(int index)
        {
            return alumnes[index];
        }

        /// <summary>
        /// Afegir un alumne a la llista. No admet repeticions
        /// </summary>
        /// <param name="nou">El nou alumne</param>
        /// <returns>true si s'ha pogut afegir l'element</returns>
        public bool addAlumne(Persona nou)
        {
            if (nou == null) { return false; }
            /*foreach(Persona p in alumnes)
            {
                if (nou.Id == p.Id) return false;
            }*/
            int indexInsercio = alumnes.BinarySearch(nou);
            if (indexInsercio >= 0) return false;
            alumnes.Insert(~indexInsercio, nou);

            /*if (alumnes.Contains(nou)) return false;
            alumnes.Add(nou);*/
            return true;
            
        }

        public override string ToString()
        {
            String ret = "";
            foreach(Persona p in alumnes)
            {
                ret+="("+ p +"),";
            }
            return "==========================\n"+ret + "\n";
        }
    }
}
