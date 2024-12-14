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
            @"insert into student (firstname, lastname, email, phoneNumber, regNumber, dateOfBirth, gender, dateOfRegistration) 
           values (@FirstName, @LastName, @Email, @PhoneNumber, @RegNumber, @DateOfBirth, @Gender, @DateOfRegistration)";
        
        int result = 0;
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
    
}