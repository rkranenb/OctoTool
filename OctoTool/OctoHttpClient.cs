using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OctoTool {

    public interface IOctoHttpClient {
        Task<T> GetAsync<T>(params object[] args);
    }

    public class OctoHttpClient : IOctoHttpClient {
        private readonly IApiKeyProvider keyProvider;

        public OctoHttpClient(IApiKeyProvider keyProvider) {
            this.keyProvider = keyProvider;
        }
        public async Task<T> GetAsync<T>(params object[] args) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://octopus.wehkamp.io/api/");
                client.DefaultRequestHeaders.Add("X-Octopus-ApiKey", keyProvider.GetKey());
                var response = await client.GetAsync(string.Join("/", args.Select(x => x.ToString()).ToArray()));
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}
