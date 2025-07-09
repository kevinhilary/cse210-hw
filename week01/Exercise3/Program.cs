using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int MagicNumber = randomGenerator.Next(1,101);
        int Guess = -1;
        while (Guess != MagicNumber)
        {
            Console.Write("What is your Guess? ");
            String input =Console.ReadLine();
            Guess = int.Parse(input);
            if (Guess > MagicNumber)
            {
                Console.WriteLine("Guess Lower");
            }
            else if (Guess < MagicNumber)
            {
                Console.WriteLine("Guess higher");
            }
            else
            {
                Console.WriteLine("You guessed it right!");
            }
        }
    }
}