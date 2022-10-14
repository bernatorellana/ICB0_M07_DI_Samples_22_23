using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrees.model
{
    public class Node
    {
        private String nom;
        private Node pare;
        private List<Node> fills;

        public ReadOnlyCollection<Node> Fills
        {
            get
            {
                return new ReadOnlyCollection<Node>(fills);
            }
        }





        public Node(String pNom)
        {
            Nom = pNom;
            pare = null;
            fills = new List<Node>();
        }

        public Node(String pNom, Node pPare)
        {
            Nom = pNom;
            pare = pPare;
            pare.fills.Add(this);
            fills = new List<Node>();
        }

        public Node Pare { get => pare;  }
        public string Nom { get => nom; set => nom = value; }
    }
}
