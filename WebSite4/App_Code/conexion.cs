using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de conexion
/// </summary>
public class conexion
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataReader dtr = null;
    public SqlDataAdapter dap = null;
    public conexion()
    {
        string cadena_con = "Data Source=LAPTOP-N6IQG5II\\MSSQLSERVER01;Initial Catalog=examenfinal; Integrated Security=True";
        con = new SqlConnection(cadena_con);
        cmd = new SqlCommand();

        cmd.CommandText = "";
    }
    public void command(String command, Boolean sw)
    {
        cmd.Connection = con;
        cmd.CommandText = command;
        cmd.ExecuteNonQuery();
    }
    public void openCon()
    {
        con.Open();
        cmd.CommandType = CommandType.Text;
    }
    public void closeCon()
    {
        con.Close();
    }
    public void readerQuery()
    {
        dtr = cmd.ExecuteReader();
    }
    public void intoAdapter(string command)
    {
        dap = new SqlDataAdapter();
        dap.SelectCommand = new SqlCommand();
        dap.SelectCommand.Connection = con;
        dap.SelectCommand.CommandText = command;
    }
}