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
 
        decimal acumulador=0;
        char? operacioPendent=null;
        bool pendentEsborrar = false;

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
                Grid.SetRow(b, 3-(i-1)/3);
                
                // associem l'esdeveniment Click al nou botó
                b.Click += Numero_Click;

                grdTeclat.Children.Add(b);
            }
 
            
        }

        private void Numero_Click(object sender, RoutedEventArgs e)
        {            
            Button elNumeroQueHanClicat = (Button)sender;
            if (pendentEsborrar)
            {                
                txbPantalla.Text = "";
                pendentEsborrar = false;
            }

            if (txbPantalla.Text.Equals("0"))
            {
                txbPantalla.Text = elNumeroQueHanClicat.Content + "";
            }
            else
            {
                txbPantalla.Text += elNumeroQueHanClicat.Content + "";
            }
            

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txbPantalla.Text = "0";
        }

        private void Operacio_Click(object sender, RoutedEventArgs e)
        {
            Button operacioQueHanClicat = (Button)sender;
            char operacioChar = operacioQueHanClicat.Tag.ToString()[0];
            if (operacioPendent != null)
            {
                decimal valorPantalla = decimal.Parse(txbPantalla.Text);
                //fer operació pendent i guardar-la a l'acumulador
                switch (operacioPendent)
                {
                    case '+': { acumulador += valorPantalla; break; } 
                    case '-': { acumulador -= valorPantalla; break; } 
                    case '/': { acumulador /= valorPantalla; break; } 
                    case '*': { acumulador *= valorPantalla; break; }
                    default: throw new Exception("Operació desconeguda");
                }
                if (operacioChar == '=')
                {
                    txbPantalla.Text = acumulador + "";
                    operacioPendent = null;
                }  
            }
            if (operacioChar != '=')
            {
                if (operacioPendent == null) {
                    this.acumulador = decimal.Parse(txbPantalla.Text);
                }
                operacioPendent = operacioChar;
                pendentEsborrar = true;
            }
        }
    }
}
