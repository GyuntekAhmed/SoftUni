namespace MiniORM;

/// <summary>
/// Used for wrapping a database connection with a using statement and
/// automatically closing it when the using statement ends
/// </summary>
internal class ConnectionManager : global::System.IDisposable
{
    private readonly global::MiniORM.DatabaseConnection connection;

    public ConnectionManager(global::MiniORM.DatabaseConnection connection)
    {
        this.connection = connection;

        this.connection.Open();
    }

    public void Dispose()
    {
        this.connection.Close();
    }
}