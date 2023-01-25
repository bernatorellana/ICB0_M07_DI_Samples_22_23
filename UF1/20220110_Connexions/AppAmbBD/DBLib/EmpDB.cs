using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;


namespace DBLib
{
    public class EmpDB
    {
        private int emp_no;
        private String cognom;
        private String ofici;
        private int? cap;
        private DateTime? data_alta;
        private decimal? salari;
        private decimal? comissio;
        private int dept_no;

        public EmpDB(int emp_no, string cognom, string ofici, int? cap, DateTime? data_alta, decimal? salari, decimal? comissio, int dept_no)
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

        public EmpDB(EmpDB empleat)
        {
            this.Emp_no = empleat.emp_no;
            this.Cognom = empleat.cognom;
            this.Ofici = empleat.ofici;
            this.Cap = empleat.cap;
            this.Data_alta = empleat.data_alta;
            this.Salari = empleat.salari;
            this.Comissio = empleat.comissio;
            this.Dept_no = empleat.dept_no;
        }

        #region properties
        public int Emp_no { get => emp_no; set => emp_no = value; }
        public string Cognom { get => cognom; set => cognom = value; }
        public string Ofici { get => ofici; set => ofici = value; }
        public int? Cap { get => cap; set => cap = value; }
        public DateTime? Data_alta { get => data_alta; set => data_alta = value; }

        public DateTimeOffset? Data_alta_offset
        {
            get
            {
                if (data_alta != null)
                {
                    return new DateTimeOffset(data_alta.Value);
                }
                else return null;
            }
        }
        public decimal? Salari { get => salari; set => salari = value; }
        public decimal? Comissio { get => comissio; set => comissio = value; }
        public int Dept_no { get => dept_no; set => dept_no = value; }
        public EmpDB Empleat { get; }
        #endregion


        /// <summary>
        /// Deletes the specified emp no.
        /// </summary>
        /// <param name="empNo">The emp no.</param>
        /// <returns></returns>
        public static Boolean delete(int empNo)
        {
            DbTransaction transaccio = null;
            try {
                using (MySQLDbContext context = new MySQLDbContext())
                {
                    using (var connection = context.Database.GetDbConnection())
                    {
                        connection.Open();

                        transaccio = connection.BeginTransaction();
                        using (var comanda = connection.CreateCommand())
                        {
                            
                            comanda.CommandText =
                                "delete from emp where emp_no=@p_emp_no";
                            //-----------------------------------------------
                            //    IMPORTANT !!! posem la comanda dins de la transacció
                            //-----------------------------------------------
                            comanda.Transaction = transaccio; //
                            //-----------------------------------------------
                            DBUtils.afegirParametre(comanda, "p_emp_no", empNo, DbType.Int32);
                            int liniesAfectades = comanda.ExecuteNonQuery();
                            if (liniesAfectades != 1)
                            {
                                transaccio.Rollback();                                
                            }
                            else
                            {
                                transaccio.Commit();
                                return true;
                            }
                        }
                    }
                }
             }catch(Exception ex)
            {
                Console.WriteLine("ERROR" + ex);
            }
            return false;
        }



        public static Boolean pucEsborrar(EmpDB emp)
        {
            using (MySQLDbContext context = new MySQLDbContext())
            {
                using (var connection = context.Database.GetDbConnection())
                {
                    connection.Open();
                    using (var comanda = connection.CreateCommand())
                    {
                        comanda.CommandText = @"select count(1) from emp 
                                                where cap = @p_emp_no ";
                        DBUtils.afegirParametre(comanda, "p_emp_no", emp.emp_no , DbType.Int32);

                        Int64 count = (Int64) comanda.ExecuteScalar();
                        if (count == 0)
                        {
                            comanda.CommandText = @"select count(1) from client where  repr_cod = @p_emp_no ";
                            count = (Int64)comanda.ExecuteScalar();
                        }
                        return count == 0;
                    }
                }
            }
            return false;
        }

        public static ObservableCollection<EmpDB> getEmpleats(
            String filtreCognom,
            DateTime? filterData) 
        {
            ObservableCollection<EmpDB> empleats = new ObservableCollection<EmpDB>();
            using(MySQLDbContext context = new MySQLDbContext())
            {
                using (var connection = context.Database.GetDbConnection())
                {
                    connection.Open();
                    using( var comanda = connection.CreateCommand())
                    {
                        comanda.CommandText = @"select * from emp 
                                                where (@p_nom='' or cognom like @p_nom ) and
                                                      (@p_data is null or data_alta>= @p_data) ";
                        DBUtils.afegirParametre(comanda, "p_nom", "%"+filtreCognom+"%", DbType.String);
                        DBUtils.afegirParametre(comanda, "p_data", filterData, DbType.DateTime);

                        DbDataReader reader = comanda.ExecuteReader();
                        while (reader.Read())
                        {
                            int emp_no = reader.GetInt32(reader.GetOrdinal("emp_no"));
                            String cognom = DBUtils.readDBC<String>(reader, "cognom");
                            string ofici = reader.GetString(reader.GetOrdinal("ofici"));
                            int? cap = DBUtils.readDB<Int32>(reader, "cap");
                            DateTime? dataAlta = DBUtils.readDB<DateTime>(reader, "data_alta");
                            decimal? salari = DBUtils.readDB<decimal>(reader, "salari");
                            decimal? comissio = DBUtils.readDB<decimal>(reader, "comissio");
                            int? dept_no = DBUtils.readDB<int>(reader, "dept_no");

                            EmpDB emp = new EmpDB(emp_no, cognom, ofici, cap, dataAlta,
                                salari, comissio, dept_no.Value);
                            empleats.Add(emp);
                        }
                    }
                }
            }
            return empleats;
        }



        public static Boolean insert(EmpDB emp)
        {
            try
            {
                using (MySQLDbContext context = new MySQLDbContext())
                {
                    using (var connection = context.Database.GetDbConnection())
                    {

                        connection.Open();
                        DbTransaction transaccio = connection.BeginTransaction();

                        using (var comanda = connection.CreateCommand())
                        {
                            comanda.CommandText = @"select last_id from ids where table_name = 'emp' for update";
                            // assignar la comanda a la transacció
                            comanda.Transaction = transaccio;

                            decimal last_id = (decimal)comanda.ExecuteScalar();
                            last_id++;

                            comanda.CommandText =
                    @"insert into emp(emp_no, cognom, ofici, cap, data_alta, salari, comissio, dept_no)
                values(@p_emp_no, @p_cognom, @p_ofici, @p_cap, @p_data_alta, @p_salari, @p_comissio, @p_dept_no)";
                            DBUtils.afegirParametre(comanda, "p_emp_no", last_id, DbType.Decimal);
                            DBUtils.afegirParametre(comanda, "p_cognom", emp.cognom, DbType.String);
                            DBUtils.afegirParametre(comanda, "p_ofici", emp.ofici, DbType.String);
                            DBUtils.afegirParametre(comanda, "p_cap", emp.cap, DbType.Decimal);
                            DBUtils.afegirParametre(comanda, "p_data_alta", emp.data_alta, DbType.DateTime);
                            DBUtils.afegirParametre(comanda, "p_salari", emp.salari, DbType.Decimal);
                            DBUtils.afegirParametre(comanda, "p_comissio", emp.comissio, DbType.Decimal);
                            DBUtils.afegirParametre(comanda, "p_dept_no", emp.dept_no, DbType.Int32);

                            Int32 filesInserides = comanda.ExecuteNonQuery();

                            if (filesInserides == 1)
                            {

                                // actualitzar el comptador de ids
                                comanda.CommandText = @"update ids set last_id= @p_last_id where table_name = 'emp'";
                                DBUtils.afegirParametre(comanda, "p_last_id", last_id, DbType.Decimal);
                                last_id++;
                                int updated = comanda.ExecuteNonQuery();
                                if (updated == 1)
                                {
                                    transaccio.Commit();
                                    return true;
                                }
                            }
                            throw new Exception("Something weird happened");
                        }
                    }
                }
            }catch(Exception ex)
            {

            }
            return false;
        }




    }
}
