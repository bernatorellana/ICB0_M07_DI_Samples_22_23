using AppClasses.Model;
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

namespace AppClasses
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
            Persona p = new Persona(1, "Paco");
            txbSortida.Text += p.Nom;

            List<Persona> persones = new List<Persona>();
            persones.Add(p);
            persones.Add(p);
            persones.Add(p);
            persones.Add(p);
            persones.Add(p);
            //---------------------------------------
            foreach(Persona actual in persones)
            {
                txbSortida.Text += actual + "\n";
            }
            persones[2].Nom = "Pepe";
            foreach (Persona actual in persones)
            {
                txbSortida.Text += actual + "\n";
            }
            LlistaClasse lc = new LlistaClasse();
            txbSortida.Text +=  "He afegit?"+lc.addAlumne(p) +"\n";
            txbSortida.Text +=  "He afegit?"+lc.addAlumne(p) + "\n";
            txbSortida.Text +=  "He afegit?"+lc.addAlumne(new Persona(1, "Paco")) + "\n";

            LlistaClasse seriosa = new LlistaClasse();
            seriosa.addAlumne(new Persona(2, "Maria"));
            seriosa.addAlumne(new Persona(4, "Pep"));
            seriosa.addAlumne(new Persona(1, "Paco"));
            seriosa.addAlumne(new Persona(6, "Cristina"));
            txbSortida.Text += seriosa.ToString();
            seriosa.esborrarAlumne(1);
            seriosa.esborrarAlumne(89);
            txbSortida.Text += seriosa.ToString();

            lsvClasse.ItemsSource = seriosa.alumnes;
            cboClasse.ItemsSource = seriosa.alumnes;
        }
    }
}
