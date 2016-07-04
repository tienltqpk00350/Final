using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final.dataConfig
{
    public class core
    {
        public int travebanghidcthuchien = 0;
        public core()
        {
            connet();
        }
        SqlConnection con;
        string stringconnect = @"workstation id=DBQLBANHANG.mssql.somee.com;packet size=4096;user id=tienltqpk00350_SQLLogin_1;pwd=gvkkqrtvue;data source=DBQLBANHANG.mssql.somee.com;persist security info=False;initial catalog=DBQLBANHANG";
        public void connet()
        {
            try
            {
                con = new SqlConnection(stringconnect);
                con.Open();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch
            {
                MessageBox.Show("ket noi khong thanh cong");
            }
        }
        //ham getdata
        public DataTable bang(string sql)
        {
            DataTable khoitao = new DataTable();
            SqlDataAdapter khoitao2 = new SqlDataAdapter(sql, con);
            khoitao2.Fill(khoitao);
            return khoitao;
        }
        //hamthemsosua
        public int themsoasua(string sql)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand khoitaocmd = new SqlCommand();
            khoitaocmd.Connection = con;
            khoitaocmd.CommandType = CommandType.Text;
            khoitaocmd.CommandText = sql;
            travebanghidcthuchien=khoitaocmd.ExecuteNonQuery();
            return travebanghidcthuchien;

        }
        public int hamdelSP(string sql,string so)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand khoitaocmd = new SqlCommand(sql, con);
            khoitaocmd.CommandType = CommandType.StoredProcedure;
            khoitaocmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = so;
            travebanghidcthuchien = khoitaocmd.ExecuteNonQuery();
            return travebanghidcthuchien;
        }
    }
}
