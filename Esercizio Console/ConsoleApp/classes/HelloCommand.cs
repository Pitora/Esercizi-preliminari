namespace ConsoleApp
{
    public class HelloCommand(Receiver receiver) : ICommand
    {

        Receiver _receiver = receiver;
        string hello = "hello world!";

        public void Execute()
        {
            _receiver.Acquire([hello]);
        }

        public void Undo()
        {
            _receiver.Remove(1);
        }
    }
}