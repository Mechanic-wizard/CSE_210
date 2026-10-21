using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create videos
            Video video1 = new Video("C# Abstraction Tutorial", "CodeMaster", 640);
            Video video2 = new Video("Top 10 VS Code Extensions", "DevGuru", 520);
            Video video3 = new Video("Learn OOP in 30 Minutes", "TechExplained", 1800);

            // Add comments to video1
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
            video1.AddComment(new Comment("Charlie", "Could you cover interfaces next?"));
            video1.AddComment(new Comment("Diana", "Loved the examples."));

            // Add comments to video2
            video2.AddComment(new Comment("Eve", "Number 3 is my favorite."));
            video2.AddComment(new Comment("Frank", "I never knew about that extension."));
            video2.AddComment(new Comment("Grace", "Please make a part 2."));

            // Add comments to video3
            video3.AddComment(new Comment("Hank", "OOP finally makes sense!"));
            video3.AddComment(new Comment("Ivy", "Well structured."));
            video3.AddComment(new Comment("Jack", "Can I get the slides?"));
            video3.AddComment(new Comment("Karen", "Amazing pacing."));

            // Put videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Display all info
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthSeconds} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}