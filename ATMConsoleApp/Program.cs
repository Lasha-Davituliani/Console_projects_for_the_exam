namespace ATMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ATMFunctions.ATMFunctions.LoadUsers();

            Console.WriteLine("Welcome to the Console ATM!");

            while (true)
            {
                Console.WriteLine("\n1. Register\n2. Login\n3. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        ATMFunctions.ATMFunctions.Login();
                        break;
                    case "3":
                        ATMFunctions.ATMFunctions.SaveUsers();
                        Console.WriteLine("Exiting the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Move these functions inside the Program class
        private static void Register()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();       
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter personal number: ");
            string personalNumber = Console.ReadLine();           
            ATMFunctions.ATMFunctions.Register(name, lastName, personalNumber);
        }

        private static void LoadUser()
        {
            ATMFunctions.ATMFunctions.LoadUsers();
        }
        private static void SaveUser()
        {
            ATMFunctions.ATMFunctions.SaveUsers();
        }
        private static void ShowMenu()
        {
            ATMFunctions.ATMFunctions.ShowMenu();
        }
    }
}
