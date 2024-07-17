namespace ConsoleApp
{
    public class SampleCommand(Receiver receiver) : ICommand
    {
        Receiver _receiver = receiver;
        string[] sample = ["PAGINA DI PROVA", "  --  1234567890  -- ", " 05-07-2024 ", "FINE PAGINA DI PROVA"];

        public void Execute()
        {
            _receiver.NewPage(sample.Length);
            _receiver.Acquire(sample);
        }

        public void Undo()
        {
            _receiver.RemoveLastPage();
        }
    }
}