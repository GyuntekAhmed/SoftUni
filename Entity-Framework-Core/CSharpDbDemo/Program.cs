using System.Data.SqlClient;

//string connectionString = "Server=.\\SQLEXPRESS01;User Id=Gyuni;Password=...;Database=SoftUni2";
string connectionString = "Server=.\\SQLEXPRESS01;Integrated Security=true;Database=SoftUni";
using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    string query = "UPDATE Employees SET Salary -= 0.12";

    SqlCommand cmd = new SqlCommand(query, connection);

    var rowAffected = cmd.ExecuteNonQuery();

    Console.WriteLine(rowAffected);
}
