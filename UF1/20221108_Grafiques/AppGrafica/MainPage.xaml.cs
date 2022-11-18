using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

namespace AppGrafica
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BindingList<Valor> llistaValors = new BindingList<Valor>();
        private DispatcherTimer td;

        public MainPage()
        {
            this.InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                llistaValors.Add(new Valor(0));
            }

            td = new DispatcherTimer();
            td.Interval = new TimeSpan(1000000);
            td.Tick += T_Tick;
            td.Start();
            
        }

        double t = 0;
        private void T_Tick(object sender, object e)
        {
            //Debug.Print(".");
            double x = 0;
            double MAX = 100;
            foreach(Valor v in llistaValors)
            {
                double k = ( x / 100.0- t / 20.0) * 2.0 * Math.PI ;
                v.V = MAX*0.5*( 0.8*Math.Sin(k)+1);
                x++;
            }
            t++;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            uig.Values = llistaValors;
            lsvValors.ItemsSource = llistaValors;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (td.IsEnabled) {
                btnPause.Content = "Resume";
                td.Stop(); 
            } else {
                btnPause.Content = "Pause";
                td.Start(); 
            }
            
        }
    }
}
