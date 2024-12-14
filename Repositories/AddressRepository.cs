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
    
    public bool CreateAddress(Address address)
    {
        string query =
            @"insert into Addresses (street, city, state, zipCode, addressLine, country, regNumber) 
            values(@Street, @City, @State, @ZipCode, @AddressLine, @Country, @RegNumber)";

        int result = 0;
        using (MySqlCommand command = new MySqlCommand(query, _connection))
        {
            command.Parameters.AddWithValue("@Street", address.Street);
            command.Parameters.AddWithValue("@City", address.City);
            command.Parameters.AddWithValue("@State", address.State);
            command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
            command.Parameters.AddWithValue("@AddressLine", address.AddressLine);
            command.Parameters.AddWithValue("@Country", address.Country);
            command.Parameters.AddWithValue("@RegNumber", address.RegNumber);
            
            command.ExecuteNonQuery();
        }
        
        return result == 1 ? true : false;
    }
}