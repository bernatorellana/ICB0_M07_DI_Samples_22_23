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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace AppTestBornAgain.View
{
    public sealed partial class UIPregunta : UserControl
    {
        public UIPregunta()
        {
            this.InitializeComponent();
        }






        public Pregunta LaPregunta
        {
            get { return (Pregunta)GetValue(LaPreguntaProperty); }
            set { SetValue(LaPreguntaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LaPregunta.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LaPreguntaProperty =
            DependencyProperty.Register("LaPregunta", typeof(Pregunta), typeof(UIPregunta), 
                new PropertyMetadata(null,new PropertyChangedCallback(LaPreguntaChangedStatic)));

        private static void LaPreguntaChangedStatic(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            UIPregunta p = (UIPregunta)d;
            p.LaPreguntaChanged(e);
        }

        private void LaPreguntaChanged(DependencyPropertyChangedEventArgs e)
        {
            // Netegem l'stackpanel
            stpRespostes.Children.Clear();
            foreach( Resposta r in LaPregunta.Respostes)
            {
                //<RadioButton Content="Aquesta és una resposta"></RadioButton>
                RadioButton rb = new RadioButton();
                rb.Content = r.Text;
                rb.IsChecked = r.Seleccionada;
                rb.Checked += Rb_Checked;
                rb.Unchecked += Rb_Unchecked;
     
                stpRespostes.Children.Add(rb);
            }
            
        }

        private void Rb_Unchecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Rb_Checked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

     
    }
}
