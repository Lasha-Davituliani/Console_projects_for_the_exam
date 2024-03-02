using Newtonsoft.Json;
using System.Threading.Channels;

namespace ATMFunctions
{
    public class ATMFunctions
    {
        private static List<User> users = new List<User>();
        private static string usersFilePath = "users.json";
        private static string logFilePath = "log.json";
        private static User currentUser;

        public static void LoadUsers()
        {
            users = FileOperations.FileOperations.LoadFromFile<User>(usersFilePath);
        }

        public static void SaveUsers()
        {
            FileOperations.FileOperations.SaveToFile(users, usersFilePath);
        }


        public static void Log(string message)
        {
            File.AppendAllText(logFilePath, JsonConvert.SerializeObject(message) + Environment.NewLine);
        }

        public static void Register(string name, string lastName, string personalNumber)
        {
            if (!IsValidPersonalNumber(personalNumber))
            {
                Console.WriteLine("Error: Personal number must be exactly 11 digits long and contain only numbers.");
                return;
            }
            if (users.Exists(u => u.PersonalNumber == personalNumber))
            {
                Console.WriteLine("Error: Personal number already registered. Please login or choose a different personal number.");
                return;
            }

            string password = GenerateRandomPassword();

            User newUser = new User
            {
                Id = users.Count + 1,
                Name = name,
                LastName = lastName,
                PersonalNumber = personalNumber,
                Password = password,
                Balance = 0
            };

            users.Add(newUser);
            SaveUsers();

            Console.WriteLine($"Registration successful! Your password is: {password}");
            Console.WriteLine("Please remember your password and use it to login.");
        }
        public static bool IsValidPersonalNumber(string personalNumber)
        {
           return personalNumber.Length == 11 && personalNumber.All(char.IsDigit);
        }
        

        public static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public static void Login()
        {
            Console.Write("Enter personal number: ");
            string personalNumber = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.PersonalNumber == personalNumber && user.Password == password)
                {
                    currentUser = user;
                    Console.WriteLine($"Welcome, {currentUser.Name}!");
                    ShowMenu();
                    return;
                }
            }

            Console.WriteLine("Invalid personal number or password.");
        }

        public static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Check Balance\n2. Deposit\n3. Withdraw\n4. View History\n5. Logout");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CheckBalance();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        ViewHistory();
                        break;
                    case "5":
                        currentUser = null;
                        Console.WriteLine("Logged out successfully.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void CheckBalance()
        {
            Console.WriteLine($"Your balance: {currentUser.Balance} GEL");
            Log($"{currentUser.Name} {currentUser.LastName} - checked the balance on: {DateTime.Now}");
        }

        public static void Deposit()
        {
            Console.Write("Enter amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                currentUser.Balance += amount;
                Console.WriteLine($"Deposited {amount} GEL. Your current balance: {currentUser.Balance} GEL");
                Log($"{currentUser.Name} {currentUser.LastName} - filled the balance with {amount} GEL on: {DateTime.Now}. Its current balance is {currentUser.Balance} GEL");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        public static void Withdraw()
        {
            Console.Write("Enter amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= currentUser.Balance)
                {
                    currentUser.Balance -= amount;
                    Console.WriteLine($"Withdrawn {amount} GEL. Your current balance: {currentUser.Balance} GEL");
                    Log($"{currentUser.Name} {currentUser.LastName} cashed out for {amount} GEL on: {DateTime.Now}. Its current balance is {currentUser.Balance} GEL");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }


        public static void ViewHistory()
        {
            Console.WriteLine(File.ReadAllText(logFilePath));

        }
        private static List<User> Parse(string input)
        {
            List<User> result = System.Text.Json.JsonSerializer.Deserialize<List<User>>(input);

            if (result == null || !result.Contains(currentUser))
            {
                throw new FormatException("Invalid format while deserialization");
            }

            return result;


        }

    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }

}
