using BlogApp.Entities;

namespace BlogService.Models
{
    public class BlogModel
    {
        public int BlogModelId { get; set; }
        public required string Name { get; set; }

        public List<PostModel> PostModels { get; set; }



        static public BlogModel fromDomainEntity(Blog blog)
        {
            return new BlogModel
            {
                BlogModelId = blog.BlogId,
                Name = blog.Name,
                PostModels = null,
            };
        }
    }
}
