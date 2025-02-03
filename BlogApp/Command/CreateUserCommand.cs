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

            //var repository =  BlogRepository();
            //repository.createUser(new User { Pseudo = parameter });

            return $"Utilisateur {parameter} créé";
        }
    }
}