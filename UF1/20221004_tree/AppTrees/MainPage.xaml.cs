using AppTrees.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AppTrees
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Node arrel = new Node("Productes");
                Node n1 = new Node("Gamma blanca", arrel);
                    Node n11 = new Node("Neveres", n1);
                        Node n111 = new Node("Normals", n11);
                        Node n112 = new Node("Combi", n11);                    
                    Node n12 = new Node("Rentadores", n1);
                    Node n13 = new Node("Rentavaixelles", n1);
                Node n2 = new Node("TV", arrel );
                    Node n21 = new Node("Samsung", n2);
                    Node n22 = new Node("LG", n2);
                    Node n23 = new Node("Sony", n2);

            String r = getDescripcio(arrel);
            txbResultat.Text = r;
        }

        /// <summary>
        /// Retorna una cadena amb la descripció del node i els 
        /// seus fills. 
        /// </summary>
        /// <param name="n">El node que cal descriure</param>
        /// <returns></returns>
        private String getDescripcio(Node n, int nivell=0)
        {
            String tabs = "";
            for(int i=0;i<nivell;i++)
            {
                tabs += "\t";
            }
            String desc =tabs + n.Nom +"\n";
            foreach( Node fill in n.Fills)
            {
                desc += getDescripcio(fill, nivell+1);
            }
            return desc;
        }
         
    }
}
