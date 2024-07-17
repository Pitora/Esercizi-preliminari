namespace ConsoleApp
{
    public class ReceiverU : Receiver
    {
        public ReceiverU(string name) : base(name)
        {

        }

        public override void Print()
        {
            Console.WriteLine($"\n{_name} is printing");
            for (int i = 0; i <= current_page; i++)
            {
                Console.WriteLine($"\nPrinting page {i}:");
                for (int j = 0; j < pages[i].Length; j++)
                {
                    if (pages[i][j] != null)
                    {
                        Console.WriteLine(pages[i][j].ToUpper() + "^");
                    }
                    else
                    {
                        Console.WriteLine("^");
                    }
                }
            }
            Console.WriteLine($"\n{_name} ended printing \n");
        }
    }
}