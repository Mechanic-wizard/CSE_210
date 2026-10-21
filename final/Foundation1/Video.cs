using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        private string PB_title;
        private string PB_author;
        private int PB_lengthSeconds;
        private List<Comment> PB_comments;

        public Video(string title, string author, int lengthSeconds)
        {
            PB_title = title;
            PB_author = author;
            PB_lengthSeconds = lengthSeconds;
            PB_comments = new List<Comment>();
        }

        public string Title => PB_title;
        public string Author => PB_author;
        public int LengthSeconds => PB_lengthSeconds;

        public void AddComment(Comment comment)
        {
            PB_comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return PB_comments.Count;
        }

        public List<Comment> GetComments()
        {
            return new List<Comment>(PB_comments);
        }
    }
}