using System.Reflection.Metadata;
using MySql.Data.MySqlClient;
using SchoolAppManager.Entities;
using SchoolAppManager.Repositories;

namespace SchoolAppManager.Manager;

public class StudentManager
{
    private readonly StudentRepository _studentRepository;
    readonly FileManager _fileManager = new FileManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "SchoolAppManager", "Students.csv"));
    public StudentManager(MySqlConnection mySqlConnection)
    {
        _studentRepository = new StudentRepository(mySqlConnection);
        
        Console.WriteLine($"Writing to file at: {_fileManager.FilePath}");

        
    }

    public void AddStudent()
    {
        Console.Write("Enter Your FirstName: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Your LastName: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Your Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Your Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter Your Date of birth(MM/DD/yyyy): ");
        string dateInput = Console.ReadLine();
           
        DateTime dateOfBirth = DateTime.ParseExact(dateInput, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            
        Console.Write("Enter Your Gender: ");
        string gender = Console.ReadLine();

        var student = new Student(firstName, lastName, email, phoneNumber, dateOfBirth, gender);
        student.Age = student.GetAge();

        if (student.GetAge() < 18)
        {
            Console.WriteLine("Your age must be at least 18 years old to proceed to registration!");
            return;
        }
        
        //_studentRepository.CreateStudent(student);
       _fileManager.Write(student.ToString());
    }

    public void FindStudentByRegNumber()
    {
        Console.WriteLine("Enter student's registration number: ");
        string regNumber = Console.ReadLine();

        _studentRepository.FindStudentByRegNumber(regNumber);
    }

    public void GetAllStudents()
    {
        _studentRepository.GetAllStudents();
    }
}