using System.Data.SqlClient;

//string connectionString = "Server=.\\SQLEXPRESS01;User Id=Gyuni;Password=...;Database=SoftUni";
string connectionString = "Server=.\\SQLEXPRESS01;Integrated Security=true;Database=SoftUni";
using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    string query = "SELECT * FROM Employees";

    SqlCommand cmd = new SqlCommand(query, connection);

    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        while(reader.Read())
        {
           Console.WriteLine(reader[1]);
        }
    }
}
