using MySql.Data.MySqlClient;
using SchoolAppManager.Entities;

namespace SchoolAppManager.Repositories;

public class AddressRepository
{
    private readonly MySqlConnection _connection;

    public AddressRepository(MySqlConnection connection)
    {
        _connection = connection;
    }
}