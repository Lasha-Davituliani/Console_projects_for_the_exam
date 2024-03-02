
while (true)
{
    Console.WriteLine("Simple Calculator:");
    Console.Write("Enter the first number: ");
    if (!double.TryParse(Console.ReadLine(), out double num1))
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        continue;
    }
    Console.WriteLine($"Choose an operation ||\"+\"||\"-\"||\"*\"||\"/\"|| :");
    string choice = Console.ReadLine();
    if (!IsValidChoice(choice))
    {
        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
        continue;
    }
    Console.Write("Enter the second number: ");
    if (!double.TryParse(Console.ReadLine(), out double num2))
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        continue;
    }
    double result = PerformOperation(choice, num1, num2);

    Console.WriteLine($"Result: {result}\n");
    Console.WriteLine("Do you want to exit the program? write \"yes\"");
    string exit = Console.ReadLine();

    if (exit.ToLower() == "yes")
    {
        Console.WriteLine("Exiting the calculator. Goodbye!");
        break;
    }
    else
    {
        continue;
    }
}
static bool IsValidChoice(string choice)
{
    return choice == "+" || choice == "-" || choice == "*" || choice == "/";
}
static double PerformOperation(string choice, double num1, double num2)
{
    switch (choice)
    {
        case "+":
            return num1 + num2;
        case "-":
            return num1 - num2;
        case "*":
            return num1 * num2;
        case "/":
            if (num2 != 0)
                return num1 / num2;
            else
            {
                Console.WriteLine("Error: Division by zero.");
                return 0.0;
            }
        default:
            throw new InvalidOperationException("Invalid operation");
    }
}