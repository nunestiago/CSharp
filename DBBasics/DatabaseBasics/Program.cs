// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

string connectionString = @"Data Source=DESKTOP-080VCN2;
Database=ExampleOne;
User ID=DESKTOP-080VCN2\feed_;
Password=;
Trusted_Connection=Yes;";

SqlConnection connection = new SqlConnection(connectionString);
connection.Open();
Debug.WriteLine("Connected to the server!");
SqlCommand cmd = new SqlCommand();
cmd.Connection = connection;
cmd.CommandType = CommandType.Text;
cmd.CommandText = "select * from dbo.People";
SqlDataReader reader = cmd.ExecuteReader();
if (reader.HasRows)
{
    while (reader.Read())
    {
        Debug.WriteLine(reader.GetString(1) + " - " + reader.GetString(2));
    }
}
connection.Close();