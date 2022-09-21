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

namespace AppCalculadora
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Creació de botons
            //<Button Grid.Column="0" Grid.Row="0" Content="1"></Button>
            for (int i = 1; i < 10; i++)
            {
                Button b = new Button();
                b.Content = i+"";
                Grid.SetColumn(b, (i-1)%3);
                Grid.SetRow(b, (i-1)/3+1);
                grdTeclat.Children.Add(b);
            }
 
            
        }
    }
}
