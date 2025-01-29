namespace BlogApp.Command
{
    public class Exit : Command
    {
        public Exit() : base("exit", "Quitte l'application") { }
        public override string? Execute(string? parameter = null)
        {
            Environment.Exit(0);
            return null;
        }
    }


}
