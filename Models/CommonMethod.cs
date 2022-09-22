using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
namespace BindCountry_Project.Models
{
    public class CommonMethod
    {
       public static DataTable ExecuteQuery(string Procname , string[,] Param)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                SqlCommand cmd = new SqlCommand(Procname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                for(int i=0;i<Param.Length/2;i++)
                {
                    cmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
                }
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        // overlodded function 
        public static DataTable ExecuteQuery(string Procname)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                SqlCommand cmd = new SqlCommand(Procname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string BindGridview(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("<table border='1' class='table table-active table-hover table-bordered'>");
                sb.Append("<tr>");
                sb.Append("<th>Sr No</th>");
                sb.Append("<th>Name</th>");
                sb.Append("<th>State</th>");
                sb.Append("<th>City</th>");
                sb.Append("<th>Registration Date</th>");
                sb.Append("<th colspan='2'>Action</th>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + dt.Rows[i]["ID"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Name"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Statename"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Cityname"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Regdate"].ToString() + "</td>");
                    sb.Append("<td><button type='button' class='btn btn-success' onclick='EditRecord(" + dt.Rows[0]["ID"].ToString() + ")'>Edit</td>");
                    sb.Append("<td><button type='button' class='btn btn-danger' onclick='Delete(" + dt.Rows[0]["ID"].ToString() + ")'>Delete</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}