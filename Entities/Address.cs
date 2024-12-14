namespace SchoolAppManager.Entities;

public class Address
{
    public int ZipCode { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string AddressLine { get; private set; }
    public string AddressRegNumber { get; private set; }
    public string Country { get; private set; }

    public Address(int zipCode, string street, string city, string state, string addressLine,
        string addressRegNumber, string country)
    {
        ZipCode = zipCode;
        Street = street;
        City = city;
        State = state;
        AddressLine = addressLine;
        AddressRegNumber = addressRegNumber;
        Country = country;
    }

    public void UpdateInfo()
    {
        bool updated = true;
        while (updated)
        {
            Console.WriteLine("Welcome to MITC information update page..................");
            Console.WriteLine("Select an option from the list below.........");
            Console.WriteLine("'1' to update 'zipcode': \n'2' to update 'street':\n'3' to update 'city':\n'4' to update 'address line':\n'5' to update 'state':\n'6' to update 'country': ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ZipCode = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Street = Console.ReadLine();
                    break;
                case 3:
                    City = Console.ReadLine();
                    break;
                case 4:
                    AddressLine = Console.ReadLine();
                    break;
                case 5:
                    State = Console.ReadLine();
                    break;
                case 6:
                    Country = Console.ReadLine();
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
    
    public static Address ConvertToAddress(string row)
    {
        string[] content = row.Split("\t");
        return new Address(int.Parse(content[0]), content[1], content[2], content[3], content[4], content[5], content[6]);
    }
    
}