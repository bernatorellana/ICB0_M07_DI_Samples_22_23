﻿using AppNBALlistes.Model;
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
    public sealed partial class UI_FilaEquip : UserControl
    {
        public UI_FilaEquip()
        {
            this.InitializeComponent();
        }


        
        public Equip Team
        {
            get { return (Equip)GetValue(teamProperty); }
            set { SetValue(teamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for jugador.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty teamProperty =
            DependencyProperty.Register("Team", 
                typeof(Equip), 
                typeof(UI_FilaEquip), // nom de la classe on estem
                new PropertyMetadata(null));


    }
}
