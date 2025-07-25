using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // You can change this scripture and reference as needed
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // You can change how many words to hide per round
        }

        // Final display
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}

class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return startVerse == endVerse
            ? $"{book} {chapter}:{startVerse}"
            : $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}

class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        if (isHidden)
        {
            return new string('_', text.Length);
        }
        else
        {
            return text;
        }
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;

        // Split by space and handle punctuation simply
        string[] splitWords = text.Split(' ');
        words = new List<Word>();

        foreach (string word in splitWords)
        {
            words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = words.Where(w => !w.IsHidden()).ToList();

        int wordsToHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string joinedText = string.Join(" ", words.Select(w => w.GetDisplayText()));
        return $"{reference.GetDisplayText()} - {joinedText}";
    }

    public bool IsCompletelyHidden()
    {
        return words.All(w => w.IsHidden());
    }
}
