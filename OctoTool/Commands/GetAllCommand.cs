using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace OctoTool.Commands {

    public class GetAllCommand : ICommand {

        private readonly IMachinesQuery query;

        public GetAllCommand(IMachinesQuery query) {
            this.query = query;
        }

        public void Execute(string[] args) {
            var task = Task.Run(async () => await query.Execute());
            task.Wait();
            Console.WriteLine(JsonConvert.SerializeObject(task.Result));
        }

        public bool ShouldExecute(string[] args) {
            return args.Length > 0 && "get-all".Equals(args[0], StringComparison.OrdinalIgnoreCase);
        }

    }
}
