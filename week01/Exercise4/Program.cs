using System;

class Program
{
    static void Main(string[] args)
    {
        List < int > Numbers = new List <int> ();
        int UserEntry = -1;
        Console.WriteLine("Enter a list of numbers, type 0 to quit");
        while (UserEntry != 0)
        {
            Console.Write("Enter a number ");
            string Numberss = Console.ReadLine();
            UserEntry = int.Parse(Numberss);
            if (UserEntry != 0)
            {
                Numbers.Add(UserEntry);
            }
        }
        if (Numbers.Count > 0)
        {
            int sum = Numbers.Sum();
            double average = Numbers.Average();
            int max = Numbers.Max();
            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine($"The average is {average}");
            Console.WriteLine($"The max number is {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered");
        }
    }
}