namespace BlogApp.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }


        public Post(int postId, string title, string content, string dateTime)
        {
            PostId = postId;
            Content = content;
            Title = title;
            DateTime = dateTime;
        }

        public Post() { }

    }
}


