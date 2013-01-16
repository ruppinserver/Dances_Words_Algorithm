using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
    SqlConnection connection;
    SqlCommand cmd;
    
    public DAL()
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename='D:\\sql\\Songs.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True";
        connection = new SqlConnection(connectionString);
        cmd = new SqlCommand();
    }// Constructor

    public DataTable retrieveTableData(string sqlQuery)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlQuery;
        cmd.Connection = connection;

        adapter.SelectCommand = cmd;
        DataTable table = new DataTable();

        cmd.Connection.Open();
        adapter.Fill(table);
        cmd.Connection.Close();

        return table;
    }// Retrieve Table Data

    public void runStoreProcedureWithVariables(string sprName, string sqlParameters, out int ans)
    {
        cmd = new SqlCommand(sprName, this.connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = sprName;

        string[] parameters = sqlParameters.Split(',');
        for (int i = 0; i < parameters.Length; i++)
        {
            cmd.Parameters.Add(new SqlParameter(parameters[i], parameters[i + 1]));
            i++;
        }// for

        cmd.Parameters.Add("@ans", SqlDbType.Int);
        cmd.Parameters["@ans"].Direction = ParameterDirection.Output;
        connection.Open();
        cmd.ExecuteNonQuery();
        ans = Convert.ToInt32(cmd.Parameters["@ans"].Value);
        connection.Close();
    }// Run Stored Procedure With Variables

    public void SqlCommands(string query)
    {
        SqlCommand sqlQuery = new SqlCommand(query.ToString(), connection);
        connection.Open();
        SqlDataReader reader = sqlQuery.ExecuteReader();
        connection.Close();
    }// SQL Commands
}// Class