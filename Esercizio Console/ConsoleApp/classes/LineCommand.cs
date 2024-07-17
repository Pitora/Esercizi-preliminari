namespace ConsoleApp
{
    public class LineCommand(Receiver receiver, string line = "") : ICommand
    {

        Receiver _receiver = receiver;
        string _line = line;

        public void Execute()
        {
            _receiver.Acquire([_line]);
        }

        public void Undo()
        {
            _receiver.Remove(1);
        }
    }
}