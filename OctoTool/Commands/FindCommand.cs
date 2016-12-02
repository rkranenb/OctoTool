using System;
using System.Linq;

namespace OctoTool.Commands {

    public class FindCommand : ICommand {

        private readonly IMachinesFileReader reader;

        public FindCommand(IMachinesFileReader reader) {
            this.reader = reader;
        }
        public void Execute(string[] args) {
            if (args == null || args.Length == 0) return;
            reader.ReadAll()
                .Where(x => x.Name.Contains(args[0]))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }

        public bool ShouldExecute(string[] args) {
            return args.ContainsOrdinalIgnoreCase("find");
        }
    }
}
