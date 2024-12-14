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
            @"insert into Addresses (street, city, state, zipCode, addressLine, country, addressRegNumber) 
            values(@Street, @City, @State, @ZipCode, @AddressLine, @Country, @AddressRegNumber)";

        int result = 0;
        try
        {
            _connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Street", address.Street);
                command.Parameters.AddWithValue("@City", address.City);
                command.Parameters.AddWithValue("@State", address.State);
                command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                command.Parameters.AddWithValue("@AddressLine", address.AddressLine);
                command.Parameters.AddWithValue("@Country", address.Country);
                command.Parameters.AddWithValue("@RegNumber", address.AddressRegNumber);

                result = command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Database error: {ex.Message}");
            throw new ApplicationException("An error occured while trying to create address", ex);
        }



    }

    public bool UpdateAddress(Address address)
    {
        string query =
            @"update Addresses SET zipCode = @ZipCode, street = @Street, city = @City, addressLine = @AddressLine, country = @Country where addressRegNumber = @AddressRegNumber";

        int result = 0;

        try
        {
            using (_connection)
            {
                _connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                    command.Parameters.AddWithValue("@Street", address.Street);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@AddressLine", address.AddressLine);
                    command.Parameters.AddWithValue("@Country", address.Country);
                    command.Parameters.AddWithValue("@RegNumber", address.AddressRegNumber);

                    result = command.ExecuteNonQuery();
                    return result > 0 ? true : false;
                }
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Database Error: {ex.Message}");
            throw new ApplicationException($"An error occured while trying to update address info for Reg No: {address.AddressRegNumber}", ex);
        }

    }

    public void FindAddressByRegNumber(string addressRegNumber)
    {
        string query = "select * from Addresses where addressRegNumber = @AddressRegNumber";

        try
        {
            _connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                MySqlDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    Console.WriteLine($"Address {count}\n\tAddress Line: {reader["addressLine"]}\n\tZip Code: {reader["zipCode"]}\n\tAddress Registration Number: {reader["addressRegNumber"]}\n\tCity: {reader["city"]}\n\tState: {reader["state"]}\n\tCountry: {reader["country"]}");
                    count++;
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Database Error: {ex.Message}");
            throw new ApplicationException($"An error occured while trying to find address with Reg No: {addressRegNumber}");
        }
    }
}