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

namespace AppNumericUpDown.View
{
    public sealed partial class UINumericUpDown : UserControl
    {

        public event EventHandler OnValueChanged;

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), 
                typeof(UINumericUpDown), new PropertyMetadata(0,ValueChangedStatic));

        private static void ValueChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UINumericUpDown instancia = (UINumericUpDown)d;
            instancia.ValueChanged(d, e);
        }

        private void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            txtNum.Text = e.NewValue.ToString();
            OnValueChanged?.Invoke(this, new EventArgs());
        }

        public UINumericUpDown()
        {
            this.InitializeComponent();
        }

        private void txtNum_BeforeTextChanging(TextBox sender, 
            TextBoxBeforeTextChangingEventArgs args)
        {
            int resultat;
            args.Cancel = args.NewText.Length > 0 && 
                !Int32.TryParse(args.NewText, out resultat);
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum.Text.Length == 0)
            {
                txtNum.Text = "0";
            }
            Value = Int32.Parse(txtNum.Text);
        }
    }
}
