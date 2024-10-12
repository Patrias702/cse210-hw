using System;
using System.Collections.Generic;


class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } 
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine(comment);
        }
        Console.WriteLine();
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        Video video1 = new Video("C# Tutorial", "Tech Guy", 600);
        Video video2 = new Video("Learning ASP.NET", "Code Academy", 900);
        Video video3 = new Video("OOP Concepts", "Programming Guru", 720);

       
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very informative."));
        video1.AddComment(new Comment("Mike", "Loved the explanation."));

        
        video2.AddComment(new Comment("Anna", "Thanks for the clear explanation."));
        video2.AddComment(new Comment("Tom", "This helped me a lot!"));
        video2.AddComment(new Comment("Kate", "Good content!"));

        
        video3.AddComment(new Comment("Leo", "Perfect intro to OOP."));
        video3.AddComment(new Comment("Sophia", "Just what I needed."));
        video3.AddComment(new Comment("David", "Super helpful, thanks!"));

        
        List<Video> videos = new List<Video> { video1, video2, video3 };

        
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
