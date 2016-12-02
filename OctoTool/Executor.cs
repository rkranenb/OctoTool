using OctoTool.Commands;
using System;
using System.Linq;

namespace OctoTool {

    public interface IExecutor {
        void Execute(string[] args);
    }

    public class Executor : IExecutor {

        private readonly ICommand[] commands;

        public Executor(ICommand[] commands) {
            this.commands = commands;
        }

        public void Execute(string[] args) {
            args = args.Length > 0 ? args : new[] { "help" };
            var command = commands.Single(x => x.ShouldExecute(args));
            if (args == null) throw new Exception($"Invalid command: '{args[0]}'");
            command.Execute(args.Skip(1).ToArray());
        }
    }
}
