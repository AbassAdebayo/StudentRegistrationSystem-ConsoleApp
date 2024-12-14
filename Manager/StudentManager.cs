using MySql.Data.MySqlClient;
using SchoolAppManager.Entities;
using SchoolAppManager.Repositories;

namespace SchoolAppManager.Manager;

public class StudentManager
{
    private readonly StudentRepository _studentRepository;

    public StudentManager(MySqlConnection mySqlConnection)
    {
        _studentRepository = new StudentRepository(mySqlConnection);
    }

    public void AddStudent()
    {
        Console.WriteLine("Enter Your FirstName: ");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter Your LastName: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter Your Email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter Your Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Enter Your Date of birth(MM/DD/yyyy): ");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Your Gender: ");
        string gender = Console.ReadLine();

        var student = new Student(firstName, lastName, email, phoneNumber, dateOfBirth, gender);

        if (student.GetAge() < 18)
        {
            Console.WriteLine("Your age must be at least 18 years old to proceed to registration.");
        }

        _studentRepository.CreateStudent(student);
    }

    public void FindStudentByRegNumber()
    {
        Console.WriteLine("Enter student's registration number: ");
        string regNumber = Console.ReadLine();

        _studentRepository.FindStudentByRegNumber(regNumber);
    }
    
    
}