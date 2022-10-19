using AppNBALlistes.Model;
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

namespace AppNBALlistes.View
{
    public sealed partial class UI_PlayersEquip : UserControl
    {
        public UI_PlayersEquip()
        {
            this.InitializeComponent();
        }





        public Equip Team
        {
            get { return (Equip)GetValue(TeamProperty); }
            set { SetValue(TeamProperty, value); }
        }
   

        // Using a DependencyProperty as the backing store for Team.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TeamProperty =
            DependencyProperty.Register("Team", typeof(Equip), typeof(UI_PlayersEquip), new PropertyMetadata(null));



    }
}
