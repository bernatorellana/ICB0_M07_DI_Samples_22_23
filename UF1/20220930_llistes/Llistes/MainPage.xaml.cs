using Llistes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Llistes
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<Persona> classe = new ObservableCollection<Persona>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            classe.Add(new Persona(1, "Paco"));
            classe.Add(new Persona(2, "Maria"));
            classe.Add(new Persona(3, "Pepe"));

            lsvPersones.ItemsSource = classe;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idMax = 0;
            foreach(Persona p in classe)
            {
                if (p.Id > idMax) idMax = p.Id;
            }
            
            classe.Add(new Persona(idMax+1, txbNou.Text));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lsvPersones.SelectedIndex != -1)
            {
                classe.RemoveAt(lsvPersones.SelectedIndex);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {            
            Persona p = (Persona)lsvPersones.SelectedItem;
            p.Nom = txbNou.Text;
        }

        private void lsvPersones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsvPersones.SelectedItem != null)
            {
                Persona p = (Persona)lsvPersones.SelectedItem;
                txbNou.Text = p.Nom;
            }
        }
    }
}
