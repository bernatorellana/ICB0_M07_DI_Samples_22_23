using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppGrafica.View
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class UIGrafica : UserControl
    {
        public UIGrafica()
        {
            this.InitializeComponent();
        }



        public BindingList<Valor> Values
        {
            get { return (BindingList<Valor>)GetValue(ValuesProperty); }
            set { SetValue(ValuesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Values.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValuesProperty =
            DependencyProperty.Register("Values", typeof(BindingList<Valor>), typeof(UIGrafica), new PropertyMetadata(new BindingList<int>(), ValuesChangedCallbackStatic));

        private static void ValuesChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIGrafica ui = (UIGrafica)d; 
            ui.ValuesChangedCallback();
        }

        private void ValuesChangedCallback()
        {
            Values.ListChanged += Values_ListChanged; ;
            //Values.CollectionChanged += UIGrafica_CollectionChanged;

            pinta();
        }

        private void Values_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType==ListChangedType.ItemChanged)
            {
                // update
                UIBarra barra = (UIBarra)grdColumes.Children[e.NewIndex];
                barra.Value = (int)Values[e.NewIndex].V;
            }
            else
            pinta();
        }

        private void pinta()
        {
            grdColumes.Children.Clear();
            grdColumes.ColumnDefinitions.Clear();
            int c = 0;
            foreach (Valor v in Values)
            {
                grdColumes.ColumnDefinitions.Add(new ColumnDefinition());
                UIBarra uib = new UIBarra();
                uib.Value = (int)v.V;
                grdColumes.Children.Add(uib);
                Grid.SetColumn(uib, c++);
            }
        }

        private void UIGrafica_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           
            pinta();
        }
    }
}
