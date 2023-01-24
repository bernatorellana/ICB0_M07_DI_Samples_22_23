using DBLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AppAmbBD
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<EmpDB> mEmpleats;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmpDB empleat = new EmpDB(123, "Paco", "PROGRAMADOR", null, DateTime.Now, 1234.2M, 12.2M, 10);
            if (EmpDB.insert(empleat))
            {
                int i = 0;
            }

            cerca();

            /*foreach( EmpDB em in empleats)
            {
                txbResultat.Text += em.Emp_no + " " + em.Cognom;
            }*/
        }

        private void btnFiltre_Click(object sender, RoutedEventArgs e)
        {
            cerca();
        }

        private void cerca()
        {
            DateTime? dataFiltre = null;
            try
            {
                dataFiltre = DateTime.ParseExact(
                                txbFiltreData.Text,
                                "dd/MM/yyyy",
                                System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex) { }

            mEmpleats = EmpDB.getEmpleats(txbFiltreNom.Text, dataFiltre);
            grdDades.ItemsSource = mEmpleats;
        }

        private void btnClearFiltre_Click(object sender, RoutedEventArgs e)
        {
            txbFiltreData.Text = "";
            txbFiltreNom.Text = "";
            cerca();

        }

        private void btnEsborrar_Click(object sender, RoutedEventArgs e)
        {
            if (grdDades.SelectedItem != null)
            {

                EmpDB empleat = (EmpDB) grdDades.SelectedItem;

                bool ok =  EmpDB.delete(empleat.Emp_no);
                if (ok)
                {
                    //mEmpleats.Remove(empleat);
                    mEmpleats.RemoveAt(grdDades.SelectedIndex);
                    //cerca();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Error al esborrar el client");
                    var cmd = dialog.ShowAsync();
                }
            }
        }

        private void grdDades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmpDB empleat = (EmpDB)grdDades.SelectedItem;
            btnEsborrar.IsEnabled = false;
            if (empleat != null) {                
                btnEsborrar.IsEnabled = EmpDB.pucEsborrar(empleat);                           
            }
        }
    }
}
