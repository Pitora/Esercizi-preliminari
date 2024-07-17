namespace ConsoleApp
{
    public class DateCommand(Receiver receiver) : ICommand
    {
        Receiver _receiver = receiver;
        string date = DateTime.Now.ToString("");
        public void Execute()
        {
            _receiver.Acquire([date]);
        }

        public void Undo()
        {
            _receiver.Remove(1);
        }
    }
}