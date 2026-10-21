namespace YouTubeVideos
{
    public class Comment
    {
        private string PB_commenterName;
        private string PB_text;

        public Comment(string commenterName, string text)
        {
            PB_commenterName = commenterName;
            PB_text = text;
        }

        public string CommenterName => PB_commenterName;
        public string Text => PB_text;
    }
}