using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGrafica
{
    
    public class Valor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double vv;

        public double V
        {
            get { return vv; }
            set { 
                vv = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("V"));
            }

        }
        override public String ToString()
        {
            return "" + vv;
        }
        public Valor(double v)
        {
            this.V = v;
        }

    }
}
