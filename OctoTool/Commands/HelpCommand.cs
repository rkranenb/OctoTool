using System;

namespace OctoTool.Commands {

    public class HelpCommand : ICommand {

        public void Execute(string[] args) {
            Console.WriteLine("Help!");
        }

        public bool ShouldExecute(string[] args) {
            return args.Length > 0 && "help".Equals(args[0], StringComparison.OrdinalIgnoreCase);
        }

    }
}
