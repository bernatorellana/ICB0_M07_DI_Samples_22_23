using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;

namespace DBLib
{
    public class DeptDB
    {
       private int dept_no;
       private String dnom;
       private String loc;

        public DeptDB(int dept_no, string dnom, string loc)
        {
            Dept_no = dept_no;
            Dnom = dnom;
            Loc = loc;
        }

        public int Dept_no { get => dept_no; set => dept_no = value; }
        public string Dnom { get => dnom; set => dnom = value; }
        public string Loc { get => loc; set => loc = value; }

        //------------------------------------------------------------------------------

        public static ObservableCollection<DeptDB> getDepartaments()
        {
            ObservableCollection<DeptDB> departaments = new ObservableCollection<DeptDB>();
            using (MySQLDbContext context = new MySQLDbContext())
            {
                using (var connection = context.Database.GetDbConnection())
                {
                    connection.Open();
                    using (var comanda = connection.CreateCommand())
                    {
                        comanda.CommandText = @"select * from dept";
                        
                        DbDataReader reader = comanda.ExecuteReader();
                        while (reader.Read())
                        {
                            int dept_no = reader.GetInt32(reader.GetOrdinal("dept_no"));
                            String dnom = reader.GetString(reader.GetOrdinal("dnom"));
                            String loc = DBUtils.readDBC<String>(reader, "loc");
                            DeptDB nouDept = new DeptDB(dept_no, dnom, loc);
                            departaments.Add(nouDept);
                        }
                    }
                }
            }
            return departaments;
        }

    }
}
