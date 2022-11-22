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

namespace AppUIGrafics.View
{
    public sealed partial class UIVelocimetre : UserControl
    {
        public UIVelocimetre()
        {
            this.InitializeComponent();
        }
        


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cnvDiana.Children.Clear();
            double mida = Math.Min(ActualWidth, ActualHeight);
            double[] diametres = { 100.0, 80.0, 70.0, 40.0, 30.0, 10.0, 5.0 };
            Color[] colors = { Colors.Black, Colors.Green, Colors.White, Colors.Green, Colors.White, Colors.Green, Colors.Red };
            for (int i = 0; i < diametres.Length; i++)
            {
                Ellipse el = new Ellipse();
                el.Fill = new SolidColorBrush(colors[i]);                
                el.Width = mida * diametres[i] / 100.0;
                el.Height = el.Width;
                double marge = (mida - el.Width) * 0.5;
                Canvas.SetTop(el, marge);
                Canvas.SetLeft(el, marge);
                cnvDiana.Children.Add(el);
            }
            double angleOffset = 0;// +Math.PI*0.5;
            int[] numeros = { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19,
                7, 16, 8, 11, 14, 9, 12, 5 };
            for (int i = 0; i < 20; i++)
            {
                Polygon p = new Polygon();
                p.Tag = numeros[i];
                p.Tapped += P_Tapped;
                
                if(i % 2 == 0) 
                p.Fill = new SolidColorBrush(Color.FromArgb(80, 0, 0, 0));
                else
                p.Fill = new SolidColorBrush(Color.FromArgb(0, 0,0,0));
                    
                p.Points.Add(new Point(mida * 0.5, mida * 0.5));
                double angle = Math.PI / 20;
                double x = mida * 0.5 * (1 + Math.Cos(angle));
                double y = mida * 0.5 + ((mida * 0.5) * Math.Sin(-angle));
                p.Points.Add(new Point(x, y));
                y = mida * 0.5 * (1 + Math.Sin(+angle));
                p.Points.Add(new Point(x, y));
                cnvDiana.Children.Add(p);
                RotateTransform rt = new RotateTransform();
                rt.Angle = angleOffset;
                angleOffset += 360 / 20;
                rt.CenterX = mida / 2;
                rt.CenterY = mida / 2;
                p.RenderTransform = rt;
            }

            angleOffset = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                TextBlock t = new TextBlock();
                t.TextAlignment = TextAlignment.Center;
                t.FontWeight = Windows.UI.Text.FontWeights.Bold;
                t.FontSize = mida / 20;
                t.Text = numeros[i]+"";
                t.Foreground = new SolidColorBrush(Colors.White);
                t.Width = mida / 10;
                t.Height = mida / 10;
                Canvas.SetLeft(t, mida / 2 - t.Width / 2);
                Canvas.SetTop(t, 0);
                cnvDiana.Children.Add(t);
                // Rotació
                RotateTransform rt = new RotateTransform();
                rt.Angle = angleOffset;
                rt.CenterX = t.Width / 2;
                rt.CenterY = mida / 2;
                angleOffset += 360 / 20;
                t.RenderTransform = rt;
            }


            /*             

            <Polygon Fill="#99000000" 
            Points="50,50, 99.38,42.2, 99.38, 57.8" ></Polygon>
            <Polygon Fill="#99000000" Points="50,50, 99.38,42.2, 99.38, 57.8" >
                <Polygon.RenderTransform>
                    <RotateTransform Angle="36" CenterX="50" CenterY="50"></RotateTransform>
                </Polygon.RenderTransform>
            </Polygon>
            <Polygon Fill="#99000000"  Points="50,50, 99.38,42.2, 99.38, 57.8" >
                <Polygon.RenderTransform>
                    <RotateTransform Angle="72" CenterX="50" CenterY="50"></RotateTransform>
                </Polygon.RenderTransform>
            </Polygon>

            <TextBlock TextAlignment="Center" FontWeight="Bold" FontSize="7" Foreground="White" Width="20" Height="10" Canvas.Left="40" Canvas.Top="0">20</TextBlock>
            <TextBlock TextAlignment="Center" FontWeight="Bold" FontSize="7" Foreground="White" Width="20" Height="10" Canvas.Left="40" Canvas.Top="0">
                1

                <TextBlock.RenderTransform>
                    <TransformGroup>
                        <RotateTransform Angle="18" CenterX="10" CenterY="50"/>
                    </TransformGroup>
                </TextBlock.RenderTransform>

            </TextBlock>
            <TextBlock TextAlignment="Center" FontWeight="Bold" FontSize="7" Foreground="White" Width="20" Height="10" Canvas.Left="40" Canvas.Top="0">
                18

                <TextBlock.RenderTransform>
                    <TransformGroup>
                        <RotateTransform Angle="36" CenterX="10" CenterY="50"/>
                    </TransformGroup>
                </TextBlock.RenderTransform>

            </TextBlock>

             */
        }

        private void P_Tapped(object sender, TappedRoutedEventArgs e)
        {
           int num =(int) ((Polygon)sender).Tag;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }

        private void cnvDiana_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //e.GetPosition().
        }
    }
}
