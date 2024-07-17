using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    public class Invoker
    {
        List<Receiver> printers = new List<Receiver>();
        List<ICommand> commands = new List<ICommand>();
        int last_command = -1;

        public Invoker()
        {
            printers.Add(new Receiver("Standard Printer"));
            printers.Add(new ReceiverU("Uppercase Printer"));
        }

        public int getNumberPrinters()
        {
            return printers.Count();
        }

        public string getNamePrinter(int i)
        {
            return printers[i].getName();
        }

        public void Undo(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (last_command >= 0)
                {
                    var command = commands[last_command - i];
                    command.Undo();
                    commands.RemoveAt(last_command);
                    last_command--;
                }
            }
        }

        public void Compute(int printer, int key)
        {
            if ((key > 0 && key < 8) && (printer < printers.Count && printer >= 0))
            {
                if (key == 1)
                {
                    var command = new SampleCommand(printers[printer]);
                    commands.Add(command);
                }
                else if (key == 2)
                {
                    var command = new WhitePageCommand(printers[printer]);
                    commands.Add(command);
                }
                else if (key == 3)
                {
                    var command = new HelloCommand(printers[printer]);
                    commands.Add(command);
                }
                else if (key == 4)
                {
                    var command = new LineCommand(printers[printer]);
                    commands.Add(command);
                }
                else if (key == 5)
                {
                    var command = new DateCommand(printers[printer]);
                    commands.Add(command);
                }
                else if (key == 6)
                {
                    var command = new SwitchCommand(printers[printer]);
                    commands.Add(command);
                }
                else if (key == 7)
                {
                    var command = new PrintCommand(printers[printer]);
                    commands.Add(command);
                }

                last_command++;
                commands[last_command].Execute();
            }
        }

        public void Line(int printer, string line = "")
        {
            var command = new LineCommand(printers[printer], line);
            command.Execute();
            commands.Add(command);
            last_command++;
        }


    }
}