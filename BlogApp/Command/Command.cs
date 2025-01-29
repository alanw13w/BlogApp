using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Command
{
    public abstract class Command
    {
        public string Name { get; private set; } = "";
        public string? Parameter { get; private set; } = null;
        public string Description { get; private set; }
        public bool ParameterIsRequired { get; private set; } = false;

        public Command(string command, string descr)
        {
            // Using null as separater means any blank characters
            var tokens = command.Trim().ToLower().Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            foreach (var t in tokens)
            {
                if (t.StartsWith("<") && t.EndsWith(">") || t.StartsWith("[") && t.EndsWith("]"))
                {
                    Parameter = t[1..^1];
                    ParameterIsRequired = t.StartsWith("<");
                    break;
                }
                Name += t + ' ';
            }
            Name = Name.Trim();

            Description = descr.Trim();

        }

        public bool Match(string cmd, out string param)
        {
            param = "";
            // Replace any sequence of blank chars by a single space
            cmd = Regex.Replace(cmd.Trim(), @"\s+", " ");
            var match = cmd.StartsWith(Name, StringComparison.OrdinalIgnoreCase);
            if (match && Parameter != null && cmd.Length > Name.Length)
                param = cmd[(Name.Length + 1)..];
            return match;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            if (Parameter != null)
            {
                sb.Append(ParameterIsRequired ? " <" : " [");
                sb.Append(Parameter);
                sb.Append(ParameterIsRequired ? '>' : ']');
            }
            sb.Append(" : \t");
            sb.Append(Description);
            return sb.ToString();
        }

        public int CompareTo(Command other)
        {
            return Name.CompareTo(other.Name);
        }

        public abstract string? Execute(string? parameter = null);
    }
}
