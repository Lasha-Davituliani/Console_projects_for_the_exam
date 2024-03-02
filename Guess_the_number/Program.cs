using System;

class NumberGuessingGame
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("Choose your difficulty level:");
        Console.WriteLine("1. Easy (1-25)");
        Console.WriteLine("2. Medium (1-50)");
        Console.WriteLine("3. Hard (1-100)");

        int choice;
        int maxNumber;

        while (true)
        {
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice >= 1 && choice <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        switch (choice)
        {
            case 1:
                maxNumber = 25;
                break;
            case 2:
                maxNumber = 50;
                break;
            case 3:
                maxNumber = 100;
                break;
            default:
                maxNumber = 25;
                break;
        }

        Random random = new Random();
        int randomNumber = random.Next(1, maxNumber + 1);
        int attempts = 10;

        Console.WriteLine($"I've picked a number between 1 and {maxNumber}. You have 10 attempts to guess it.");

        while (attempts > 0)
        {
            Console.Write("Enter your guess: ");

            if (int.TryParse(Console.ReadLine(), out int guess))
            {
                if (guess == randomNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the number in {11 - attempts} attempts!");
                    return;
                }
                else if (guess < randomNumber)
                {
                    Console.WriteLine("The target number is higher.");
                }
                else
                {
                    Console.WriteLine("The target number is lower.");
                }

                attempts--;
                Console.WriteLine($"Attempts: {attempts}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        Console.WriteLine($"Sorry, you've run out of attempts. The number was {randomNumber}.");
    }
}
