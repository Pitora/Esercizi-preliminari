namespace ConsoleApp
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
