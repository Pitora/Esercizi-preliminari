namespace ConsoleApp
{
    public class WhitePageCommand(Receiver receiver) : ICommand
    {
        Receiver _receiver = receiver;
        public void Execute()
        {
            _receiver.NewPage(20);
        }

        public void Undo()
        {
            _receiver.RemoveLastPage();
        }
    }
}