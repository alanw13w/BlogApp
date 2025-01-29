using System.Text;

namespace BlogApp.Command
{
    public class CommandList
    {
        private class HelpCommand : Command
        {
            private CommandList commandList;
            public HelpCommand(CommandList cmdList) : base("help", "Affiche la liste des commandes")
            {
                commandList = cmdList;
            }

            public override string? Execute(string? parameter = null)
            {
                return commandList.ToString();
            }
        }

        private readonly List<Command> commands = new();

        public CommandList()
        {
            Add(new HelpCommand(this));
        }

        public void Add(Command command)
        {
            commands.Add(command);
            //commands.Sort();
        }

        public void Execute(string cmdline)
        {
            if (string.IsNullOrWhiteSpace(cmdline))
                return;
            cmdline = cmdline.Trim();
            foreach (var c in commands)
            {
                if (c.Match(cmdline, out var param))
                {
                    if (c.ParameterIsRequired && string.IsNullOrWhiteSpace(param))
                    {
                        Console.Write($"{c.Parameter}: ");
                        param = Console.ReadLine()?.Trim();
                        if (string.IsNullOrWhiteSpace(param))
                        {
                            Console.WriteLine($"Le paramètre \"{c.Parameter}\" est requis");
                            return;
                        }
                    }
                    var output = c.Execute(param);
                    if (output != null)
                        Console.WriteLine(output);
                    return;
                }
            }
            Console.WriteLine("Commande invalide");
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var c in commands)
                sb.AppendLine(c.ToString());
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

    }
}
