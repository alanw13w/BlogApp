using BlogApp.Entities;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Navigation;

namespace BlogUI
{
    public partial class MainWindow : Window
    {

        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Add_User_Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                FirstName = FirstNameInput.Text,
                LastName = LastNameInput.Text,
                Password = PasswordInput.Text,
                Pseudo = PseudoInput.Text ?? "",
            };

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7075/api/user", user);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("User added successfully");
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error adding user");
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

        private async void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            UsersListBox.Items.Clear();
            var users = await GetUsers();
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

        private async void Refresh_Blog_Button_Click(object sender, RoutedEventArgs e)
        {
            BlogListBox.Items.Clear();
            var blogs = await GetBlogs();
            foreach (var b in blogs)
            {
                BlogListBox.Items.Add($"Id : {b.BlogId}, Name: {b.Name}");
            }
        }

        public async Task<List<Blog>> GetBlogs()
        {
            var users = new List<Blog>();
            try
            {
                users = await client.GetFromJsonAsync<List<Blog>>("https://localhost:7075/api/blog");
                return users;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error getting users");
                return users;
            }
        }

        private async void Add_Post_Button_Click(object sender, RoutedEventArgs e)
        {
            Post post = new Post
            {
                Title = TitleInput.Text ?? "",
                Content = ContentInput.Text,
                DateTime = DateTime.Now.ToString(),
            };

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

        private void setBlogComboBox()
        {
            BlogComboBox.Items.Clear();
            var blogs = GetBlogs().Result;
            foreach (var b in blogs)
            {
                BlogComboBox.Items.Add(b.Name);
            }
        }

        private void BlogComboBox_ContextMenuOpening(object sender, System.Windows.Controls.ContextMenuEventArgs e)
        {
            setBlogComboBox();
        }
    }
}