using System.Text;
using System.Data.SqlClient;
using VillainNames;

public class StartUp
{
    static void Main()
    {
        using SqlConnection sqlConnection = new SqlConnection(Config.connectionString);

        sqlConnection.Open();

        string result = GetVillianNamesWithMinionsCount(sqlConnection);
        Console.WriteLine(result);
        sqlConnection.Close();
    }

    private static string GetVillianNamesWithMinionsCount(SqlConnection sqlConnection)
    {
        StringBuilder output = new StringBuilder();

        string query = @"SELECT[v].[Name],
                        COUNT([mv].[MinionId]) AS[MinionsCount]
                        FROM[Villains]
                        AS[v]
                        LEFT JOIN[MinionsVillains]
	                    AS [mv]
                        ON[v].[Id] = [mv].[VillainId]
                        GROUP BY[v].[Name],
		                [v].[Id]
                        HAVING COUNT([mv].[MinionId]) > 3
                        ORDER BY COUNT([mv].[MinionId])";
        SqlCommand command = new SqlCommand(query, sqlConnection);

        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            output.AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
        }

        return output.ToString().TrimEnd();
    }
}