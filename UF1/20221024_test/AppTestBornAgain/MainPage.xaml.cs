using AppTestBornAgain.Model;
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

namespace AppTestBornAgain
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int indexPreguntaSeleccionada;

        public int IndexPreguntaSeleccionada { 
            get => indexPreguntaSeleccionada;
            set
            {
              
                indexPreguntaSeleccionada = value;
                btnPrev.IsEnabled = indexPreguntaSeleccionada > 0;
                btnNext.IsEnabled = indexPreguntaSeleccionada < Pregunta.getPreguntesTest().Count - 1;
                pregPregunta.LaPregunta = Pregunta.getPreguntesTest()[indexPreguntaSeleccionada];
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IndexPreguntaSeleccionada = 0;
        }


        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            IndexPreguntaSeleccionada++;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            IndexPreguntaSeleccionada--;
        }

        private void btnFinal_Click(object sender, RoutedEventArgs e)
        {
            CalculaPuntuacio();
        }

        private void CalculaPuntuacio()
        {
            double puntuacio = 0;
            foreach (Pregunta p in Pregunta.getPreguntesTest())
            {
                puntuacio += p.getPuntuacio();
            }
            txtPuntuacio.Text = "Has tret un :" + puntuacio;
        }

        private void pregPregunta_PreguntaCanviada(object sender, EventArgs e)
        {
            CalculaPuntuacio();
        }
    }
}
