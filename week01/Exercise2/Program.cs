using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        String UserInput = Console.ReadLine();
        int GradePercentage = int.Parse(UserInput);
        String letter = "";
        if (GradePercentage >= 90)
        {
            letter = "A";
        }
        else if (GradePercentage >= 80)
        {
            letter = "B";
        }
        else if (GradePercentage >= 70)
        {
            letter = "C";
        }
        else if (GradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (GradePercentage >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}