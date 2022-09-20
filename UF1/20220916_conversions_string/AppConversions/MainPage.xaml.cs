using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AppConversions
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


        private void validaNumero( TextBox entrada, TextBlock sortida)
        {
            int numero = 0;
            bool haConvertit = int.TryParse(entrada.Text, out numero);
            Color backgr = Color.FromArgb(255, 255, 255, 255);
            if (haConvertit)
            {
                sortida.Text = numero + "";
            }
            else
            {
                backgr = Color.FromArgb(255,255,100,100);
                sortida.Text = "Usuari , no siguis lluç, les unitats són un número.";
            }
            entrada.Background = new SolidColorBrush(backgr);

            /*try
            {
                int numero = int.Parse(txbUnitats.Text);
                txtUnitats.Text = numero + "";
            }
            catch(Exception ex)
            {
                txtUnitats.Text = "Usuari , no siguis lluç, les unitats són un número.";
            }*/
        }

        private void ButtonUnitats2_Click(object sender, RoutedEventArgs e)
        {
            validaNumero(txbUnitats2, txtUnitats2);
        }
        private void ButtonUnitats_Click(object sender, RoutedEventArgs e)
        {
            validaNumero(txbUnitats, txtUnitats);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal numero = 0;
            bool haConvertit = decimal.TryParse(txbPreu.Text, out numero);
            if (haConvertit)
            {
                txtPreu.Text = numero + "";
            }
            else
            {
                txtPreu.Text = "Usuari , no siguis lluç, les unitats són un número.";
            }
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            DateTime data;
            bool conversioOk = DateTime.TryParseExact(
                txbData.Text, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out data);
            if (conversioOk)
            {
                txtData.Text = data.ToString("dddd, dd \\de MMMM \\de yyyy");
            } else
            {
                txtData.Text = "Data incorrecta";
            }

        }
    }
}
