//using BlogApp;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        var commandList = new CommandList();

//        commandList.Add(new Exit());
//        commandList.Add(new CreateUserCommand());
//        commandList.Add(new ListUserCommand());
//        commandList.Add(new DeleteUserCommand());
//        commandList.Add(new PostCommand());


//        var currentUser = new User { Pseudo = Environment.UserName };
//        var publicBlog = new Blog { Name = "Public" };

//        using (var db = new BlogContext())
//        {
//            var usr = db.Users.FirstOrDefault(u => u.Pseudo == currentUser.Pseudo);
//            var blg = db.Blogs.FirstOrDefault(b => b.Name == publicBlog.Name);

//            if (usr == null)
//                db.Users.Add(currentUser);

//            if (blg == null)
//                db.Blogs.Add(publicBlog);

//            db.SaveChanges();
//        }

//        while (true)
//        {
//            Console.Write("$ ");
//            string m = Console.ReadLine();
//            commandList.Execute(m);
//        }

//    }
//}

public class Program
{
    public static void Main(string[] args)
    {
        //using (var db = new BlogContext())
        //{
        //    db.Database.EnsureCreated();
        //}
    }
}
