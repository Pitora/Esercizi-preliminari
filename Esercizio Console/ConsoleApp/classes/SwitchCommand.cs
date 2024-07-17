namespace ConsoleApp
{
    public class SwitchCommand(Receiver receiver) : ICommand
    {

        Receiver _receiver = receiver;

        public void Execute()
        {
            _receiver.Switch();
        }

        public void Undo()
        {
            _receiver.Switch();
        }
    }
}