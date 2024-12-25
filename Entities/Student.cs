namespace SchoolAppManager.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public int Age { get; set; }
    public string Gender { get; private set; }
    public string RegNumber { get; private set; }
    public DateTime DateOfRegistration { get; private set; }

    public string FullName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }
    
    public int GetAge()
    {
        int age =  DateTime.UtcNow.Year - DateOfBirth.Year;
        if (DateTime.UtcNow < DateOfBirth.AddYears(age))
        {
            age--;
        }

        return age;
    }

    public Student(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, string gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Age = GetAge();
        Gender = gender;
        RegNumber = GenerateRegNumber();
        DateOfRegistration = DateTime.Now;
    }

    private Student(string firstName, string lastName, string email, string phoneNumber, string regNumber,
        DateTime dateOfBirth, string gender, DateTime dateOfRegistration)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Age = GetAge();
        Gender = gender;
        RegNumber = regNumber;
        DateOfRegistration = dateOfRegistration;

    }

    private string GenerateRegNumber()
    {
        return Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "").ToUpper().Trim();
    }

    public string GetRegistrationNumber()
    {
        return RegNumber;
    }
    
    public override string ToString()
    {
        return $"{FullName(firstName: FirstName, lastName: LastName)}\t{Email}\t{PhoneNumber}\t{Age}\t{Gender}\t{DateOfRegistration:dd/MM/yyyy}";
    }

    public void UpdateInfo()
    {
        bool updated = true;

        while (updated)
        {
            Console.WriteLine("Welcome to MITC information update page..................");
            Console.WriteLine("Select an option from the list below.........");
            Console.WriteLine("'1' to update 'firstname': \n'2' to update 'lastname':\n'3' to update 'email':\n'4' to update 'phone-number':\n'5' to update 'age':\n'6' to update 'gender':\n'7' to update 'gender': ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter your first name: ");
                    FirstName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter your last name: ");
                    LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Enter your email: ");
                    Email = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Enter your phone number: ");
                    PhoneNumber = Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Enter your date Of birth (MM/DD/yyyy): ");
                    DateOfBirth = DateTime.Parse(Console.ReadLine());
                    break;
                case 6:
                    Console.WriteLine("Enter your gender (e.g. male): ");
                    Gender = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option!");
                    break;
                    
            }
        }
        Console.WriteLine("Do you want to proceed to update? (y/n): ");
        string choice = Console.ReadLine();

        if (choice.ToLower() == "n".ToLower())
        {
            updated = false;
        }

    }

    public static Student ConvertToStudent(string line)
    {
        string[] content = line.Split("\t");
        return new Student(content[0], content[1], content[2], content[3], content[4], DateTime.Parse(content[5]),  (content[6]), DateTime.Parse(content[7]));

    }
}