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
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace AppGrafica.View
{
    public sealed partial class UIBarra : UserControl
    {
        /// <summary>
        /// Número màxim de rectangles dins de la barra.
        /// </summary>
        private const int N = 10;

        public UIBarra()
        {
            this.InitializeComponent();
            inicialitza();
        }

        #region Propietats
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UIBarra), new PropertyMetadata(0, ValueChangedCallbackStatic));

        private static void ValueChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIBarra b = (UIBarra)d;
            b.ValueChangedCallback();
        }
        #endregion

        private void ValueChangedCallback()
        {
            // Això es crida cada vegada que canvia "Value"
            int rectanglesIluminats = N * Value / 10;
            for(int i = 0; i < grdColumna.Children.Count; i++)
            {
                grdColumna.Children[i].Opacity = i > (N - rectanglesIluminats-1) ? 1 : 0.25;
            }

        }

        /// <summary>
        /// Inicialitza els rectangles dins del control, incialment
        /// es fan tots transparents.
        /// </summary>
        void inicialitza()
        {
            for (int i = 0; i < N; i++)
            {
                // Creem la definició de la fila
                grdColumna.RowDefinitions.Add(new RowDefinition());
                //<Rectangle Grid.Row="1" Fill="red"></Rectangle>
                // Creem un rectangle tal i com es mostra al
                // template d'adalt.
                Rectangle r = new Rectangle();
                r.Fill = new SolidColorBrush(Colors.RosyBrown);
                Grid.SetRow(r, i);
                r.Opacity = 0; // Aquí es fa invisibles (totalment transparents)
                grdColumna.Children.Add(r);
            }
        }
    }
}
