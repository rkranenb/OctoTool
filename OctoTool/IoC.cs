using StructureMap;


namespace OctoTool {
    internal static class IoC {

        public static IContainer Initialize() {
            return new Container(registry => {
                registry.Scan(scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<Commands.ICommand>();
                });
            });
        }
    }
}
