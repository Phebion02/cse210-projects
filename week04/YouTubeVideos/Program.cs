using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Mike", 600);
        video1.AddComment(new Comment("Sarah", "Great recipe!"));
        video1.AddComment(new Comment("John", "Very helpful."));
        video1.AddComment(new Comment("Emma", "Trying this tonight!"));

        // Create Video 2
        Video video2 = new Video("Learn C# in 30 Minutes", "CodeMaster", 1800);
        video2.AddComment(new Comment("Alex", "This explained a lot."));
        video2.AddComment(new Comment("Maria", "Please make more tutorials!"));
        video2.AddComment(new Comment("David", "Awesome video."));

        // Create Video 3
        Video video3 = new Video("Top 10 Travel Destinations", "TravelerTom", 900);
        video3.AddComment(new Comment("Lily", "I want to visit Japan!"));
        video3.AddComment(new Comment("Noah", "Great editing."));
        video3.AddComment(new Comment("Olivia", "Very inspiring!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display Videos
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine("-----------------------------------");
        }
    }
}
    
