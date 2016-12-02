namespace OctoTool.Commands {

    public interface ICommand {
        bool ShouldExecute(string[] args);
        void Execute(string[] args);
    }
}
