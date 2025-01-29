using BlogApp.Entities;
using BlogService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Controllers
{
    public class BlogController : Controller
    {
        [Route("/ResetDatabase")]
        [HttpGet]
        public ActionResult<string> ResetDatabase()
        {
            return BlogRepository.ResetDatabase();
        }

        [Route("/CreateUser")]
        [HttpPost]
        public ActionResult<string> CreateUser(User user)
        {
            UserModel userModel = UserModel.fromDomainEntity(user);
            return BlogRepository.createUser(userModel);
        }

        [Route("/CreatePost")]
        [HttpPost]
        public ActionResult<string> CreatePost(Post post)
        {
            PostModel postModel = PostModel.fromDomainEntity(post);
            return BlogRepository.createPost(postModel);
        }

        [Route("/CreateBlog")]
        [HttpPost]
        public ActionResult<string> CreateBlog(Blog blog)
        {
            BlogModel blogModel = BlogModel.fromDomainEntity(blog);
            return BlogRepository.createBlog(blogModel);
        }
    }
}
