using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create list to hold videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("The Power of Focus", "Brian Tracy", 480);
        video1.AddComment(new Comment("Alice", "Amazing message!"));
        video1.AddComment(new Comment("James", "Very motivating."));
        video1.AddComment(new Comment("Grace", "Thanks for sharing this!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("How to Cook Ugali", "Chef Kendi", 300);
        video2.AddComment(new Comment("George", "Now I’m hungry 😋"));
        video2.AddComment(new Comment("Njeri", "Tried it and it turned out great!"));
        video2.AddComment(new Comment("Brian", "Simple and helpful, thanks."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 5 Study Tips", "StudySmart", 250);
        video3.AddComment(new Comment("Elijah", "Tip 3 changed my life."));
        video3.AddComment(new Comment("Martha", "Exactly what I needed."));
        video3.AddComment(new Comment("Joseph", "Shared this with my classmates."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Funny Cats Compilation", "LaughDaily", 180);
        video4.AddComment(new Comment("Liam", "😂😂😂 I can’t stop laughing"));
        video4.AddComment(new Comment("Ivy", "This made my day!"));
        video4.AddComment(new Comment("Sam", "More of this please!"));
        videos.Add(video4);

        // Display all video details
        foreach (Video video in videos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}

// Video class using abstraction
class Video
{
    private string title;
    private string author;
    private int length; // in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public int GetLength()
    {
        return length;
    }
}

// Comment class
class Comment
{
    private string name;
    private string text;

    public Comment(string name, string text)
    {
        this.name = name;
        this.text = text;
    }

    public string GetName()
    {
        return name;
    }

    public string GetText()
    {
        return text;
    }
}
