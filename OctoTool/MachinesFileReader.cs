using Newtonsoft.Json;
using System.IO;

namespace OctoTool {

    public interface IMachinesFileReader {
        Machine[] ReadAll();
    }

    public class MachinesFileReader : IMachinesFileReader {
        public Machine[] ReadAll() {
            using (var reader = new StreamReader("machines.json")) {
                return JsonConvert.DeserializeObject<Machine[]>(reader.ReadToEnd());
            }
        }
    }

}
