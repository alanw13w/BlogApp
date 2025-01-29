namespace BlogApp.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; } 


        public Blog(int blogId, string name)
        {
            BlogId = blogId;
            Name = name;
        }

        public Blog() { }
    }
}
