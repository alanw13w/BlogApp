using BlogService.Context;
using BlogService.Models;

namespace BlogService
{
    public static class BlogRepository
    {
        public static string ResetDatabase()
        {
            try
            {
                using (var db = new BlogContext())
                {
                    db.RemoveRange(db.Blogs);
                    db.RemoveRange(db.Users);
                    db.RemoveRange(db.Posts);
                    db.SaveChanges();
                }
                return "Database reset";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string createUser(UserModel user)
        {
            using (var db = new BlogContext())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return "User created";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

        }

        public static string createPost(PostModel post)
        {
            using (var db = new BlogContext())
            {
                try
                {
                    db.Posts.Add(post);
                    db.SaveChanges();
                    return "Post created";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        public static string createBlog(BlogModel blog)
        {
            using (var db = new BlogContext())
            {
                try
                {
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                    return "Blog created";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}