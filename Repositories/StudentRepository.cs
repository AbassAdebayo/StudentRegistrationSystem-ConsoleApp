using MySql.Data.MySqlClient;
using SchoolAppManager.Entities;

namespace SchoolAppManager.Repositories;

public class StudentRepository
{
    private readonly MySqlConnection _connection;

    public StudentRepository(MySqlConnection connection)
    {
        _connection = connection;
    }

    public bool CreateStudent(Student student)
    {
        string query =
            @"insert into Students (firstname, lastname, email, phoneNumber, regNumber, dateOfBirth, gender, dateOfRegistration) 
           values (@FirstName, @LastName, @Email, @PhoneNumber, @RegNumber, @DateOfBirth, @Gender, @DateOfRegistration)";
        
        int result = 0;

        try
        {
            _connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                command.Parameters.AddWithValue("@RegNumber", student.RegNumber);
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@DateOfRegistration", student.DateOfRegistration.ToString("yyyy-MM-dd HH:MM:ss"));
            
                result = command.ExecuteNonQuery();
            
                return result == 1 ? true : false;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Database Error: {ex.Message}");
            throw new ApplicationException("An error occured while trying to create student");
        }
        
    }
    
    public void GetAllStudents()
    {
        string query = "select * from students";
        
        _connection.Open();
        using (MySqlCommand command = new MySqlCommand(query, _connection))
        {
            MySqlDataReader reader = command.ExecuteReader();
            int count = 1;
            while (reader.Read())
            {
                Console.WriteLine($"Student {count}\n\tFirst Name: {reader["firstName"]}\n\tLast Name: {reader["lastName"]}\n\tReg Number: {reader["regNumber"]}\n\tEmail: {reader["email"]}");
                count++;
            }
        }
    }
    
}