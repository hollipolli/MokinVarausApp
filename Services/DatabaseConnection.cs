using MySqlConnector; // Tuodaan MySqlConnector -kirjasto
public class DatabaseConnector
{
    private readonly string server = "localhost";
    private readonly string port = "3306";
    private readonly string uid = "root";
    private readonly string pwd = "root";
    private readonly string database = "OmaDB";
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