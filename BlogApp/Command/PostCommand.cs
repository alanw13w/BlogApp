using BlogApp.Entities;

namespace BlogApp.Command
{
    public class PostCommand : Command
    {
        public PostCommand() : base("post <message>", "Crée un nouveau post dans le blog public")
        {
        }
        public override string Execute(string? parameter = null)
        {
            if (parameter == null)
            {
                return "Le message est requis";
            }

            //using (var db = new BlogContext())
            //{
            //    var blog = db.Blogs.FirstOrDefault(b => b.Name == "Public");

            //    var user = db.Users.FirstOrDefault(u => u.Pseudo == Environment.UserName);

            //    if (blog == null)
            //    {
            //        return "Le blog public n'existe pas";
            //    }

            //    db.Posts.Add(new Post { Title = "Default Title", Content = parameter, BlogId = blog.BlogId, UserId = user.UserId });
            //    db.SaveChanges();
            //}

            return "Post créé";
        }
    }
}
