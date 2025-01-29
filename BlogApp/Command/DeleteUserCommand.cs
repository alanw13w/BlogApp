
namespace BlogApp.Command
{
    public class DeleteUserCommand : Command
    {
        public DeleteUserCommand() : base("delete user <pseudo>", "Supprime un utilisateur")
        {
        }

        public override string? Execute(string? parameter = null)
        {
            if (parameter == null)
            {
                return "Le nom de l'utilisateur est requis";
            }
            //using (var db = new BlogContext())
            //{
            //    var user = db.Users.FirstOrDefault(u => u.Pseudo == parameter);
            //    db.Users.Remove(user);
            //    db.SaveChanges();
            //}
            return $"Utilisateur {parameter} supprimé";
        }
    }
}
