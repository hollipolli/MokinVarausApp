using MySqlConnector; // Tuodaan MySqlConnector -kirjasto
public class DatabaseConnector
{
    private readonly string server = "localhost";
    private readonly string port = "3307";
    private readonly string uid = "root";
    private readonly string pwd = "Ruutti";
    private readonly string database = "hovi";
    public DatabaseConnector()
    {
    }
    public MySqlConnection _getConnection()
    {
        string connectionString =
        $"Server={server};Port={port};uid={uid};password={pwd};database={database}";
        MySqlConnection connection = new MySqlConnection(connectionString);
        return connection;
    }
}