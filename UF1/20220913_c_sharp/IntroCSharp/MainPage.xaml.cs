using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace IntroCSharp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private int total;
        private String nom_global;

        public MainPage()
        {
            this.InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txbSortida.Text = "Hello world !";
            txbSortida.Text += Environment.NewLine + "Segona línia";
            Debug.WriteLine("Això és un missatge de consola");

            int i = 0;
            long l = 1000;
            float cm = 12.34f;
            double cm_precis = 12.34;
            decimal import = 123.45M;

            bool certOFals = true;

            char c = 'c';

            const double PI = 3.14159;

            for (int n = 0; n < 10; n++)
            {

            }

            String nom = "Paco";
            String cognom = "Maroto";
            String nomComplet = nom + " " + cognom;
            nomComplet = $"{nom} {cognom}";
            txbSortida.Text = nomComplet + Environment.NewLine;
            //012345678901
            //Paco Maroto
            int posicioEspai = nomComplet.IndexOf(' ');
            String nomSeparat = nomComplet.Substring(0, posicioEspai);
            txbSortida.Text += nomSeparat + Environment.NewLine;
            txbSortida.Text += getCognomBis(nomComplet) + Environment.NewLine;



            String adreca = "  C/Coromines       34,sdf    sdf sd  f1-2  ";
            adreca = netejaEspais3(adreca);
            txbSortida.Text += adreca + Environment.NewLine;


            //--------------------------------------------
            // Conversions
            //--------------------------------------------
            double numero = 1007770.45;
            String numeroS = numero.ToString("###,###.000", new CultureInfo("en-AU"));
            //numeroS = numero+"";
            mostra(numeroS);

            showRussianWeekDays();
        }

        private void showRussianWeekDays()
        {
            DateTime dt = DateTime.Today;
            while(dt.DayOfWeek!= DayOfWeek.Monday)
            {
              dt = dt.AddDays(1);
            }
            CultureInfo ci_ru = new CultureInfo("ru-RU");
            CultureInfo ca_es = new CultureInfo("ca-ES");
            for (int i = 0; i < 7; i++, dt = dt.AddDays(1))
            {
                mostra(dt.ToString("dddd", ci_ru) +"-"+ dt.ToString("dddd", ca_es));
            }

        }

        private void mostra(string cadena)
        {
            txbSortida.Text += cadena + Environment.NewLine;
        }

        private String netejaEspais3(String cadena)
        {
            return Regex.Replace(cadena, "[\\s]{2,}", " ").Trim();
        }

        private String netejaEspais2(String cadena)
        {
            String[] paraules = cadena.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            String sortida = "";
            String espai = "";
            for (int i = 0; i < paraules.Length; i++)
            {
                sortida += espai + paraules[i];
                espai = " ";
            }
            return sortida;
        }
        
        private String netejaEspais(String cadena)
        {
            String sortida = "";
            bool modeEspai= true;

            foreach(char c in cadena)
            {
                if (c != ' ')
                {
                    sortida += c;
                    modeEspai = false;
                }
                else if(!modeEspai )
                {
                    sortida += c;
                    modeEspai = true;
                }
            }
            return sortida.Trim();
        }

        private String getCognom(String nomComplet)
        {
            return nomComplet.Substring(nomComplet.LastIndexOf(' ') + 1);
        }

        private String getCognomBis(String nomComplet)
        {
            String[] noms = nomComplet.Split(" ");
            return noms.Last();
        }
    }
}
