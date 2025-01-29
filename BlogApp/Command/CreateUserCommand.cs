using BlogApp.Entities;

namespace BlogApp.Command
{
    public class CreateUserCommand : Command
    {
        public CreateUserCommand() : base("create user <pseudo>", "Crée un nouvel utilisateur") { }
        public override string? Execute(string? parameter = null)
        {
            if (parameter == null)
                return "Le nom de l'utilisateur est requis";
            var user = new User { Pseudo = parameter };

            //using (var db = new BlogContext())
            //{
            //    db.Users.Add(user);
            //    db.SaveChanges();
            //}

            return $"Utilisateur {parameter} créé";
        }
    }
}
