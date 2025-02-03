using BlogApp.Entities;
using System.Net.Http;
using System.Net.Http.Json;
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
                FirstName = FirstNameInput.Text ?? "",
                LastName = LastNameInput.Text ?? "",
                Password = PasswordInput.Text ?? "",
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

        public async Task<List<User>> GetUsers() { 
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
            var users = await GetUsers();
            foreach (var u in users)
            {
                UsersListBox.Items.Add($"Id : {u.UserId}, FirstName: {u.FirstName}, LastName: {u.LastName}, Password: {u.Password}, Pseudo: {u.Pseudo}");
            }
        }
    }
}