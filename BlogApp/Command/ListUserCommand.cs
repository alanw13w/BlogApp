
namespace BlogApp.Command
{
    public class ListUserCommand : Command
    {
        public ListUserCommand() : base("list users", "LIst des utilisateurs") { }

        public override string? Execute(string? parameter = null)
        {
            string result = "";

            //using (var db = new BlogContext())
            //{
            //    var users = db.Users.ToList();
            //    foreach (var u in users)
            //        result += u.Pseudo + " / ";
            //}
            return result;
        }
    }
}
