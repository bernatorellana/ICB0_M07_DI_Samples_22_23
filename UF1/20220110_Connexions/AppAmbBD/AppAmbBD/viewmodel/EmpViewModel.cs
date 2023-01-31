using DBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace AppAmbBD.viewmodel
{
    public class EmpViewModel:INotifyPropertyChanged
    {

        private int emp_no;
        private String cognom;
        private String ofici;
        private int? cap;
        private DateTime? data_alta;
        private DateTimeOffset? data_alta_offset;
        private decimal? salari;
        private decimal? comissio;
        private int dept_no;

        public event PropertyChangedEventHandler PropertyChanged;

        public EmpViewModel(int emp_no, string cognom, string ofici, int? cap, DateTime? data_alta, decimal? salari, decimal? comissio, int dept_no)
        {
            this.Emp_no = emp_no;
            this.Cognom = cognom;
            this.Ofici = ofici;
            this.Cap = cap;
            this.Data_alta = data_alta;
            this.Salari = salari;
            this.Comissio = comissio;
            this.Dept_no = dept_no;
        }

        public EmpViewModel(EmpDB empleat)
        {
            this.Emp_no = empleat.Emp_no;
            this.Cognom = empleat.Cognom;
            this.Ofici = empleat.Ofici;
            this.Cap = empleat.Cap;
            this.Data_alta = empleat.Data_alta;
            this.Salari = empleat.Salari;
            this.Comissio = empleat.Comissio;
            this.Dept_no = empleat.Dept_no;
        }


        public Brush CognomBackground { get; set; }
 
        public String CognomError { get; set; }

        #region properties
        public int Emp_no { get => emp_no; set => emp_no = value; }
        public string Cognom { get => cognom; 
            set { 
                cognom = value; 
                // validació cognom
                if(cognom.Trim().Length<2)
                {
                    CognomBackground = new SolidColorBrush(Colors.Red);
                    CognomError = "El nom ha de tenir 2 caràcters com a mínim";
                } else
                {
                    CognomBackground = new SolidColorBrush(Colors.Transparent);
                    CognomError = "";
                }
            } 
        }
        public string Ofici { get => ofici; set => ofici = value; }
        public int? Cap { get => cap; set => cap = value; }

        public DateTime? Data_alta
        {
            get => data_alta;
            set
            {
                data_alta = value;
                if (data_alta != null)
                {
                    data_alta_offset = new DateTimeOffset(data_alta.Value);
                }
            }
        }

        public DateTimeOffset? Data_alta_offset
        {
            get => data_alta_offset;
            set
            {
                data_alta_offset = value;
                data_alta = data_alta_offset.Value.DateTime;
            }
        }

        public decimal? Salari { get => salari; set => salari = value; }
        public decimal? Comissio { get => comissio; set => comissio = value; }
        public int Dept_no { get => dept_no; set => dept_no = value; }
        public EmpDB Empleat { get; }

        internal EmpDB toEmpDB()
        {
            return new EmpDB(
                this.emp_no, 
                this.cognom,
                this.ofici,
                this.cap, 
                this.data_alta,
                this.salari, 
                this.comissio,
                this.dept_no);
        }
        #endregion

    }
}
