namespace ConsoleApp
{
    public class PrintCommand(Receiver receiver) : ICommand
    {
        Receiver _receiver = receiver;
        public void Execute()
        {
            _receiver.Print();
        }

        public void Undo()
        {

        }
    }
}