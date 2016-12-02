using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctoTool {

    public interface IMachinesQuery {
        Task<Machine[]> Execute();
    }

    public class MachinesQuery : IMachinesQuery {

        private readonly IOctoHttpClient client;

        public MachinesQuery(IOctoHttpClient client) {
            this.client = client;
        }

        public async Task<Machine[]> Execute() {

            var machines = new List<Machine>();

            var result = await client.GetAsync<MachinesQueryResponse>("machines");
            machines.AddRange(result.Items);

            int pageSize = result.ItemsPerPage;
            int remainingItems = result.TotalResults - result.Items.Length;
            int batch = 1;

            while (remainingItems > 0) {
                result = await client.GetAsync<MachinesQueryResponse>($"machines?skip={batch++ * pageSize}");
                machines.AddRange(result.Items);
                remainingItems = remainingItems - result.Items.Length;
            }

            return machines.ToArray();
        }
    }

    public class MachinesQueryResponse {
        public int TotalResults { get; set; }
        public int ItemsPerPage { get; set; }
        public Machine[] Items { get; set; }
    }
}
