namespace BlogApp.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }


        public Post(int postId, string title, string content, string dateTime, int userId, int blogId)
        {
            PostId = postId;
            Content = content;
            Title = title;
            DateTime = dateTime;
            UserId = userId;
            BlogId = blogId;
        }

        public Post() { }

    }
}


