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
        private int pageCount;


        public MainPage()
        {
            this.InitializeComponent();
        }

        

        public EmpDB EmpleatSeleccionat
        {
            get { return (EmpDB)GetValue(EmpleatSeleccionatProperty); }
            set { SetValue(EmpleatSeleccionatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmpleatSeleccionat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmpleatSeleccionatProperty =
            DependencyProperty.Register("EmpleatSeleccionat", typeof(EmpDB), typeof(MainPage), new PropertyMetadata(null));


        private long rowCount;

        public long RowCount
        {
            get { return rowCount; }
            set { 
                rowCount = value;
                pageCount = (int) Math.Ceiling((decimal)rowCount / DBUtils.ROWS_PER_PAGE);
            }
        }


        public int Page
        {
            get { return (int)GetValue(PageProperty); }
            set { 
                SetValue(PageProperty, value);
                cerca();
            }
        }

        // Using a DependencyProperty as the backing store for Page.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageProperty =
            DependencyProperty.Register("Page", typeof(int), typeof(MainPage), new PropertyMetadata(0));




        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            RowCount = EmpDB.count();

            EmpleatSeleccionat = new EmpDB(0, "", "", null, null, null, null, -1);

            cerca();

            ObservableCollection<EmpDB> totsElsEmpleats = EmpDB.getEmpleats("", null);
            totsElsEmpleats.Insert(0, new EmpDB(-1, "", "", null, null, null, null, 0));
            cboCap.ItemsSource = totsElsEmpleats;
            cboCap.DisplayMemberPath = "Cognom";
            cboCap.SelectedValuePath = "Emp_no";
            //--------------------------------------------------------

            cboDepartament.ItemsSource = DeptDB.getDepartaments();
            cboDepartament.DisplayMemberPath = "Dnom";
            cboDepartament.SelectedValuePath = "Dept_no";

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

            mEmpleats = EmpDB.getEmpleats(txbFiltreNom.Text, dataFiltre, Page);
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
                    RowCount--;
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

                EmpleatSeleccionat =  new EmpDB(empleat);
            }
            //--------------------------------
           
        }

        

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            EmpleatSeleccionat = new EmpDB(0, "", "", null, null, null, null, -1);
            grdDades.SelectedIndex = -1;
        }

        private void btnDesar_Click(object sender, RoutedEventArgs e)
        {
            if(grdDades.SelectedIndex == -1)
            {
                //new EmpDB(0, txbCognom.Text, "", null, null, null, null, -1);
                bool insercioCorrecta = EmpDB.insert(EmpleatSeleccionat);
                if (insercioCorrecta)
                {
                    RowCount++;
                    cerca();
                }

            } else // tenim un element seleccionat i per tant fem update
             {
                bool udpateCorrecte = EmpDB.update(EmpleatSeleccionat);
                if (udpateCorrecte)
                {
                    cerca();
                }
            }
        }

        private void btnAfegir_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            incPagina(+1);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            incPagina(-1);
        }
        private void incPagina(int inc)
        {
            int p = Page +  inc;
            if(p<0)
            {
                p = pageCount - 1;
            } else if(p==pageCount)
            {
                p = 0;
            }
            Page = p;
                    
        }
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Page = pageCount - 1;
   
        }
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Page = 0;
        }
    }
}
