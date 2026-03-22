namespace OldConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get user input for person details
            string? fullName = GetFullName();
            Console.WriteLine();

            int age = GetAge();
            Console.WriteLine();

            bool isAlive = GetAlive();
            Console.WriteLine();

            string? phoneNumber = GetPhoneNumber();
            Console.WriteLine();

            // Display person details
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Person Details");
            Console.WriteLine($"Name:\t\t{fullName}");
            Console.WriteLine($"Age:\t\t{age}");
            Console.WriteLine($"Alive:\t\t{isAlive}");
            Console.WriteLine($"Phone Number:\t{phoneNumber}");
            Console.WriteLine("---------------------------");
            Console.ReadLine();
        }

        static string GetFullName()
        {
            Console.Write("Enter full name: ");
            string? fullName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullName))
            {
                Console.Write("Invalid - Enter full name: ");
                fullName = Console.ReadLine();
            }
            return fullName.Trim();
        }

        static int GetAge()
        {
            Console.Write("Enter age: ");
            bool isValidAge = int.TryParse(Console.ReadLine(), out int age);   

            while (!isValidAge || age < 0)
            {
                if (age < 0)
                    Console.Write("Enter valid age (no negatives): ");
                else
                    Console.Write("Enter valid age (numbers): ");
                isValidAge = int.TryParse(Console.ReadLine(), out age);
            }
            return age;
        }

        static bool GetAlive()
        {
            Console.Write("Is Alive (y/n): ");
            string? aliveInput = Console.ReadLine();
            aliveInput = aliveInput?.Trim().ToLower();

            while (string.IsNullOrWhiteSpace(aliveInput) || (aliveInput != "y" && aliveInput != "n"))
            {
                Console.Write("Invalid - Is Alive (y/n): ");
                aliveInput = Console.ReadLine();
            }

            if (aliveInput == "y")
                return true;
            else
                return false;
        }

        static string GetPhoneNumber()
        {
            Console.Write("Enter phone number: ");
            string? phoneNumber = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.Write("Invalid - Enter phone number: ");
                phoneNumber = Console.ReadLine();
            }
            return phoneNumber.Trim();
        }
    }
}
