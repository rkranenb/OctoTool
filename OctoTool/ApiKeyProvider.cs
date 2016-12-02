using System.IO;

namespace OctoTool {

    public interface IApiKeyProvider {
        string GetKey();
    }

    public class ApiKeyProvider : IApiKeyProvider {

        public string GetKey() {
            using (var reader = new StreamReader("api.key")) {
                return reader.ReadToEnd().Trim();
            }
        }

    }
}
