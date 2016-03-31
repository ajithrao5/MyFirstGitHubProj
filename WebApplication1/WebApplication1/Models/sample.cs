using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1.Models
{
    public class sample
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString.ToString();

        public void insertvalues(sample s1)
        {
            using (SqlConnection con1 = new SqlConnection(conn))
            {
                string strsql = "insert into table1 values("+ s1.id +",'" + s1.name + "','" + s1.surname + "')";
                SqlCommand cmd = new SqlCommand(strsql, con1);
                con1.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet display()
        {
            string strsql2 = "select id,firstname,lastname from table1";
            SqlDataAdapter da = new SqlDataAdapter(strsql2, conn);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            return ds1;
        }

    }
}