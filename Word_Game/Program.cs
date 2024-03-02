namespace Word_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>()
            {
                "apple", "banana", "orange", "grape", "kiwi", "strawberry", "pineapple", "blueberry", "peach", "watermelon"
            };

            Random random = new Random();
            string wordToGuess = words[random.Next(words.Count)];
            char[] charsArray = new char[wordToGuess.Length];

            for (int i = 0; i < charsArray.Length; i++)
            {
                charsArray[i] = '-';
            }

            int attempts = 6;

            while (attempts > 0)
            {
                Console.WriteLine("Curent Word: " + new string(charsArray));
                Console.WriteLine("Attempts Left: " + attempts);
                Console.WriteLine("Enter a letter: ");
                char guess = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (wordToGuess.Contains(guess))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {
                            charsArray[i] = guess;
                        }

                    }
                    if (!charsArray.Contains('-'))
                    {
                        Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
                        break;
                    }

                }
                else
                {
                    attempts--;
                    Console.WriteLine($"The word does not contain a letter :{guess}");
                    if (attempts == 0)
                    {
                        Console.WriteLine("Sorry, you ran out of attempts. The correct word was: " + wordToGuess);
                    }
                }
            }
        }
    }
}
