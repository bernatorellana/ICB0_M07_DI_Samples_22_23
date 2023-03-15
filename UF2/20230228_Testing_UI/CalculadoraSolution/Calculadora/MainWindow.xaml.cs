using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Click event of the btnCalcula control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCalcula_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = ""+(int.Parse(txtOp1.Text) + int.Parse(txtOp2.Text));
        }

        /// <summary>
        /// Sumas the specified a.
        /// 
        ///         | asfd       | asdasd |   |       |   |
        ///         |------------|--------|---|-------|---|
        ///         | asd        | asd    |   | a     |   |
        ///         |            |        |   | asdf  |   |
        /// 
        /// 
        /// # Dillinger
        ///    ## _The Last Markdown Editor, Ever_
        ///    ### Subsubtitol
        ///    * primer
        ///    * segon
        ///    * tercer
        ///
        ///    1. Primer
        ///    2. segon 
        ///    3. tercer
        ///    4. 
        ///    Hola** negreta**, _cursiva_,
        ///
        ///    | primer|segon|tercer| i un cucharon|
        ///    |-------|-------|-------|-------|
        ///    |soc una taula| una altra cel·la| quin mal| ????|
        ///
        /// 
        /// ```c
        /// 
        /// int i=0;
        /// ``` 
        /// 
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public int suma(int a,int b)
        {
            return a + b;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int c = CalculadoraLib.Calculadora.suma(2, 2);
        }
    }
}
