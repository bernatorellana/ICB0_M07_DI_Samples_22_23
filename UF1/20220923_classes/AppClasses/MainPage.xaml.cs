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

            LlistaClasse llistaSeriosa = new LlistaClasse();
            llistaSeriosa.addAlumne(new Persona(2, "Maria"));
            llistaSeriosa.addAlumne(new Persona(4, "Pep"));
            llistaSeriosa.addAlumne(new Persona(1, "Paco"));
            llistaSeriosa.addAlumne(new Persona(6, "Cristina"));
            txbSortida.Text += llistaSeriosa.ToString();
            llistaSeriosa.esborrarAlumne(1);
            llistaSeriosa.esborrarAlumne(89);
            txbSortida.Text += llistaSeriosa.ToString();

            lsvClasse.ItemsSource = llistaSeriosa.alumnes;
            cboClasse.ItemsSource = llistaSeriosa.alumnes;
            //------------------------------------
            Dictionary<String, Persona> indexPerNomDePersones
                = new Dictionary<String, Persona>();
            indexPerNomDePersones["Maria"] = new Persona(2, "Maria");

            int idDeLaMaria = indexPerNomDePersones["Maria"].Id;


            foreach(Persona pers in llistaSeriosa.alumnes)
            {
                indexPerNomDePersones[pers.Nom] = pers;
            }
            if (indexPerNomDePersones.ContainsKey("Juanito"))
            {
                Persona juanitoPerson = indexPerNomDePersones["Juanito"];
            }
            txbSortida.Text += "==== Noms dins del diccionari ======";
            foreach (String nom in indexPerNomDePersones.Keys)
            {
                txbSortida.Text += nom + "\n";
            }
            //================================
            String[] paraules = { "Primer", "Caca", "Pedo", "Pis", "Pis", "Segon" };

            Dictionary<String, Int32> frequencies = new Dictionary<String, Int32>();
            foreach(String paraula in paraules)
            {
                int f = 0;
                if(frequencies.ContainsKey(paraula))
                {
                    f = frequencies[paraula];
                }
                f++;
                frequencies[paraula] = f;
            }
        }

        private void cboClasse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lsvClasse.SelectedIndex = cboClasse.SelectedIndex;

                
        }

        private void lsvClasse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsvClasse.SelectedItem != null)
            {
                Persona p = (Persona)lsvClasse.SelectedItem;
                txbId.Text = p.Id + "";
                txbNom.Text = p.Nom;
            }
            
        }
    }
}
