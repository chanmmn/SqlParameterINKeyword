using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppSqlParaIn
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConn = "data source=.;initial catalog=northwind;integrated security=True";
            //string sqlread = "SELECT * FROM [dbo].[Products] Where CategoryID IN (1,2)";
            //string sqlread = "SELECT * FROM [dbo].[Products] Where CategoryID IN (@para1,@para2)";
            string sqlread = "SELECT * FROM [dbo].[Products] Where CategoryID IN (@para3)";

            SqlConnection conn = new SqlConnection(strConn);
            
            SqlDataReader dr = null; 
            using (conn)
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlread,conn))
                {
                    //cmd.Parameters.Add("@para1", SqlDbType.Int);
                    //cmd.Parameters["@para1"].Value = 1;
                    //cmd.Parameters.Add("@para2", SqlDbType.Int);
                    //cmd.Parameters["@para2"].Value = 2;
                    cmd.Parameters.Add("@para3", SqlDbType.VarChar,20);
                    cmd.Parameters["@para3"].Value = "1,2";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Console.WriteLine(dr[0].ToString());
                    }
                }
            }
        }
    }
}
