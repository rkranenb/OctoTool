using System;
using System.Linq;

namespace OctoTool.Commands {
    internal static class Extensions {

        public static bool ContainsOrdinalIgnoreCase(this string[] values, string value) {
            return values == null ? false : values.Contains(value, StringComparer.OrdinalIgnoreCase);
        }
    }
}
