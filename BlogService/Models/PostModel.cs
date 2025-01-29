using BlogApp.Entities;

namespace BlogService.Models
{
    public class PostModel
    {
        public int PostModelId { get; set; }
        public required string Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public string DateTime { get; set; } = string.Empty;

        public int BlogModelId { get; set; }
        public BlogModel? BlogModel { get; set; }

        public int UserModelId { get; set; }
        public UserModel? UserModel { get; set; }


        public static PostModel fromDomainEntity(Post post)
        {
            return new PostModel
            {
                PostModelId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                DateTime = post.DateTime,
                BlogModelId = 0,
                UserModelId = 0,
                BlogModel = null,
                UserModel = null,
            };
        }
    }
}
