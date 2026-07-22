public class Program
{
    public static void Main(string[] args)
    {
        string[] lockers = new string[100];
        
        while (true)
        {
            int menuChoice = MainMenu();
            if (menuChoice == 1)
            {
                ViewLockerContent(lockers);
            }
            else if (menuChoice == 2)
            {
                int lockerNumber = SelectLocker();
                FillLocker(lockers, lockerNumber);
            }
            else if (menuChoice == 3)
            {
                EndLocker(lockers);
            }
            else if (menuChoice == 4)
            {
                ViewAllLockers(lockers);
            }
            else
            {
                Console.WriteLine("END OF PROGRAM!");
                break;
            }
            ClearScreen();
        }
    }
    
    private static int MainMenu()
    {
        // Display menu
        Console.WriteLine("Airport Locker Rental Menu");
        Console.WriteLine("=============================");
        Console.WriteLine("1. View a locker");
        Console.WriteLine("2. Rent a locker");
        Console.WriteLine("3. End a locker rental");
        Console.WriteLine("4. List all locker contents");
        Console.WriteLine("5. Quit");
        Console.WriteLine();

        // Obtain menu choice
        Console.Write("Enter your choice (1-5): ");
        int.TryParse(Console.ReadLine(), out int choice);
        while (choice < 1 || choice > 5)
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5. ");
            Console.Write("Enter your choice (1-5): ");
            int.TryParse(Console.ReadLine(), out choice);
        }

        return choice;
    }
    
    private static void ClearScreen()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private static void ViewLockerContent(string[] locker)
    {
        // Capture locker number
        int id = SelectLocker();
        
        // Check locker contents
        if (string.IsNullOrEmpty(locker[id]))
        {
            Console.WriteLine($"Locker {id} is EMPTY.");
        }
        else
        {
            Console.WriteLine($"Locker {id} contents: {locker[id]}");
        }
    }
    
    private static int SelectLocker()
    {
        Console.Write("Enter locker number (1-100): ");
        int.TryParse(Console.ReadLine(), out int id);
        while (id < 1 || id > 100)
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 100. ");
            Console.Write("Enter locker number (1-100): ");
            int.TryParse(Console.ReadLine(), out id);
        }

        return id;
    }

    private static void FillLocker(string[] locker, int id)
    {
        // Check to see if locker is already occupied
        if (string.IsNullOrEmpty(locker[id]) == false)
        {
            Console.WriteLine($"Sorry, but locker {id} has already been rented!");
            return;
        }
        
        // Fill the locker with an item
        Console.Write("Enter the item you want to store in the locker: ");
        string item = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(item))
        {
            Console.Write("Enter the item you want to store in the locker: ");
            item = Console.ReadLine().Trim();
        }
        
        locker[id] = item;
        Console.WriteLine($"Locker {id} has been rented for {item} storage.");
    }
    
    private static void EndLocker(string[] locker)
    {
        int id = SelectLocker();
        if (string.IsNullOrEmpty(locker[id]))
        {
            Console.WriteLine($"Locker {id} is not currently rented.");
        }
        else
        {
            Console.WriteLine($"Locker {id} rental has ended, please take your {locker[id]}.");
            locker[id] = null;
        }
    }

    private static void ViewAllLockers(string[] locker)
    {
        for (int i = 0; i < locker.Length; i++)
        {
            if (string.IsNullOrEmpty(locker[i]) == false)
            {
                Console.WriteLine($"Locker {i + 1}: {locker[i]}");
            }
        }
    }
}
