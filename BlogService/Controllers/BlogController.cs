using BlogApp.Entities;
using BlogService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Controllers
{
    public class BlogController : Controller
    {
        [Route("/api/restetDb")]
        [HttpGet]
        public ActionResult<string> ResetDatabase()
        {
            return BlogRepository.ResetDatabase();
        }

        [Route("/api/user")]
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<UserModel> userModel = BlogRepository.getUsers();

            List<User> users = new List<User>();
            foreach (var i in userModel)
            {
                users.Add(i.toDomainEntity());
            }

            return users;
        }

        [Route("/api/user")]
        [HttpPost]
        public ActionResult<string> CreateUser([FromBody]User user)
        {
            UserModel userModel = UserModel.fromDomainEntity(user);
            return BlogRepository.createUser(userModel);
        }

        [Route("/api/user")]
        [HttpDelete]
        public ActionResult<string> DeleteUser(User user)
        {
            UserModel userModel = UserModel.fromDomainEntity(user);
            return BlogRepository.deleteUser(userModel);
        }

        [Route("/api/post")]
        [HttpGet]
        public ActionResult<List<Post>> GetPosts()
        {
            List<PostModel> postModel = BlogRepository.getPosts();
            List<Post> posts = new List<Post>();
            foreach (var i in postModel)
            {
                posts.Add(i.toDomainEntity());
            }
            return posts;
        }

        [Route("/api/post")]
        [HttpPost]
        public ActionResult<string> CreatePost([FromBody]Post post)
        {
            PostModel postModel = PostModel.fromDomainEntity(post);
            return BlogRepository.createPost(postModel);
        }

        [Route("/api/post")]
        [HttpDelete]
        public ActionResult<string> DeletePost(Post post)
        {
            PostModel postModel = PostModel.fromDomainEntity(post);
            return BlogRepository.deletePost(postModel);
        }

        [Route("api/post/user")]
        [HttpGet]



        [Route("/api/blog")]
        [HttpGet]
        public ActionResult<List<Blog>> GetBlogs()
        {
            List<BlogModel> blogModel = BlogRepository.getBlogs();
            List<Blog> blogs = new List<Blog>();
            foreach (var i in blogModel)
            {
                blogs.Add(i.toDomainEntity());
            }
            return blogs;
        }

        [Route("/api/blog")]
        [HttpPost]
        public ActionResult<string> CreateBlog([FromBody]Blog blog)
        {
            BlogModel blogModel = BlogModel.fromDomainEntity(blog);
            return BlogRepository.createBlog(blogModel);
        }

        [Route("/api/blog")]
        [HttpDelete]
        public ActionResult<string> DeleteBlog(Blog blog)
        {
            BlogModel blogModel = BlogModel.fromDomainEntity(blog);
            return BlogRepository.deleteBlog(blogModel);
        }
    }
}
