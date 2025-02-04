using BlogService.Context;
using BlogService.Models;
using System.Diagnostics;

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

        //USERS

        public static List<UserModel> getUsers()
        {
            using (var db = new BlogContext())
            {
                return db.Users.ToList();
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

        public static string deleteUser(UserModel user)
        {
            using (var db = new BlogContext())
            {
                try
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return "user deleted";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        //POSTS

        public static List<PostModel> getPosts()
        {
            using (var db = new BlogContext())
            {
                return db.Posts.ToList();
            }
        }

        public static string createPost(PostModel post)
        {
            using (var db = new BlogContext())
            {
                try
                {
                    Debug.WriteLine(post);
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

        public static string deletePost(PostModel post)
        {
            using (var db = new BlogContext())
            {
                try
                {
                    db.Posts.Remove(post);
                    db.SaveChanges();
                    return "Post deleted";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        //BLOGS

        public static List<BlogModel> getBlogs()
        {
            using (var db = new BlogContext())
            {
                return db.Blogs.ToList();
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

        public static string deleteBlog(BlogModel blog)
        {
            using (var db = new BlogContext())
            {
                try
                {
                    db.Blogs.Remove(blog);
                    db.SaveChanges();
                    return "Blog deleted";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}