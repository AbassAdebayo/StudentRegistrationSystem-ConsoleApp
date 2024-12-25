// See https://aka.ms/new-console-template for more information

using System.Text;
using MySql.Data.MySqlClient;
using SchoolAppManager.Manager;

delegate void PrintMenuDelegate();

class Program
{
    private static StudentManager _studentManager;
    static void Main(string[] args)
    {
        string connectionString  = "server=localhost;user=root;database=student_app;password=DefinedCodes";
        MySqlConnection connection = new MySqlConnection(connectionString);
         _studentManager = new StudentManager(connection);
        Run();
    }
    static void Run()
    {
        bool flag;
        PrintMenuDelegate printMenu = new(PrintMenu);
        do
        {
            printMenu(); 
            var option = HandleSelections(Console.ReadLine(), printMenu);
            flag = HandleMenuOption(option);
        } while (flag);
        Console.WriteLine("Thank you for using our app....");
    }
    
    static void PrintMenu()
    {
        Console.WriteLine("Welcome to MITC page..................");
        Console.WriteLine("Select an option from the list below.........");
        Console.WriteLine("'1' To Register: \n'2' To update Record:\n'3' To Get All Students:\n'4' To Delete Student's Record:\n'5' To find Student:\n'0' To End");
    }
    
    static bool HandleMenuOption(int option)
    {
        switch (option)
        {
            case 1:
                _studentManager.AddStudent();
                return true;
            // case 2:
            //     _studentManager.Update();
            //     return true;
            case 3:
               _studentManager.GetAllStudents();
                return true;
            // case 4:
            //     studentManager.Delete();
            //     return true;
            case 5:
              _studentManager.FindStudentByRegNumber();
                return true;
            case 0:
                return false;
            default:
                return false;
        }
    }
     
    static int HandleSelections(string selection, PrintMenuDelegate printMenu)
    {
        bool result = int.TryParse(selection, out int action);
        while (result == false)
        {
            Console.WriteLine("Try again!");
            printMenu();
            result = int.TryParse(Console.ReadLine(), out action);
        }
        return action;
    }
}


