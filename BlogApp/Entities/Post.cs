namespace BlogApp.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Content { get; set; }
        public required string Title { get; set; }
        public string? DateTime { get; set; }
    }
}
