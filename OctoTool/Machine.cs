using System.Text;

namespace OctoTool {
    public class Machine {
        public string Id { get; set; }
        public bool IsDisabled { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool HasLatestCalamari { get; set; }
        public string[] Roles { get; set; }

        public override string ToString() {
            return new StringBuilder()
                .AppendLine($"{Name} (${Id})")
                .AppendLine($"  Disabled: {IsDisabled}")
                .AppendLine($"  Status: {Status}")
                .AppendLine($"  HasLatestCalamari: {HasLatestCalamari}")
                .AppendLine($"  Roles: {string.Join(", ", Roles)}")
                .ToString();
        }
    }
}
