using BlogApp.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace BlogUI
{
    public class BlogProvider
    {
        private static readonly HttpClient client = new HttpClient();

        public async void AddUser(User user)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7075/api/user", user);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("User added successfully");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error adding user : {ex}");
            }
        }

        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();
            try
            {
                users = await client.GetFromJsonAsync<List<User>>("https://localhost:7075/api/user");
                return users;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error getting users");
                return users;
            }
        }

        public async Task DeleteUser(User user)
        {
            try
            {
                await client.DeleteAsync($"https://localhost:7075/api/user?userId={user.UserId}");
                MessageBox.Show("User deleted");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"User not deleted : {ex.Message}");
            }
        }

        public async void AddBlog(Blog blog)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7075/api/blog", blog);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Blog added successfully");
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error adding blog");
            }
        }

        public async Task<List<Blog>> GetBlogs()
        {
            var blogs = new List<Blog>();
            try
            {
                blogs = await client.GetFromJsonAsync<List<Blog>>("https://localhost:7075/api/blog");
                return blogs;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error getting blogs");
                return blogs;
            }
        }

        public async Task DeleteBlog(Blog blog)
        {
            try
            {
                await client.DeleteAsync($"https://localhost:7075/api/blog?blogId={blog.BlogId}");
                MessageBox.Show("Blog deleted");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Blog not deleted : {ex.Message}");
            }
        }

        public async void AddPost(Post post)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7075/api/post", post);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Post added successfully");
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error adding post");
            }
        }

        public async Task<List<Post>> GetPosts()
        {
            var posts = new List<Post>();
            try
            {
                posts = await client.GetFromJsonAsync<List<Post>>("https://localhost:7075/api/post");
                return posts;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error getting users");
                return posts;
            }
        }

        public async Task DeletePost(Post post)
        {
            try
            {
                await client.DeleteAsync($"https://localhost:7075/api/post?postId={post.PostId}");
                MessageBox.Show("Post deleted");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Post not deleted : {ex.Message}");
            }
        }
    }
}
