using BlogApp.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace BlogUI
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        BlogProvider provider = new BlogProvider();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_User_Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                FirstName = FirstNameInput.Text,
                LastName = LastNameInput.Text,
                Password = PasswordInput.Text,
                Pseudo = PseudoInput.Text ?? "",
            };

            provider.AddUser(user);
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
           RefreshUsers();
        }

        private async void RefreshUsers()
        {
            UsersListBox.Items.Clear();
            var users = await provider.GetUsers();
            foreach (var u in users)
            {
                UsersListBox.Items.Add($"Id : {u.UserId}, FirstName: {u.FirstName}, LastName: {u.LastName}, Password: {u.Password}, Pseudo: {u.Pseudo}");
            }
        }

        private async void Add_Blog_Button_Click(object sender, RoutedEventArgs e)
        {
            Blog blog = new Blog
            {
                Name = BlogNameInput.Text ?? "",
            };

            provider.AddBlog(blog);
        }

        private void Refresh_Blog_Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshBlogs();
        }

        private async void RefreshBlogs()
        {
            BlogListBox.Items.Clear();
            var blogs = await provider.GetBlogs();
            foreach (var b in blogs)
            {
                BlogListBox.Items.Add($"Id : {b.BlogId}, Name: {b.Name}");
            }
        }

        private async void Add_Post_Button_Click(object sender, RoutedEventArgs e)
        {
            Post post = new Post
            {
                Title = TitleInput.Text ?? "",
                Content = ContentInput.Text,
                DateTime = DateTime.Now.ToString(),
                BlogId = await GetBlogIdByName(BlogComboBox.Text),
                UserId = await GetUserIdByPseudo(UserComboBox.Text),
            };

            provider.AddPost(post);
        }

        private async void setBlogComboBox()
        {
            BlogComboBox.Items.Clear();
            var blogs = await provider.GetBlogs();
            foreach (var b in blogs)
            {
                BlogComboBox.Items.Add(b.Name);
            }
        }

        private async void setUserComboBox()
        {
            UserComboBox.Items.Clear();
            var users = await provider.GetUsers();
            foreach (var u in users)
            {
                UserComboBox.Items.Add(u.Pseudo);
            }
        }

        private async Task<int> GetBlogIdByName(string name)
        {
            List<Blog> blogs = await provider.GetBlogs();
            Blog blog = blogs.FirstOrDefault(b => b.Name == name);
            return blog.BlogId;
        }

        private async Task<int> GetUserIdByPseudo(string pseudo)
        {
            List<User> users = await provider.GetUsers();
            User user = users.FirstOrDefault(u => u.Pseudo == pseudo);
            return user.UserId;
        }

        private void BlogComboBox_DropDownOpened(object sender, EventArgs e)
        {
            setBlogComboBox();
        }

        private void UserComboBox_DropDownOpened(object sender, EventArgs e)
        {
            setUserComboBox();
        }

        private void Refresh_Post_Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshPosts();
        }

        private async void RefreshPosts()
        {
            PostListBox.Items.Clear();
            var post = await provider.GetPosts();
            foreach (var p in post)
            {
                PostListBox.Items.Add($"Id : {p.PostId}, Title: {p.Title}, Content: {p.Content}, DateTime: {p.DateTime}, BlogId: {p.BlogId}, UserId: {p.UserId}");
            }
        }

        private async void UsersListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(UsersListBox.SelectedItems != null && e.AddedItems.Count > 0)
            {
                List<User> users = await provider.GetUsers();
                User user = users[UsersListBox.SelectedIndex];
                await provider.DeleteUser(user);
                RefreshUsers();
            }
        }

        private async void BlogListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (BlogListBox.SelectedItems != null && e.AddedItems.Count > 0)
            {
                List<Blog> blogs = await provider.GetBlogs();
                Blog blog = blogs[BlogListBox.SelectedIndex];
                await provider.DeleteBlog(blog);
                RefreshBlogs();
            }
        }

        private async void PostListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (PostListBox.SelectedItems != null && e.AddedItems.Count > 0)
            {
                List<Post> posts = await provider.GetPosts();
                Post post = posts[PostListBox.SelectedIndex];
                await provider.DeletePost(post);
                RefreshPosts();
            }
        }
    }
}