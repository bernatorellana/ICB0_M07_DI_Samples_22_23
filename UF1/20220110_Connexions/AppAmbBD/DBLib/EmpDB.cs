using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DBLib
{
    public class EmpDB
    {
        private int emp_no;
        private String cognom;
        private String ofici;
        private int cap;
        private DateTime data_alta;
        private decimal salari;
        private decimal comissio;
        private int dept_no;

        public EmpDB(int emp_no, string cognom, string ofici, int cap, DateTime data_alta, decimal salari, decimal comissio, int dept_no)
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
        #region properties
        public int Emp_no { get => emp_no; set => emp_no = value; }
        public string Cognom { get => cognom; set => cognom = value; }
        public string Ofici { get => ofici; set => ofici = value; }
        public int Cap { get => cap; set => cap = value; }
        public DateTime Data_alta { get => data_alta; set => data_alta = value; }
        public decimal Salari { get => salari; set => salari = value; }
        public decimal Comissio { get => comissio; set => comissio = value; }
        public int Dept_no { get => dept_no; set => dept_no = value; }
        #endregion


        public static List<EmpDB> getEmpleats() 
        {
            List<EmpDB> empleats = new List<EmpDB>();
            using(MySQLDbContext context = new MySQLDbContext())
            {
                using (var connection = context.Database.GetDbConnection())
                {
                    connection.Open();
                    using( var comanda = connection.CreateCommand())
                    {
                        comanda.CommandText = @"select * from emp 
                                                where ofici = 'VENEDOR'";
                        DbDataReader reader  = comanda.ExecuteReader();
                        while (reader.Read())
                        {
                            int emp_no = reader.GetInt32(reader.GetOrdinal("emp_no"));
                            string cognom = reader.GetString(reader.GetOrdinal("cognom"));
                            EmpDB emp = new EmpDB(emp_no, cognom, "", 0, new DateTime(), 0, 0, 0);
                            empleats.Add(emp);
                        }
                    }
                }
            }
            return empleats;
        }

    }
}
