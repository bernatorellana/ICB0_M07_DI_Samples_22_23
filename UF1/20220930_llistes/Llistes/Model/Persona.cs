using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llistes.Model
{
    class Persona : IComparable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String nom;
        private int id;

        public Persona(int id, string nom)
        {
            Nom = nom;
            Id = id;
        }
        //-------------------------------------------------
        #region Properties

        public String Nom
        {
            get { return nom; }
            set {
                if (value == null || value.Trim().Length < 2){ 
                    throw new Exception("El nom ha de ser not null i tenir 2 lletres com a mínim ");
                }
                nom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nom"));
            }
        }

        public int Id
        {
            get { return id; }
            set { 
                if(value <= 0) throw new Exception("Id ha de ser positiu");
                id = value; }
        }


        public int CompareTo(object laltre)
        {
            if( !(laltre is Persona)) return 1;
            Persona p = (Persona) laltre;
            return this.Id - p.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Persona persona &&
                   Id == persona.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Id}: {Nom}";
            //return Id + ":" + Nom;
        }


        #endregion




    }
}
