namespace BlogApp.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Password { get; set; }
        public string Pseudo { get; set; }

        //public User(int userId, string firstName, string lastName, string password, string pseudo)
        //{
        //    UserId = userId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Password = password;
        //    Pseudo = pseudo;
        //}

        public User() { }
    }
}