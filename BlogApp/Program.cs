using BlogApp;
using BlogApp.Command;

public class Program
{
    public static void Main(string[] args)
    {
        var commandList = new CommandList();

        commandList.Add(new Exit());
        commandList.Add(new CreateUserCommand());
        commandList.Add(new ListUserCommand());
        commandList.Add(new DeleteUserCommand());
        commandList.Add(new PostCommand());



        while (true)
        {
            Console.Write("$ ");
            string m = Console.ReadLine();
            commandList.Execute(m);
        }

    }
}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//using (var db = new BlogContext())
//{
//    db.Database.EnsureCreated();
//}
//    }
//}
