using MySql.Data.MySqlClient;

namespace SchoolAppManager.Repositories;

public class StudentRepository
{
    private readonly MySqlConnection _connection;

    public StudentRepository(MySqlConnection connection)
    {
        _connection = connection;
    }
}